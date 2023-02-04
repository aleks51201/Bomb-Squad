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
    public bool IsClicked { get; private set; }
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
            if (img.color == Color.white)
            {
                if (NumRightClick > 0)
                {
                    if (IsClicked)
                    {
                        return;
                    }
                    if(flagSprite is null)
                    {
                        img.color = Color.blue;
                    }
                    else
                    {
                        img.sprite = flagSprite;
                    }
                    NumRightClick--;
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
                if (flagSprite is null)
                {
                    img.color = Color.white;
                }
                else
                {
                    img.sprite = defaultSprite;
                }
                NumRightClick++;
                if (IsBomb)
                {
                    Bomb--;
                }
            }
        }
    }

}
