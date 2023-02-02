using UnityEngine;

namespace Assets.Scripts
{
    public class CellSpawnerView: MonoBehaviour
    {
        [SerializeField]private CellView cellView;


        private void SpawnCell()
        {
            Instantiate(cellView, this.transform);
        }

        private void SpawnCels()
        {
            var data = new DataHolder();
            data.
            for (int i = 0; i < 100; i++)
            {
                SpawnCell();
            }
        }

        private void Start()
        {
            SpawnCels();
        }
    }
}
