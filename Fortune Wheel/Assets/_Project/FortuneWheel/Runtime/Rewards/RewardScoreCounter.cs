using System;
using System.Collections;
using FortuneWheel.Runtime.Wheel;
using UnityEngine;

namespace FortuneWheel.Runtime.Rewards
{
    public class RewardScoreCounter : MonoBehaviour
    {
        [SerializeField] private WheelSpinController _wheelSpinController;
        [SerializeField] private WheelStateController _wheelStateController;
        
        public int CurrentScore { get; private set; }

        public event EventHandler OnScoreChanged;

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