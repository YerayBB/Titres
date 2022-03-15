using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Titres
{
    public enum Piece 
    {
        I,
        L,
        J,
        O,
        T,
        Z,
        S,
    }

    [System.Serializable]
    public struct PieceData
    {
        public Piece piece;
        public Tile tile;
        public Vector2Int[] cells;
        
        public void Initialize()
        {
            this.cells = Data.Cells[piece];
        }
    }
}
