using System;
using UnityEngine;
using TMPro;

public class CellView : MonoBehaviour
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
        GetComponentInChildren<TextMeshProUGUI>().text= $"{DistanceValue}";
    }
}
