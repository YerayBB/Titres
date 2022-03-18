using UnityEngine;
using TMPro;

namespace Titres {
    public class Score : MonoBehaviour
    {
        [SerializeField]
        private int _pointsGained = 10;

        private int _score;
        private TMP_Text _text;



        #region MonoBehaviorCalls

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
            _score = 0;
            _text.text = _score.ToString();
        }

        private void Start()
        {
            Board.Instance.OnLineFull += ScoreUp;
            Board.Instance.OnFullDrop += ScoreOnDrop;
        }

        #endregion

        private void ScoreUp(int combo)
        {
            _score += _pointsGained * combo * combo;
            _text.text = _score.ToString();
        }

        private void ScoreOnDrop(int rows)
        {
            if(rows > 10)
            {
                ++_score;
                _text.text = _score.ToString();
            }
        }
    }
}
