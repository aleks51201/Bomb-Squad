using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CellView : MonoBehaviour, IPointerClickHandler
{
    public  static int NumRightClick = 5;
    public static int Bomb = 0;

    [SerializeField] private Sprite bombSprite;
    [SerializeField] private Sprite flagSprite;
    [SerializeField] private Sprite defaultSprite;


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
    public static Action GameWinEvent;
    public static Action ButtonClickedEbent;


    public void OnClick()
    {
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

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
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
                        if(Bomb == 5)
                        {
                            GameWinEvent?.Invoke();
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
    }

}
