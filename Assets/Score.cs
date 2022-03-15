using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Titres {
    public class Score : MonoBehaviour
    {
        private int score;
        private TMP_Text text;

        [SerializeField]
        private int pointsGained = 1;

        private void Awake()
        {
            text = GetComponent<TMP_Text>();
            score = 0;
            text.text = score.ToString();
        }

        private void Start()
        {
            Board.Instance.OnLineFull += ScoreUp;
        }

        private void ScoreUp(int combo)
        {
            score += pointsGained * combo * combo;
            text.text = score.ToString();
        }
    }
}
