using Scripts.Yandex;
using UnityEngine;

namespace Assets.Scripts
{
    public class ButtonUpdater:MonoBehaviour
    {
        [SerializeField] private ScoreSaver _scoreSaver;
        [SerializeField] private Btn _btn;


        private void OnEnable()
        {
            if (_scoreSaver.IsPlayerAuth)
            {
                _btn.gameObject.SetActive(false);
                return;
            }
            _btn.gameObject.SetActive(true);
            
        }
    }
}
