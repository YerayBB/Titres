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

        [SerializeField]
        private float _stepDelay = 1f;
        [SerializeField]
        private float _lockDelay = 0.5f;

        private int _rotationIndex;
        private Controls _inputs;
        private Vector3Int _ghostPosition = new Vector3Int();

        private float _stepTime;
        private float _lockTime;

       

        #region MonoBehaviorCalls

        private void Awake()
        {
            _inputs = new Controls();
            _inputs.PieceActions.Enable();
            _inputs.PieceActions.Movement.performed += InputMove;
            _inputs.PieceActions.Drop.performed += FullDrop;
            _inputs.PieceActions.Rotate.performed += InputRotate;
            
        }

        private void Start()
        {
            Board.Instance.OnGameOver += () => _inputs.PieceActions.Disable();
        }

        void Update()
        {
            Board.Instance.ClearPiece(this);
            _lockTime += Time.deltaTime;

            if (Time.time >= _stepTime)
            {
                Step();
            }

            Board.Instance.SetPiece(this);
        }

        #endregion

        #region InputHandling

        private void InputRotate(InputAction.CallbackContext context)
        {
            Board.Instance.ClearPiece(this);
            if (Rotate((int)context.ReadValue<float>()))
            {
                UpdateGhost();
            }
            Board.Instance.SetPiece(this);
        }

        private void InputMove(InputAction.CallbackContext context)
        {
            Board.Instance.ClearPiece(this);
            Vector2Int value = Vector2Int.RoundToInt(context.ReadValue<Vector2>());
            if (Move(value))
            {
                if (value.x != 0) UpdateGhost();
            }
            Board.Instance.SetPiece(this);
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

        #endregion

        public void Initialize(Vector3Int position, PieceData data)
        {
            this.data = data;
            this.position = position;
            _rotationIndex = 0;
            _stepTime = Time.time + _stepDelay;
            _lockTime = 0;

            cells = new Vector3Int[data.cells.Length];

            for (int i = 0; i < data.cells.Length; i++)
            {
                cells[i] = (Vector3Int)data.cells[i];
            }
            UpdateGhost();
        }

        private bool Move(Vector2Int translation)
        {
            Vector3Int newPos = position;
            newPos.x += translation.x;
            newPos.y += translation.y;

            if (Board.Instance.IsValidPosition(this, newPos))
            {
                position = newPos;
                _lockTime = 0;
                return true;
            }
            return false;
        }

        private bool Rotate(int dir)
        {
            int originalRotaionIndex = _rotationIndex;

            _rotationIndex += dir;
            if (_rotationIndex < 0) _rotationIndex += 4;
            _rotationIndex = _rotationIndex % 4;

            ApplyRotationMatrix(dir);

            if (!TestWallKicks(originalRotaionIndex, dir))
            {
                _rotationIndex = originalRotaionIndex;
                ApplyRotationMatrix(dir * -1);
                return false;
            }

            return true;
        }

        private void Step()
        {
            _stepTime = Time.time + _stepDelay;

            Move(Vector2Int.down);

            if (_lockTime >= _lockDelay)
            {
                LockPiece();
            }
        }

        private void LockPiece()
        {
            Board.Instance.SetPiece(this);

            SortedSet<int> lines = new SortedSet<int>();
            foreach (var cell in cells)
            {
                lines.Add(cell.y + position.y);
            }
            Board.Instance.CheckLines(lines);

            Board.Instance.SpawnPiece();
        }


        private void UpdateGhost()
        {
            Board.Instance.ClearGhost();
            _ghostPosition = position;
            while (Board.Instance.IsValidPosition(this, _ghostPosition))
            {
                _ghostPosition += Vector3Int.down;
            }
            Board.Instance.SetGhost(this, _ghostPosition + Vector3Int.up);
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
