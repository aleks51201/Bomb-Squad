using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Restarter:MonoBehaviour
    {
        [SerializeField] private Sprite defaultCellSprite;
        [SerializeField] private GameObject losePanel;

        private CellView[] _cells;


        private CellView[] Cells
        {
            get
            {
                if(_cells is null)
                {
                    _cells = GetCells();
                }
                return _cells;
            }
        }


        private void UpdateCells()
        {
            CellView.NumRightClick = 5;
            CellView.Bomb = 0;
            foreach(CellView cell in Cells)
            {
                cell.GetComponent<Image>().color = Color.white;
                cell.GetComponent<Image>().sprite = defaultCellSprite;
                cell.GetComponentInChildren<TextMeshProUGUI>().text = "";
            }
        }

        private CellView[] GetCells()
        {
            return GetComponentsInChildren<CellView>();
        }

        private void Update()
        {
            if (!Input.GetKey(KeyCode.Space))
            {
                return;
            }
            UpdateCells();
            losePanel.SetActive(false);
        }
    }
}
