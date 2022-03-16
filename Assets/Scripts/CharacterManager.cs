using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Titres
{
    public class CharacterManager : MonoBehaviour
    {
        [SerializeField]
        private int _maxStep = 10;

        [SerializeField]
        private GameObject[] _characters;

        private List<Character> _activeCharacters;

        private int _nextSpawn = 1;
        private int _lastSpawn = 0;
        private int _remaining;

        private void Awake()
        {
            _remaining = _nextSpawn + _lastSpawn;
        }

        // Start is called before the first frame update
        void Start()
        {
            Board.Instance.OnLineFull += React;
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void React(int combo)
        {
            if(combo == 4)
            {
                if(_remaining == 1)
                {
                    SpawnCharacter();
                    UpdateSpawnTimer();
                }
                else
                {
                    --_remaining;
                }
            }



        }

        private void UpdateSpawnTimer()
        {
            _remaining = _lastSpawn + _nextSpawn;
            _lastSpawn = _nextSpawn;
            _nextSpawn = _remaining;
        }

        private void SpawnCharacter()
        {
            Instantiate(_characters[Random.Range(0, _characters.Length)], transform);
        }
    }
}
