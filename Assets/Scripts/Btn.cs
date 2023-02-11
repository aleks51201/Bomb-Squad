using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class Btn : MonoBehaviour
    {
        public Action ButtonClickedEvent;


        private void OnClick()
        {
            ButtonClickedEvent?.Invoke();
        }
    }
}
