using BombSquad;
using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Yandex
{
    public class ScoreSaver : MonoBehaviour
    {
        [SerializeField] private Btn _btn;
        private ScoreHolder _score;


        public bool IsPlayerAuth
        {
            get
            {
                ConsoleLog($"IsPlayerAuthorized: {IsPlayerAuthorized() == 1}");
                return IsPlayerAuthorized() == 1;
            }
        }


        public Action AuthorizedEvent;


        [DllImport("__Internal")]
        private static extern void SetLeaderBoardScore(int score);
        [DllImport("__Internal")]
        private static extern int GetLeaderBoardScore();

        [DllImport("__Internal")]
        private static extern int IsPlayerAuthorized();
        [DllImport("__Internal")]
        private static extern int AuthPlayer();
        [DllImport("__Internal")]
        private static extern void ConsoleLog(string str);
        [DllImport("__Internal")]
        private static extern void Hello();


        private void OnWin()
        {
            if (!IsPlayerAuth)
            {
                return;
            }
            StartCoroutine(SaveScore());
        }

        private void OnAuthButtonClick()
        {
            StartCoroutine(Authorization());
        }

        private IEnumerator Authorization()
        {
            AuthPlayer();
            while (!IsPlayerAuth)
            {
                yield return null;
            }
            AuthorizedEvent?.Invoke();
            StartCoroutine(SaveScore());
        }

        private IEnumerator SaveScore()
        {
            int score = GetLeaderBoardScore();
            yield return null;
            if (0 == score || score > _score.Score)
            {
                SetLeaderBoardScore(_score.Score);
            }
            yield return null;
        }

        private void Awake()
        {
            _score = new();
            _score.Init();
        }

        private void OnEnable()
        {
            CellView.GameWonEvent += OnWin;
            _btn.ButtonClickedEvent += OnAuthButtonClick;
        }

        private void OnDisable()
        {
            CellView.GameWonEvent -= OnWin;
            _btn.ButtonClickedEvent -= OnAuthButtonClick;
        }
    }
}
