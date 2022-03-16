using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Titres
{
    public class ActivePiece : MonoBehaviour
    {
        public PieceData data { get; private set; }
        public Vector3Int position { get; private set; }
        public Vector3Int[] cells { get; private set; }
        public int rotationIndex { get; private set; }
        private Controls _inputs;

        public float stepDelay = 1f;
        public float lockDelay = 0.5f;


        private float _stepTime;
        private float _lockTime;

        public void Initialize(Vector3Int position, PieceData data)
        {
            this.data = data;
            this.position = position;
            rotationIndex = 0;
            _stepTime = Time.time + stepDelay;
            _lockTime = 0;

            cells = new Vector3Int[data.cells.Length];

            for(int i = 0; i<data.cells.Length; i++)
            {
                cells[i] = (Vector3Int) data.cells[i];
            }
        }

        private void Awake()
        {
            _inputs = new Controls();
            _inputs.PieceActions.Enable();
            _inputs.PieceActions.Movement.performed += InputMove;
            _inputs.PieceActions.Drop.performed += FullDrop;
            _inputs.PieceActions.Rotate.performed += InputRotate;
        }

        private void InputRotate(InputAction.CallbackContext context)
        {
            Board.Instance.ClearPiece(this);
            Rotate((int)context.ReadValue<float>());
            Board.Instance.SetPiece(this);
        }

        private void InputMove(InputAction.CallbackContext context)
        {
            Board.Instance.ClearPiece(this);
            Move(Vector2Int.RoundToInt(context.ReadValue<Vector2>()));
            Board.Instance.SetPiece(this);
        }

        // Update is called once per frame
        void Update()
        {
            Board.Instance.ClearPiece(this);
            _lockTime += Time.deltaTime;

            if(Time.time >= _stepTime)
            {
                Step();
            }

            Board.Instance.SetPiece(this);
        }

        private void Step()
        {
            _stepTime = Time.time + stepDelay;

            Move(Vector2Int.down);

            if(_lockTime >= lockDelay)
            {
                LockPiece();
            }
        }

        private void LockPiece()
        {
            Board.Instance.SetPiece(this);

            SortedSet<int> lines = new SortedSet<int>();
            foreach(var cell in cells)
            {
                lines.Add(cell.y + position.y);
            }
            Board.Instance.CheckLines(lines);

            Board.Instance.SpawnPiece();
        }

        private void FullDrop(InputAction.CallbackContext obj)
        {
            Board.Instance.ClearPiece(this);
            int rows = 0;
            while (Move(Vector2Int.down))
            {
                ++rows;
                continue;
            }
            Board.Instance.OnFullDrop?.Invoke(rows);
            LockPiece();
        }

        private bool Move(Vector2Int translation)
        {
            Vector3Int newPos = position;
            newPos.x += translation.x;
            newPos.y += translation.y;

            if(Board.Instance.IsValidPosition(this, newPos))
            {
                position = newPos;
                _lockTime = 0;
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
                return false;
            }

            return true;
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
