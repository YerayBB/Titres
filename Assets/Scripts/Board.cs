using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Titres
{
    public class Board : MonoBehaviour
    {
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


        private void Awake()
        {
            tilemap = GetComponentInChildren<Tilemap>();
            piece = GetComponentInChildren<ActivePiece>();

            for(int i = 0; i<pieces.Length; i++)
            {
                pieces[i].Initialize();
            }

            SpawnPiece();
        }
        
        // Start is called before the first frame update
        void Start()
        {

        }

        public void SpawnPiece()
        {
            int random = Random.Range(0, pieces.Length);
            PieceData pieceData = pieces[random];

            this.piece.Initialize(this, _spawnPosition, pieceData);

            SetPiece(this.piece);
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

        // Update is called once per frame
        void Update()
        {

        }
    }
}
