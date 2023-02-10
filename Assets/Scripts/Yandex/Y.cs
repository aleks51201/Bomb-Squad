using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Scripts.Yandex
{
    public class Y: MonoBehaviour
    {
        [DllImport("_internal")] 
        private static extern void Hello();


        private void Start()
        {
            Hello();
        }
    }
}
