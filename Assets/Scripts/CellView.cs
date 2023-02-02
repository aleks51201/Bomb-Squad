using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CellView : MonoBehaviour, IPointerClickHandler
{
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
        if (DistanceValue == 0)
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
                img.color = Color.blue;
            }
            else
            {
                img.color = Color.white;
            }
        }
    }

}
