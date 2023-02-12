using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class DataHolder
    {
        private int[,] array = new int[10, 10];
        private bool[,] array1 = new bool[10, 10];
        private List<Bomb> arr;


        public int[,] DistanceValueArr => array;


        public void Init()
        {
            SpawnBombCoord();
            AssignDistanceValuesToCells();
        }

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
                bool isEqual = false;
                foreach (Bomb bm in arr)
                {
                    if (bm.IsEqualsBobm(bomb))
                    {
                        isEqual = true;
                        break;
                    }
                }
                if (!isEqual)
                {
                    arr.Add(bomb);
                    n++;
                }
            }
            foreach (Bomb bmb in arr)
            {
                array1[bmb.Y, bmb.X] = true;
                array[bmb.Y, bmb.X] = 0;
            }
        }

        private void AssignDistanceValues​​ToCells()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (array1[i, j])
                    {
                        continue;
                    }
                    int max = 0;
                    foreach (var bmb in arr)
                    {
                        int numMax = Math.Max(Math.Abs(bmb.X -j) ,Math.Abs( bmb.Y - i));
                        if (max == 0)
                        {
                            max = numMax;
                        }
                        else
                        {
                            if (numMax < max)
                            {
                                max = numMax;
                            }
                        }

                    }
                    array[i, j] = max;
                }
            }
        }

        public void PrintMap()
        {
            string strResult = "";
            int b= 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    strResult = strResult +$" {array[i, j]}" ;
                    if (array[i, j]==0)
                    {
                        b++;
                    }
                }
                strResult = strResult + "\n";
            }
            strResult =  $"\n bomb = {b}\n" + strResult ;
            Debug.Log(strResult);
        }

        private int GetRandomNum()
        {
            System.Random rnd = new System.Random();
            return rnd.Next(0, 10);
        }
    }
}
