namespace Assets.Scripts
{
    public class DataHolder
    {
        private int[,] array = new int[10, 10];

        private void SpawnBombCoord()
        {
            for (int i = 0; i < 5; i++)
            {


            }
        }

        private int GetRandomNum()
        {
            var rnd = new System.Random();
            return rnd.Next(0, 10);
        }

        private void aslkd()
        {
            var arr = new int[5, 2];
            int n = 0;
            while (true)
            {
                int x= GetRandomNum();
                int y= GetRandomNum();
                if(arr[n,0] !=x && arr[n, 1] != y)
                {

                    n++;
                    if (n > 4)
                    {
                        return ;
                    }
                }
            }

        }
    }
}
