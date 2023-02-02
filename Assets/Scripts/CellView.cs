using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CellView : MonoBehaviour, IPointerClickHandler
{
    private static int s_numRightClick = 5;
    private static int s_bomb = 0;


    //public int DistanceValue { get; set; }
    public int DistanceValue;
    public bool IsBomb
    {
        get
        {
            return DistanceValue == 0;
        }
    }


    public static Action GameLosedEvent;
    public static Action ButtonClickedEbent;


    public void OnClick()
    {
        if (IsBomb)
        {
            GameLosedEvent?.Invoke();
            return;
        }
        ChangeText();
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
                    img.color = Color.blue;
                    s_numRightClick--;
                    if (IsBomb)
                    {
                        s_bomb++;
                        if(s_bomb == 5)
                        {
                            GameLosedEvent?.Invoke();
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
