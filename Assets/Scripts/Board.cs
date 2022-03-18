using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Titres
{
    public class Board : MonoBehaviour
    {
        public static Board Instance { get; private set; }

        public event System.Action<int> OnLineFull;
        public event System.Action OnGameOver;
        public System.Action<int> OnFullDrop;

        [SerializeField]
        private Vector2Int _boardSize = new Vector2Int(10, 20);
        [SerializeField]
        private PieceData[] _pieces;
        [SerializeField]
        private Vector3Int _spawnPosition = Vector3Int.zero;
        [SerializeField]
        private Vector3Int _previewCenter = new Vector3Int(11, 7, 0);
        [SerializeField]
        private RectInt _previewBounds = new RectInt(-1, -3, 4, 4);

        private Tilemap _tilemap;
        private Tilemap _ghostTilemap;
        private RectInt _bounds
        {
            get
            {
                return new RectInt(new Vector2Int(-_boardSize.x / 2, -_boardSize.y / 2), _boardSize);
            }
        }
        private ActivePiece _piece;
        private PieceData _nextPiece;



        #region MonoBehaviorCalls

        private void Awake()
        {
            if(!(Instance == null))
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
            _tilemap = transform.GetChild(0).GetComponent<Tilemap>();
            _ghostTilemap = transform.GetChild(1).GetComponent<Tilemap>();
            _piece = GetComponentInChildren<ActivePiece>();

            for(int i = 0; i<_pieces.Length; i++)
            {
                _pieces[i].Initialize();
            }

            PickPiece();
            SpawnPiece();
        }

        #endregion


        public bool IsValidPosition(ActivePiece piece, Vector3Int pos)
        {
            RectInt rect = _bounds;

            for (int i = 0; i < piece.cells.Length; i++)
            {
                Vector3Int tilePos = pos + piece.cells[i];

                if (!rect.Contains((Vector2Int)tilePos)) return false;

                if (_tilemap.HasTile(tilePos)) return false;

            }
            return true;
        }

        public void CheckLines(SortedSet<int> lines)
        {
            int row;
            bool fullLine = false;
            SortedSet<int> fullLines = new SortedSet<int>();
            foreach (int line in lines)
            {
                row = _tilemap.WorldToCell(Vector3.up * line).y;
                fullLine = IsLineFull(row);
                if (fullLine)
                {
                    LineClear(row);
                    fullLines.Add(row);
                }
            }
            if (fullLines.Count > 0)
            {
                OnLineFull?.Invoke(fullLines.Count);
                UpdateLines(fullLines);
            }
        }

        private void PickPiece()
        {
            int random = Random.Range(0, _pieces.Length);
            _nextPiece = _pieces[random];

            PrintNextPiece();
        }

        private void PrintNextPiece()
        {
            //clear preview
            for(int i = _previewBounds.xMin; i<= _previewBounds.xMax; i++)
            {
                for(int j= _previewBounds.yMin; j<=_previewBounds.yMax; j++)
                {
                    _tilemap.SetTile(_previewCenter + new Vector3Int(i, j, 0), null);
                }
            }

            //print next
            foreach(Vector3Int cell in _nextPiece.cells)
            {
                _tilemap.SetTile(_previewCenter + cell, _nextPiece.tile);
            }

        }

        public void SpawnPiece()
        {
            _piece.Initialize(_spawnPosition, _nextPiece);

            if (IsValidPosition(_piece, _spawnPosition)) { 

                SetPiece(_piece);
                PickPiece();
            }
            else
            {
                OnGameOver?.Invoke();
                _tilemap.ClearAllTiles();
            }
        }

        public void SetPiece(ActivePiece piece)
        {
            foreach (Vector3Int cell in piece.cells)
            {
                Vector3Int tilePosition = cell + piece.position;
                _tilemap.SetTile(tilePosition, piece.data.tile);
            }
        }

        public void ClearPiece(ActivePiece piece)
        {
            foreach (Vector3Int cell in piece.cells)
            {
                Vector3Int tilePosition = cell + piece.position;
                _tilemap.SetTile(tilePosition, null);
            }
        }

        public void SetGhost(ActivePiece piece, Vector3Int position)
        {
            foreach (Vector3Int cell in piece.cells)
            {
                Vector3Int tilePosition = cell + position;
                _ghostTilemap.SetTile(tilePosition, piece.data.tile);
            }
        }

        public void ClearGhost()
        {
            int count = 0;
            Vector3Int pos;
            for(int i = _bounds.xMin; i< _bounds.xMax; ++i)
            {
                for(int j = _bounds.yMin; j < _bounds.yMax; ++j)
                {
                    pos = new Vector3Int(i, j, 0);
                    if (_ghostTilemap.HasTile(pos))
                    {
                        _ghostTilemap.SetTile(pos, null);
                        if (count == 3) return;
                        ++count;
                    }
                }
            }
        }

        private void LineClear(int row)
        {
            for(int i = _bounds.xMin; i< _bounds.xMax; i++)
            {
                _tilemap.SetTile(new Vector3Int(i, row, 0), null);
            }
        }

        private void UpdateLines(SortedSet<int> lines)
        {
            int extra = 1;
            int newrow;
            for(int row = lines.First(); row < _bounds.yMax; row++)
            {
                newrow = row + extra;
                while (lines.Contains(newrow))
                {
                    extra++;
                    newrow++;
                }
                if(newrow < _bounds.yMax)
                {
                    for(int col = _bounds.xMin; col< _bounds.xMax; col++)
                    {
                        _tilemap.SetTile(new Vector3Int(col, row, 0), _tilemap.GetTile(new Vector3Int(col, newrow, 0)));
                    }
                }
                else
                {
                    for (int col = _bounds.xMin; col < _bounds.xMax; col++)
                    {
                        _tilemap.SetTile(new Vector3Int(col, row, 0), null);
                    }
                }
            }
        }

        private bool IsLineFull(int row)
        {
            for (int i = _bounds.xMin; i < _bounds.xMax; i++)
            {
                if (!_tilemap.HasTile(new Vector3Int(i, row, 0)))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
