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
            _activeCharacters = new List<Character>();
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
            Debug.Log($"Called with {combo}");
            switch (combo)
            {
                case 4:
                    if (_remaining == 1)
                    {
                        SpawnCharacter();
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
                        character.Jump(Random.Range(0,5)*10);
                    }
                    break;
                case 2:
                    foreach (Character character in _activeCharacters)
                    {
                        Debug.Log("?? 2");
                        character.Move(Random.Range(-5, 5)*10);
                    }
                    break;
                case 1:
                    if (_activeCharacters.Count > 0)
                    {
                        Character cha = _activeCharacters[Random.Range(0, _activeCharacters.Count)];
                        if (Random.Range(0, 2) == 0)
                        {
                            cha.Move(Random.Range(-2, 2)*10);
                            Debug.Log($"{cha.name} asked to move");
                        }
                        else
                        {
                            cha.Jump(Random.Range(1, 3)*10);
                            Debug.Log($"{cha.name} asked to jump");
                        }
                    }
                    break;
                default:
                    Debug.Log("Error?");
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
            GameObject go = Instantiate(_characters[Random.Range(0, _characters.Length)], new Vector3(Random.Range((float)-_maxStep, (float)_maxStep), Random.Range(3f,12f)),Quaternion.identity, transform);
            Character character = go.GetComponent<Character>();
            character.OnDeath += (a) => _activeCharacters.Remove(a);
            _activeCharacters.Add(character);
        }

    }
}
