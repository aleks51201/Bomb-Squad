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


        public bool IsPlayerAuth => IsPlayerAuthorized() == 1;


        /*        [DllImport("__Internal")]
                private static extern void SetLeaderBoardScore(int score);
        *//*        [DllImport("__Internal")]
                private static extern int GetLeaderBoardScore();
        */
/*        [DllImport("__Internal")]
        private static extern int IsPlayerAuthorized();
*/        [DllImport("__Internal")]
        private static extern void AuthPlayer();


        private void SetLeaderBoardScore(int score) { }
        private int GetLeaderBoardScore() { return 0; }
        private int IsPlayerAuthorized() { return 0; }
        //private int AuthPlayer() { return 0; }

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
            _currentCoroutine = StartCoroutine(Authorization());
        }

        private IEnumerator Authorization()
        {
            yield return new WaitUntil(() => AuthPlayer() == 0 ? true : false);
            if (IsPlayerAuth)
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
            _btn.ButtonClickedEvent += OnAuthButtonClick;
        }

        private void OnDisable()
        {
            CellView.GameWinEvent -= OnWin;
            _btn.ButtonClickedEvent -= OnAuthButtonClick;
        }
    }
}
