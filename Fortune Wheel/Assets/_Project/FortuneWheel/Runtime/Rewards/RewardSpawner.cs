using System;
using _Project.FortuneWheel.Runtime;
using _Project.FortuneWheel.Runtime.Rewards;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace _Project.Scripts.Runtime
{
    public class RewardSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _rewardPrefab;
        [SerializeField] private RectTransform _parentObject;
        
        [SerializeField] private WheelSpinController _wheelSpinController;
        [SerializeField] private WheelGenerator _wheelGenerator;

        [Header("Spawn parameters")] 
        [Range(0f, 15f)] [SerializeField] private float _minSpawnRadius;
        [Range(25f, 100f)] [SerializeField] private float _maxSpawnRaduis;

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
            var numberOfObjectsToSpawn = Mathf.Min(spinScore, RuntimeConstants.RewardSpawner.MaxRewardsToSpawn);
            var valuePerReward = spinScore / numberOfObjectsToSpawn;
            var remainingValue = spinScore % numberOfObjectsToSpawn;

            for (int i = 0; i < numberOfObjectsToSpawn; i++)
            {
                var currentRewardValue = valuePerReward;

                // if score is more than number of objects we need to increase value per reward
                if (i < remainingValue)
                    currentRewardValue++;

                var newReward = SpawnReward();
                newReward.GetComponent<Reward>().Initialize(currentRewardValue, _wheelGenerator.RewardTypeToSpritesDictionary[_wheelGenerator.CurrentRewardType]);
                newReward.GetComponent<RewardAnimator>().InitialPosition =
                    GenerateRandomPositionAroundPoint(_parentObject.transform.position);
            }
        }
        
        private GameObject SpawnReward()
        {
            var newObject = Instantiate(_rewardPrefab, _parentObject.transform.position, Quaternion.identity);
            newObject.transform.SetParent(_parentObject);
            return newObject;
        }

        private Vector3 GenerateRandomPositionAroundPoint(Vector3 point)
        {
            var randomAngle = Random.Range(0, Mathf.PI * 2);
            var radius = Random.Range(_minSpawnRadius, _maxSpawnRaduis);

            // generate a point on a circle
            var spawnPosition = new Vector3(point.x + Mathf.Sin(randomAngle) * radius, point.y + Mathf.Cos(randomAngle) * radius, point.z);

            return spawnPosition;
        }
    }
}