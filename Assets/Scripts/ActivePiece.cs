using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Titres
{
    public class ActivePiece : MonoBehaviour
    {
        public Board board { get; private set; }
        public PieceData data { get; private set; }
        public Vector3Int position { get; private set; }
        public Vector3Int[] cells { get; private set; }

        public void Initialize(Board board, Vector3Int position, PieceData data)
        {
            this.board = board;
            this.data = data;
            this.position = position;

            cells = new Vector3Int[data.cells.Length];

            for(int i = 0; i<data.cells.Length; i++)
            {
                cells[i] = (Vector3Int) data.cells[i];
            }
        }    

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            board.ClearPiece(this);

            if (Input.GetKeyDown(KeyCode.A))
            {
                Move(Vector2Int.left);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Move(Vector2Int.right);
            }


            board.SetPiece(this);
        }

        private bool Move(Vector2Int direcion)
        {
            Vector3Int newPos = position;
            newPos.x += direcion.x;
            newPos.y += direcion.y;

            if(board.IsValidPosition(this, newPos))
            {
                position = newPos;
                return true;
            }
            return false;
        }
        
    }
}
