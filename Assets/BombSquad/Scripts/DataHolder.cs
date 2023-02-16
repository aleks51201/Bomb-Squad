using System;
using UnityEngine;

namespace BombSquad
{
    public class DataHolder
    {
        private int[,] array = new int[10, 10];
        private bool[,] array1 = new bool[10, 10];
        private Bomb[] arr;


        public int[,] DistanceValueArr => array;


        public void Init()
        {
            SpawnBombCoord();
            AssignDistanceValuesToCells();
        }

        private void CreateBombs()
        {
            BombCreater bombCreater = new(5);
            arr = bombCreater.Bombs;
        }

        private void SpawnBombCoord()
        {
            CreateBombs();
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
                        int numMax = Math.Max(Math.Abs(bmb.X - j), Math.Abs(bmb.Y - i));
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
            int b = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    strResult = strResult + $" {array[i, j]}";
                    if (array[i, j] == 0)
                    {
                        b++;
                    }
                }
                strResult = strResult + "\n";
            }
            strResult = $"\n bomb = {b}\n" + strResult;
            Debug.Log(strResult);
        }
    }
}
