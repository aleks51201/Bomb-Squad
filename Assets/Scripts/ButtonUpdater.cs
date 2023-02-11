using Scripts.Yandex;
using UnityEngine;

namespace Assets.Scripts
{
    public class ButtonUpdater:MonoBehaviour
    {
        [SerializeField] private ScoreSaver _scoreSaver;
        [SerializeField] private GameObject _btn;


        private void OnEnable()
        {
            if (_scoreSaver.IsPlayerAuth)
            {
                _btn.SetActive(false);
                return;
            }
            _btn.SetActive(true);
            
        }
    }
}
