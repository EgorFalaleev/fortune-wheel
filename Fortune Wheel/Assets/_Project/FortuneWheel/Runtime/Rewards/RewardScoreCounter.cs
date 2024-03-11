using System;
using UnityEngine;

namespace _Project.FortuneWheel.Runtime.Rewards
{
    public class RewardScoreCounter : MonoBehaviour
    {
        public int CurrentScore { get; private set; }

        public event EventHandler OnScoreChanged;

        public void UpdateScore(int value)
        {
            CurrentScore += value;
            
            if (OnScoreChanged != null)
                OnScoreChanged(this, EventArgs.Empty);
        }
    }
}