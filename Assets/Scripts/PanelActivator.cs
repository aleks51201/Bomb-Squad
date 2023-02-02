using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class PanelActivator : MonoBehaviour
    {
        [SerializeField] private GameObject panel;
        [SerializeField] private string loseText;
        [SerializeField] private string winText;

        private ScoreHolder score;


        private void ActivateLosePanel()
        {
            panel.SetActive(true);
            panel.GetComponentInChildren<TextMeshProUGUI>().text = loseText + $"/n{score.Score}";
        }

        private void ActivateWinPanel()
        {
            panel.SetActive(true);
            panel.GetComponentInChildren<TextMeshProUGUI>().text = winText + $"/n{score.Score}";
        }

        private void Start()
        {
            score = new();
        }

        private void OnEnable()
        {
            CellView.GameLosedEvent += ActivateLosePanel;
            CellView.GameWinEvent += ActivateWinPanel;
        }

        private void OnDisable()
        {
            CellView.GameLosedEvent -= ActivateLosePanel;
            CellView.GameWinEvent -= ActivateWinPanel;
        }
    }
}
