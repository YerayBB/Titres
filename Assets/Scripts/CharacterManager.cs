using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Titres
{
    public class CharacterManager : MonoBehaviour
    {
        [SerializeField]
        private Vector2 _spawnArea = new Vector2(7, 15);

        [SerializeField]
        private GameObject[] _characters;

        private List<Character> _activeCharacters;

        private int _nextSpawn = 1;
        private int _lastSpawn = 1;
        private int _remaining;

        private void Awake()
        {
            _activeCharacters = new List<Character>();
            _remaining = _nextSpawn + _lastSpawn;
        }

        // Start is called before the first frame update
        void Start()
        {
            Board.Instance.OnLineFull += React;
            SpawnCharacter();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void React(int combo)
        {
            switch (combo)
            {
                case 4:
                    if (_remaining == 1)
                    {
                        for(int i = 0; i < Mathf.Min(_nextSpawn, 3); ++i) SpawnCharacter();
                        UpdateSpawnTimer();
                    }
                    else
                    {
                        --_remaining;
                    }
                    break;
                case 3:
                    foreach(Character character in _activeCharacters)
                    {
                        character.Jump(5);
                        character.Move();
                    }
                    break;
                case 2:
                    foreach (Character character in _activeCharacters)
                    {
                        character.Move(Random.Range(-5, 5)*2);
                    }
                    break;
                case 1:
                    if (_activeCharacters.Count > 0)
                    {
                        Character cha = _activeCharacters[Random.Range(0, _activeCharacters.Count)];
                        if (Random.Range(0, 2) == 0)
                        {
                            cha.Move();
                        }
                        else
                        {
                            cha.Jump();
                        }
                    }
                    break;
                default:
                    break;
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
            GameObject go;
            if (Random.Range(0, 2) == 0)
            {
                go = Instantiate(_characters[Random.Range(0, _characters.Length)], new Vector3(Random.Range(_spawnArea.x, _spawnArea.y), Random.Range(3f, 12f)), Quaternion.identity, transform);
            }
            else
            {
                go = Instantiate(_characters[Random.Range(0, _characters.Length)], new Vector3(Random.Range(-_spawnArea.y, -_spawnArea.x), Random.Range(3f, 12f)), Quaternion.identity, transform);
            }

            Character character = go.GetComponent<Character>();
            character.OnDeath += (a) => _activeCharacters.Remove(a);
            _activeCharacters.Add(character);
        }

    }
}
