using UnityEngine;

namespace Assets.Scripts
{
    public class PanelActivator:MonoBehaviour
    {
        [SerializeField] GameObject panel;


        private void SetActive()
        {

        }

        private void OnEnable()
        {
            CellView.GameLosedEvent += SetActive;
        }

        private void OnDisable()
        {
            CellView.GameLosedEvent -= SetActive;
        }
    }
}
