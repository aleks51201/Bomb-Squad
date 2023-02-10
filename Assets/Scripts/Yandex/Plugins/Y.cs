using System.Runtime.InteropServices;
using UnityEngine;

namespace Scripts.Yandex
{
    public class Y : MonoBehaviour
    {

        [DllImport("__Internal")]
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
