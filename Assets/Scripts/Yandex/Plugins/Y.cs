using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Scripts.Yandex
{
    public class Y : MonoBehaviour
    {
        [DllImport("_Internal")] 
        private static extern void Hello();

        public void OnClick()
        {
            Init();
        }

        private void Init()
        {
            Hello();
        }
    }
}
