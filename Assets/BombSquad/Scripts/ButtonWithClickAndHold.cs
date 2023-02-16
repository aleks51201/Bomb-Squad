﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BombSquad
{
    public class ButtonWithClickAndHold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private float timeDelayInMilliseconds;

        private Coroutine _currentCoroutine;
        private bool _isHolding;


        public Action ButtonClickedEvent;
        public Action ButtonHeldEvent;


        private void StartTimerAsync()
        {
            _currentCoroutine = StartCoroutine(StartHoldTimerRoutine());
        }

        private IEnumerator StartHoldTimerRoutine()
        {
            int n = 0;
            _isHolding = true;
            while(n< timeDelayInMilliseconds)
            {
                yield return new WaitForSeconds(0.01f);
                n++;
            }
            OnButtonHeld();
        }

        private void OnButtonHeld()
        {
            ButtonHeldEvent?.Invoke();
            _isHolding = false;
        }

        private void EndTimerAsync()
        {
            if (_isHolding)
            {
                StopCoroutine(_currentCoroutine);
                _isHolding = false;
            }
        }

        private void Click()
        {
            if (!_isHolding)
            {
                ButtonClickedEvent?.Invoke();
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            StartTimerAsync();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Click();
            EndTimerAsync();
        }

        private void OnEnable()
        {
            if (!ControlSystem.IsMobile)
            {
                this.enabled = false;
            }
        }
    }
}
