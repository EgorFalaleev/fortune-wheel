using System;
using _Project.FortuneWheel.Runtime;
using _Project.FortuneWheel.Runtime.Rewards;
using UnityEngine;

namespace _Project.Scripts.Runtime
{
    public class RewardSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _rewardPrefab;
        
        [SerializeField] private WheelSpinController _wheelSpinController;

        private void OnEnable()
        {
            _wheelSpinController.OnSpinAnimationFinished += WheelSpinControllerOnSpinAnimationFinished;
        }

        private void OnDisable()
        {
            _wheelSpinController.OnSpinAnimationFinished -= WheelSpinControllerOnSpinAnimationFinished;
        }

        private void WheelSpinControllerOnSpinAnimationFinished(object sender, EventArgs e)
        {
            var spinScore = _wheelSpinController.SpinResult;
            var numberOfObjectsToSpawn = Mathf.Min(spinScore, RuntimeConstants.RewardSpawnerConfig.MaxRewardsToSpawn);
            var valuePerReward = spinScore / numberOfObjectsToSpawn;
            var remainingValue = spinScore % numberOfObjectsToSpawn;

            for (int i = 0; i < numberOfObjectsToSpawn; i++)
            {
                var currentRewardValue = valuePerReward;

                // if score is more than number of objects we need to increase value per reward
                if (i < remainingValue)
                    currentRewardValue++;

                var newReward = SpawnReward();
                newReward.GetComponent<Reward>().Value = currentRewardValue;
            }
        }
        
        private GameObject SpawnReward()
        {
            return Instantiate(_rewardPrefab, transform.position, Quaternion.identity);
        }
    }
}