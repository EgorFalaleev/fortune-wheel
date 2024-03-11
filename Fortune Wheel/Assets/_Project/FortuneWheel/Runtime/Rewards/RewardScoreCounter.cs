using System;
using System.Collections;
using _Project.Scripts.Runtime;
using UnityEngine;

namespace _Project.FortuneWheel.Runtime.Rewards
{
    public class RewardScoreCounter : MonoBehaviour
    {
        [SerializeField] private WheelSpinController _wheelSpinController;
        [SerializeField] private WheelStateController _wheelStateController;
        
        public int CurrentScore { get; private set; }

        public event EventHandler OnScoreChanged;
        public event EventHandler OnTargetScoreReached;

        public void UpdateScore(int value)
        {
            CurrentScore += value;
            
            if (OnScoreChanged != null)
                OnScoreChanged(this, EventArgs.Empty);

            if (CurrentScore == _wheelSpinController.SpinResult)
            {
                CurrentScore = 0;

                StartCoroutine(EnterCooldownAfterPause(2f));
            }
        }

        private IEnumerator EnterCooldownAfterPause(float pauseInSeconds)
        {
            yield return new WaitForSeconds(pauseInSeconds);
            
            _wheelStateController.EnterCooldownState();
        }
    }
}