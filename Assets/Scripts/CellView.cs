using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CellView : MonoBehaviour, IPointerClickHandler
{
    private static int s_numRightClick = 5;
    private static int s_bomb = 0;

    [SerializeField] private Sprite bombSprite;


    public int DistanceValue { get; set; }
    public bool IsBomb
    {
        get
        {
            return DistanceValue == 0;
        }
    }
    public bool IsClicked { get; private set; }


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
                if (s_numRightClick > 0)
                {
                    if (IsClicked)
                    {
                        return;
                    }
                    img.color = Color.blue;
                    s_numRightClick--;
                    if (IsBomb)
                    {
                        s_bomb++;
                        if(s_bomb == 5)
                        {
                            GameWinEvent?.Invoke();
                        }
                    }
                }
            }
            else
            {
                img.color = Color.white;
                s_numRightClick++;
                if (IsBomb)
                {
                    s_bomb--;
                }
            }
        }
    }

}
