using Assets.Scripts;
using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Scripts.Yandex
{
    public class ScoreSaver : MonoBehaviour
    {
        [SerializeField] private Btn _btn;
        private ScoreHolder _score;
        private Coroutine _currentCoroutine;


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


/*        //private void SetLeaderBoardScore(int score) { }
        private int GetLeaderBoardScore() { return 0; }
        private int IsPlayerAuthorized() { return 0; }
        private int AuthPlayer() { return 0; }
*/
        private void OnWin()
        {
            ConsoleLog("OnWin");
            if (!IsPlayerAuth)
            {
                ConsoleLog("OnWin: player is not auth");
                return;
            }
            ConsoleLog("OnWin: start coroutine SaveScore");
            StartCoroutine(SaveScore());
            ConsoleLog("OnWin: end coroutine SaveScore");
        }

        private void OnAuthButtonClick()
        {
            ConsoleLog($"OnAuthButtonClick");
            ConsoleLog($"OnAuthButtonClick: start coroutine Authorization");
            _currentCoroutine = StartCoroutine(Authorization());
            ConsoleLog($"OnAuthButtonClick: end coroutine Authorization");
        }

        private IEnumerator Authorization()
        {
            ConsoleLog($"Authorization: start AuthPlayer");
            yield return new WaitUntil(() => AuthPlayer() == 0 ? true : false);
            ConsoleLog($"Authorization: end AuthPlayer");
            AuthorizedEvent?.Invoke();
            if (IsPlayerAuth)
            {
                ConsoleLog($"Authorization: if (IsPlayerAuth): start coroutine SaveScore");
                StartCoroutine(SaveScore());
                ConsoleLog($"Authorization: if (IsPlayerAuth): end coroutine SaveScore");
            }
        }

        private IEnumerator SaveScore()
        {
            ConsoleLog("SaveScore: start GetLeaderBoardScore");
            int score = GetLeaderBoardScore();
            ConsoleLog($"SaveScore: end GetLeaderBoardScore int score = {score}");
            yield return null;
            ConsoleLog($"SaveScore: score = {score} < _score.Score = {_score.Score}: start");
            if (score < _score.Score)
            {
                ConsoleLog($"SaveScore: score = {score} < _score.Score = {_score.Score}: start SetLeaderBoardScore");
                SetLeaderBoardScore(_score.Score);
                ConsoleLog($"SaveScore: score = {score} < _score.Score = {_score.Score}: end SetLeaderBoardScore");
            }
            ConsoleLog($"SaveScore: score = {score} < _score.Score = {_score.Score}: end");
            yield return null;
        }

        private void Awake()
        {
            _score = new();
            _score.Init();
        }

        private void OnEnable()
        {
            CellView.GameWinEvent += OnWin;
            _btn.ButtonClickedEvent += OnAuthButtonClick;
        }

        private void OnDisable()
        {
            CellView.GameWinEvent -= OnWin;
            _btn.ButtonClickedEvent -= OnAuthButtonClick;
        }
    }
}
