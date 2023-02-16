using TMPro;
using UnityEngine;

namespace BombSquad
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
            panel.GetComponentInChildren<TextMeshProUGUI>().text = loseText + $"\n{score.Score}";
        }

        private void ActivateWinPanel()
        {
            panel.SetActive(true);
            panel.GetComponentInChildren<TextMeshProUGUI>().text = winText + $"\n{score.Score}";
        }

        private void Start()
        {
            score = new();
            score.Init();
        }

        private void OnEnable()
        {
            CellView.GameLosedEvent += ActivateLosePanel;
            CellView.GameWonEvent += ActivateWinPanel;
        }

        private void OnDisable()
        {
            CellView.GameLosedEvent -= ActivateLosePanel;
            CellView.GameWonEvent -= ActivateWinPanel;
        }
    }
}
