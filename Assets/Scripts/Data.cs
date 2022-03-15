using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Titres
{
    public static class Data
    {


        public static readonly Dictionary<Piece, Vector2Int[]> Cells = new Dictionary<Piece, Vector2Int[]>()
        {
            {Piece.I, new Vector2Int[] {new Vector2Int(-1,1), Vector2Int.up, Vector2Int.one, new Vector2Int(2, 1) } },
            {Piece.O, new Vector2Int[] {Vector2Int.one, Vector2Int.right, Vector2Int.up, Vector2Int.zero } },
            {Piece.J, new Vector2Int[] {new Vector2Int(-1,1), Vector2Int.left, Vector2Int.zero, Vector2Int.right } },
            {Piece.L, new Vector2Int[] { Vector2Int.one, Vector2Int.left, Vector2Int.zero, Vector2Int.right } },
            {Piece.Z, new Vector2Int[] {new Vector2Int(-1,1), Vector2Int.up, Vector2Int.zero, Vector2Int.right } },
            {Piece.S, new Vector2Int[] {Vector2Int.up, Vector2Int.one, Vector2Int.zero, Vector2Int.left } },
            {Piece.T, new Vector2Int[] {Vector2Int.left,  Vector2Int.zero,  Vector2Int.right,  Vector2Int.up } },
        };
    }
}
