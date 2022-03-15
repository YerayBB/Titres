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
        public int rotationIndex { get; private set; }

        public void Initialize(Board board, Vector3Int position, PieceData data)
        {
            this.board = board;
            this.data = data;
            this.position = position;
            rotationIndex = 0;

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

            if (Input.GetKeyDown(KeyCode.Q))
            {
                Rotate(-1);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                Rotate(1);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                Move(Vector2Int.left);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Move(Vector2Int.right);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                Move(Vector2Int.down);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                FullDrop();
            }



            board.SetPiece(this);
        }

        private void FullDrop()
        {
            while (Move(Vector2Int.down))
            {
                continue;
            }
        }

        private bool Move(Vector2Int translation)
        {
            Vector3Int newPos = position;
            newPos.x += translation.x;
            newPos.y += translation.y;

            if(board.IsValidPosition(this, newPos))
            {
                position = newPos;
                return true;
            }
            return false;
        }
        
        private bool Rotate(int dir)
        {
            int originalRotaionIndex = rotationIndex;

            rotationIndex += dir;
            if (rotationIndex < 0) rotationIndex += 4;
            rotationIndex = rotationIndex % 4;

            ApplyRotationMatrix(dir);

            if(!TestWallKicks(originalRotaionIndex, dir))
            {
                rotationIndex = originalRotaionIndex;
                ApplyRotationMatrix(dir * -1);
            }

            return false;
        }

        private void ApplyRotationMatrix(int dir)
        {
            for (int i = 0; i < cells.Length; i++)
            {
                Vector3 cell = cells[i];

                int x, y;

                if (data.piece == Piece.I || data.piece == Piece.O)
                {
                    cell.x -= 0.5f;
                    cell.y -= 0.5f;
                    x = Mathf.CeilToInt(Data.rotationMatrix[0] * cell.x * dir + Data.rotationMatrix[1] * cell.y * dir);
                    y = Mathf.CeilToInt(Data.rotationMatrix[2] * cell.x * dir + Data.rotationMatrix[3] * cell.y * dir);
                }
                else
                {
                    x = Mathf.RoundToInt(Data.rotationMatrix[0] * cell.x * dir + Data.rotationMatrix[1] * cell.y * dir);
                    y = Mathf.RoundToInt(Data.rotationMatrix[2] * cell.x * dir + Data.rotationMatrix[3] * cell.y * dir);
                }

                cells[i] = new Vector3Int(x, y, 0);
            }
        }

        private bool TestWallKicks(int rotationIndex, int dir)
        {
            int index = rotationIndex * 2 + (dir < 0 ? -1 : 0);
            if (index < 0) index += data.wallKicks.GetLength(0);
            index = index % data.wallKicks.GetLength(0);

            for (int i = 0; i < data.wallKicks.GetLength(1); i++)
            {
                if (Move(data.wallKicks[index, i])){
                    return true;
                }
            }

            return false;
        }

    }
}
