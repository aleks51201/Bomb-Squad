using Scripts.Yandex;
using UnityEngine;

namespace BombSquad
{
    public class ButtonUpdater:MonoBehaviour
    {
        [SerializeField] private ScoreSaver _scoreSaver;
        [SerializeField] private GameObject _btn;


        private void UpdateButtonStatus()
        {
            if (!CellView.IsWin || _scoreSaver.IsPlayerAuth)
            {
                _btn.SetActive(false);
                return;
            }
            _btn.SetActive(true);
        }

        private void OnEnable()
        {
            _scoreSaver.AuthorizedEvent += UpdateButtonStatus;
            UpdateButtonStatus();
        }

        private void OnDisable()
        {
            _scoreSaver.AuthorizedEvent -= UpdateButtonStatus;
        }
    }
}
