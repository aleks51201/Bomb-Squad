using BombSquad;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Yandex
{
    public class DeviceChecker:MonoBehaviour
    {
        [DllImport("__Internal")]
        private static extern int IsDesktop();


        private void Awake()
        {
            if (IsDesktop() == 1)
            {
                ControlSystem.IsMobile = false;
            }
            else
            {
                ControlSystem.IsMobile = true;
            }
        }
    }
}
