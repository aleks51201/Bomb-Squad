using System.Collections.Generic;

namespace Assets.Scripts
{
    public class BombCreater
    {
        private List<Bomb> _bombs;
        private int _countBombs;


        public Bomb[] Bombs
        {
            get
            {
                return _bombs.ToArray();
            }
        }


        public BombCreater(int countBombs)
        {
            _countBombs = countBombs;
        }


        public void CreateBombs()
        {
            int n = 0;
            
            while (n < _countBombs)
            {
                Bomb bomb = CreateBomb(); 
                if (_bombs.Count == 0)
                {
                    _bombs.Add(bomb);
                    n++;
                    continue;
                }
                bool isEqual = false;
                foreach (Bomb bm in _bombs)
                {
                    if (bm.IsEqualsBobm(bomb))
                    {
                        isEqual = true;
                        break;
                    }
                }
                if (!isEqual)
                {
                    _bombs.Add(bomb);
                    n++;
                }
            }
        }

        private Bomb CreateBomb()
        {
            return new(GetRandomNum(0, 10), GetRandomNum(0, 10));
        }

        private int GetRandomNum(int minValue, int maxValue)
        {
            System.Random rnd = new System.Random();
            return rnd.Next(minValue, maxValue);
        }
    }
}
