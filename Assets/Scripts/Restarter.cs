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
