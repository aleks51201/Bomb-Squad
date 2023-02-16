using System;
using UnityEngine;

namespace BombSquad
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
