using Scripts.Yandex;
using UnityEngine;

namespace Assets.Scripts
{
    public class CellSpawnerView : MonoBehaviour
    {
        [SerializeField] private CellView cellView;



        private CellView SpawnCell()
        {
            return Instantiate(cellView, this.transform);
        }

        private void SpawnCels()
        {
            var data = new DataHolder();
            data.Init();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    CellView cell = SpawnCell();
                    cell.DistanceValue = data.DistanceValueArr[i, j];
                }
            }
        }

        private void Start()
        {
            SpawnCels();
        }
    }
}
