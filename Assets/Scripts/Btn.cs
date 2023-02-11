using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class Btn : MonoBehaviour
    {
        public Action ButtonClickedEvent;


        public void OnClick()
        {
            ButtonClickedEvent?.Invoke();
        }
    }
}
