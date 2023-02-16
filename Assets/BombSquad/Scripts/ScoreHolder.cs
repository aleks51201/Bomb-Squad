
namespace Assets.Scripts
{
    public class ScoreHolder
    {
        private int _score;


        public int Score => _score;


        public void Init()
        {
            CellView.ButtonClickedEbent += AddPoint;
            Restarter.GameRestartedEvent += OnRestartedEvent;
        }

        private void AddPoint()
        {
            _score +=1;
        }

        private void OnRestartedEvent()
        {
            _score = 0;
        }
    }
}
