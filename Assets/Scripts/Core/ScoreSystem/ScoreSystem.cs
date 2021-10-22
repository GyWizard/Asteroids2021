using System;

namespace Asteroids.Systems
{
    public sealed class ScoreSystem
    {
        private int _score;
        public int Score => _score;

        public event Action<int> scoreUpdated;

        public void AddPoints(int points)
        {
            _score += points;
            scoreUpdated?.Invoke(_score);
        }

        public void ClearScoreSystem()
        {
            scoreUpdated = null;
        }
    }
}