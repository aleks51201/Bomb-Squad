using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class PanelActivator:MonoBehaviour
    {
        [SerializeField] private GameObject panel;
        [SerializeField] private string loseText;
        [SerializeField] private string winText;


        private void ActivateLosePanel()
        {
            panel.SetActive(true);
            panel.GetComponentInChildren<TextMeshProUGUI>().text = loseText;
        }

        private void OnEnable()
        {
            CellView.GameLosedEvent += ActivateLosePanel;
        }

        private void OnDisable()
        {
            CellView.GameLosedEvent -= ActivateLosePanel;
        }
    }
}
