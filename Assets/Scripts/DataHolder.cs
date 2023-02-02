using System;
using System.Collections.Generic;

namespace Assets.Scripts
{
    public class DataHolder
    {
        private int[,] array = new int[10, 10];
        private bool[,] array1 = new bool[10, 10];
        private List<Bomb> arr;


        private void SpawnBombCoord()
        {
            arr = new List<Bomb>();
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
                foreach (Bomb bm in arr)
                {
                    if (bm.IsEqualsBobm(bomb))
                    {
                        continue;
                    }
                }
                n++;
            }
            foreach (Bomb bmb in arr)
            {
                array1[bmb.Y, bmb.X] = true;
                array[bmb.Y, bmb.X] = 0;
            }
        }

        private void lakdjf()
        {
            for(int i= 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    if( array1[i, j])
                    {
                        continue;
                    }
                    foreach(var bmb in arr)
                    {
                        int numMax = Math.Max(bmb.X, bmb.Y);
                        if(array[i,j] ==0 || array[i,j] > numMax)
                        {
                            array[i, j] = numMax;
                        }
                    }
                }
            }
        }

        private int GetRandomNum()
        {
            System.Random rnd = new System.Random();
            return rnd.Next(0, 10);
        }
    }
}
