using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Restarter:MonoBehaviour
    {
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

        }
    }
}
