using System;
using UnityEngine;

namespace BombSquad
{
    public class MapCreater
    {
        private int[,] array = new int[10, 10];
        private bool[,] array1 = new bool[10, 10];
        private Bomb[] arr;


        public int[,] DistanceValueArr => array;


        public void Init()
        {
            CreateBombCoordOField();
            AssignDistanceValuesToCells();
        }

        private void CreateBombs()
        {
            BombCreater bombCreater = new(5);
            bombCreater.CreateBombs();
            arr = bombCreater.Bombs;
        }

        private void CreateBombCoordOField()
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
                        int numMax = MaxDistance(bmb.X - j, bmb.Y - i);
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

        private int MaxDistance(int x, int y)
        {
            return Math.Max(Math.Abs(x), Math.Abs(y));
        }
    }
}
