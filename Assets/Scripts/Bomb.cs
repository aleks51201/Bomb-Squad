namespace Assets.Scripts
{
    public class Bomb
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int[] Coordinate
        {
            get
            {
                return new int[] { X, Y };
            }
        }


        public Bomb(int x, int y)
        {
            X = x;
            Y = y;
        }

        
        public bool IsEqualsBobm(Bomb bomb)
        {
            return bomb.X == X && bomb.Y == Y;
        }
    }
}
