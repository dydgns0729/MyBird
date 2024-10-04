using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyBird
{
    public class GameManager : MonoBehaviour
    {
        #region Variables
        public static bool IsStart { get; set; }
        public static bool IsDeath { get; set; }
        public static int Score { get; set; }
        public static int BestScore { get; set; }

        //게임UI
        public TextMeshProUGUI scoreText;
        #endregion

        private void Start()
        {
            //초기화
            IsStart = false;
            IsDeath = false;
            Score = 0;
        }
        private void Update()
        {
            scoreText.text = Score.ToString();
        }
    }
}