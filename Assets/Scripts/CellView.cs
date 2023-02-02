using UnityEngine;

public class CellView : MonoBehaviour
{
    public int DistanceValue { get; set; }
    public bool IsBomb
    {
        get
        {
            return DistanceValue == 0;
        }
    }
}
