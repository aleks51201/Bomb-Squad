using System.Collections.Generic;

namespace Assets.Scripts
{
    public class DataHolder
    {
        private int[,] array = new int[10, 10];

        private void SpawnBombCoord()
        {
            var arr = new List<Bomb>();
            int n = 0;
            Bomb bomb;
            while (n < 5)
            {
                bomb = new(GetRandomNum(), GetRandomNum());
                if (arr.Count == 0)
                {
                    arr.Add(bomb);
                    n++;
                    continue;
                }
                foreach(var bm in arr)
                {
                    if (bm.IsEqualsBobm(bomb))
                    {
                        continue;
                    }
                }
                n++;
            }
        }

        private int GetRandomNum()
        {
            var rnd = new System.Random();
            return rnd.Next(0, 10);
        }

        private void aslkd()
        {

        }
    }
}
