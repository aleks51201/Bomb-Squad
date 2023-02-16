using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BombSquad
{
    public class ButtonWithClick : MonoBehaviour,IPointerClickHandler
    {
        public Action LeftButtonClickedEvent;
        public Action RightButtonClickedEvent;


        public void OnLeftClick()
        {
            LeftButtonClickedEvent?.Invoke();
        }

        public void OnRightClick()
        {
            RightButtonClickedEvent?.Invoke();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if(eventData.button == PointerEventData.InputButton.Left)
            {
                OnLeftClick();
            }
            else if(eventData.button == PointerEventData.InputButton.Right)
            {
                OnRightClick();
            }
        }

        private void OnEnable()
        {
            if (ControlSystem.IsMobile)
            {
                this.enabled = false;
            }
        }
    }
}
