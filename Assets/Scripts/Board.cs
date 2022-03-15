using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Titres
{
    public class Board : MonoBehaviour
    {
        public Tilemap tilemap { get; private set; }
        public PieceData[] pieces;

        private void Awake()
        {
            tilemap = transform.GetChild(0).GetComponent<Tilemap>();

            foreach(var piece in pieces)
            {
                piece.Initialize();
            }
        }
        
        // Start is called before the first frame update
        void Start()
        {

        }

        public void SpawnPiece()
        {
            int random = Random.Range(0, pieces.Length);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
