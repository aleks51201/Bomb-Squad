using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BombSquad
{
    public class CellView : MonoBehaviour
    {
        public static int NumRightClick = 5;
        public static int Bomb = 0;
        public static bool IsWin = false;

        [SerializeField] private Sprite bombSprite;
        [SerializeField] private Sprite flagSprite;
        [SerializeField] private Sprite defaultSprite;
        [SerializeField] private ButtonWithClick button;
        [SerializeField] private ButtonWithClickAndHold buttonWithHold;


        public int DistanceValue { get; set; }
        public bool IsBomb
        {
            get
            {
                return DistanceValue == 0;
            }
        }
        public bool IsClicked { get; set; }
        public bool IsMarked { get; set; }
        public Sprite DefaultSprite => defaultSprite;


        public static Action GameLosedEvent;
        public static Action GameWonEvent;
        public static Action ButtonClickedEbent;


        public void OnClick()
        {
            if (IsClicked || IsMarked)
            {
                return;
            }
            if (IsBomb)
            {
                GetComponent<Image>().sprite = bombSprite;
                GameLosedEvent?.Invoke();
                return;
            }
            ChangeText();
            IsClicked = true;
            ButtonClickedEbent?.Invoke();
        }

        private void ChangeText()
        {
            GetComponentInChildren<TextMeshProUGUI>().text = $"{DistanceValue}";
        }

        private void OnAlternativeAction()
        {
            var img = GetComponent<Image>();
            if (!IsMarked)
            {
                if (NumRightClick > 0)
                {
                    if (IsClicked)
                    {
                        return;
                    }
                    img.sprite = flagSprite;
                    NumRightClick--;
                    IsMarked = true;
                    if (IsBomb)
                    {
                        Bomb++;
                        if (Bomb == 5)
                        {
                            IsWin = true;
                            GameWonEvent?.Invoke();
                        }
                    }
                }
            }
            else
            {
                img.sprite = defaultSprite;
                IsMarked = false;
                NumRightClick++;
                if (IsBomb)
                {
                    Bomb--;
                }
            }
        }

        private void OnEnable()
        {
            button.LeftButtonClickedEvent += OnClick;
            button.RightButtonClickedEvent += OnAlternativeAction;
            buttonWithHold.ButtonClickedEvent += OnClick;
            buttonWithHold.ButtonHeldEvent += OnAlternativeAction;
        }

        private void OnDisable()
        {
            button.LeftButtonClickedEvent -= OnClick;
            button.RightButtonClickedEvent -= OnAlternativeAction;
            buttonWithHold.ButtonClickedEvent -= OnClick;
            buttonWithHold.ButtonHeldEvent -= OnAlternativeAction;
        }
    }

}
