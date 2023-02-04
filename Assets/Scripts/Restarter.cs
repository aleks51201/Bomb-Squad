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


        public static Action GameRestartedEvent;


        private void UpdateCells()
        {
            CellView.NumRightClick = 5;
            CellView.Bomb = 0;
            int[] distances = ChangeDataFormat();
            for(int i=0; i< Cells.Length;i++)
            {
                CellView cell = Cells[i];
                cell.GetComponent<Image>().color = Color.white;
                cell.GetComponent<Image>().sprite = cell.DefaultSprite;
                cell.GetComponentInChildren<TextMeshProUGUI>().text = "";
                cell.DistanceValue = distances[i];
                cell.IsClicked = false;
                cell.IsMarked = false;
            }
            GameRestartedEvent?.Invoke();
        }

        private int[] ChangeDataFormat()
        {
            DataHolder data = new();
            data.Init();
            List<int> result = new();
            foreach(int i in data.DistanceValueArr)
            {
                result.Add(i);
            }
            return result.ToArray();
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
