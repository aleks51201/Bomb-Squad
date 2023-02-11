using Assets.Scripts;
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


        [DllImport("__Internal")]
        private static extern void SetLeaderBoardScore(int score);
        [DllImport("__Internal")]
        private static extern int GetLeaderBoardScore();
        [DllImport("__Internal")]
        private static extern int IsPlayerAuthorized();
        [DllImport("__Internal")]
        private static extern int AuthPlayer();


        private void OnWin()
        {
            if (IsPlayerAuthorized() == 0)
            {
                return;
            }
            StartCoroutine(SaveScore());
        }

        private void OnAuthButtonClick()
        {
            _currentCoroutine = StartCoroutine(Authorization());
        }

        private IEnumerator Authorization()
        {
            yield return new WaitUntil(() => AuthPlayer() == 0 ? true : false);
            if (IsPlayerAuthorized() == 1)
            {
                StartCoroutine(SaveScore());
            }
        }

        private IEnumerator SaveScore()
        {
            int score = GetLeaderBoardScore();
            yield return null;
            if(score < _score.Score)
            {
                SetLeaderBoardScore(_score.Score);
            }
            yield return null;
        }

        private void Awake()
        {
            _score = new();
        }

        private void OnEnable()
        {
            CellView.GameWinEvent += OnWin;
            // Нажатие на копку авторизации += OnAuthButtonClidk();
        }

        private void OnDisable()
        {
            CellView.GameWinEvent -= OnWin;
        }
    }
}
