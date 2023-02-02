
namespace Assets.Scripts
{
    public class ScoreHolder
    {
        private int _score;


        public int Score => _score;


        public void Init()
        {
            CellView.ButtonClickedEbent += AddPoint;
        }

        private void AddPoint()
        {
            _score +=1;
        }
    }
}
