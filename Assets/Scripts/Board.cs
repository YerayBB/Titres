using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Titres
{
    public class Board : MonoBehaviour
    {
        public static Board Instance { get; private set; }

        public Tilemap tilemap { get; private set; }
        public ActivePiece piece { get; private set; }
        [SerializeField]
        private Vector3Int _spawnPosition = Vector3Int.zero;
        [SerializeField]
        private Vector2Int _boardSize = new Vector2Int(10,20);
        public RectInt bounds
        {
            get
            {
                return new RectInt(new Vector2Int(-_boardSize.x / 2, -_boardSize.y / 2), _boardSize);
            }
        }

        public PieceData[] pieces;
        private PieceData nextPiece;
        [SerializeField]
        private Vector3Int _previewCenter = new Vector3Int(11, 7, 0);
        private RectInt _previewBounds = new RectInt(-1, -3, 4, 4);

        public event System.Action<int> OnLineFull;


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
            tilemap = GetComponentInChildren<Tilemap>();
            piece = GetComponentInChildren<ActivePiece>();

            for(int i = 0; i<pieces.Length; i++)
            {
                pieces[i].Initialize();
            }

            PickPiece();
            SpawnPiece();
        }
        
        // Start is called before the first frame update
        void Start()
        {

        }

        private void PickPiece()
        {
            int random = Random.Range(0, pieces.Length);
            nextPiece = pieces[random];

            PrintNextPiece();
        }

        private void PrintNextPiece()
        {
            //clear preview
            for(int i = _previewBounds.xMin; i<= _previewBounds.xMax; i++)
            {
                for(int j= _previewBounds.yMin; j<=_previewBounds.yMax; j++)
                {
                    tilemap.SetTile(_previewCenter + new Vector3Int(i, j, 0), null);
                }
            }

            //print next
            foreach(Vector3Int cell in nextPiece.cells)
            {
                tilemap.SetTile(_previewCenter + cell, nextPiece.tile);
            }

        }

        public void SpawnPiece()
        {
            piece.Initialize(_spawnPosition, nextPiece);

            if (IsValidPosition(piece, _spawnPosition)) { 

                SetPiece(piece);
                PickPiece();
            }
            else
            {
                //gameover
                tilemap.ClearAllTiles();
            }
        }

        public void SetPiece(ActivePiece piece)
        {
            foreach (Vector3Int cell in piece.cells)
            {
                Vector3Int tilePosition = cell + piece.position;
                tilemap.SetTile(tilePosition, piece.data.tile);
            }
        }

        public void ClearPiece(ActivePiece piece)
        {
            foreach (Vector3Int cell in piece.cells)
            {
                Vector3Int tilePosition = cell + piece.position;
                tilemap.SetTile(tilePosition, null);
            }
        }

        public bool IsValidPosition(ActivePiece piece, Vector3Int pos)
        {
            RectInt rect = bounds;

            for(int i = 0; i<piece.cells.Length; i++)
            {
                Vector3Int tilePos = pos + piece.cells[i];

                if (!rect.Contains((Vector2Int)tilePos)) return false;

                if (tilemap.HasTile(tilePos)) return false;

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
                row = tilemap.WorldToCell(Vector3.up * line).y;
                fullLine = IsLineFull(row);
                if (fullLine)
                {
                    LineClear(row);
                    fullLines.Add(row);
                }
            }
            if(fullLines.Count > 0)
            {
                OnLineFull?.Invoke(fullLines.Count);
                UpdateLines(fullLines);
            }
        }

        private void LineClear(int row)
        {
            for(int i = bounds.xMin; i< bounds.xMax; i++)
            {
                tilemap.SetTile(new Vector3Int(i, row, 0), null);
            }
        }

        private void UpdateLines(SortedSet<int> lines)
        {
            int extra = 1;
            int newrow;
            for(int row = lines.First(); row < bounds.yMax; row++)
            {
                newrow = row + extra;
                while (lines.Contains(newrow))
                {
                    extra++;
                    newrow++;
                }
                if(newrow < bounds.yMax)
                {
                    for(int col = bounds.xMin; col< bounds.xMax; col++)
                    {
                        tilemap.SetTile(new Vector3Int(col, row, 0), tilemap.GetTile(new Vector3Int(col, newrow, 0)));
                    }
                }
                else
                {
                    for (int col = bounds.xMin; col < bounds.xMax; col++)
                    {
                        tilemap.SetTile(new Vector3Int(col, row, 0), null);
                    }
                }
            }
        }

        private bool IsLineFull(int row)
        {
            for (int i = bounds.xMin; i < bounds.xMax; i++)
            {
                if (!tilemap.HasTile(new Vector3Int(i, row, 0)))
                {
                    return false;
                }
            }
            return true;
        }


        // Update is called once per frame
        void Update()
        {

        }
    }
}
