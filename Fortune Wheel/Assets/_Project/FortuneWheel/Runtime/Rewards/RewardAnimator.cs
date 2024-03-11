using System;
using DG.Tweening;
using UnityEngine;

namespace FortuneWheel.Runtime.Rewards
{
    public class RewardAnimator : MonoBehaviour
    {
        [Header("Animation parameters")]
        [SerializeField] private float _moveTime = 0.5f;
        [SerializeField] private float _scaleTime = 0.5f;
        
        public Vector3 InitialPosition { get; set; }
        private Vector3 _destructionPosition;
        
        private Reward _reward;
        private RewardScoreCounter _rewardScoreCounter;

        private void Awake()
        {
            _reward = GetComponent<Reward>();
            _rewardScoreCounter = GameObject.FindGameObjectWithTag(RuntimeConstants.Tags.Counter).GetComponent<RewardScoreCounter>();
        }

        private void OnEnable()
        {
            _reward.OnLifetimeEnded += RewardOnLifetimeEnded;
        }

        private void OnDisable()
        {
            _reward.OnLifetimeEnded -= RewardOnLifetimeEnded;
        }

        private void Start()
        {
            transform.localScale = Vector3.zero;
            _destructionPosition = GameObject.FindGameObjectWithTag(RuntimeConstants.Tags.Finish).transform.position;

            transform.DOMove(InitialPosition, _moveTime).SetEase(Ease.OutCubic);
            transform.DOScale(Vector3.one, _scaleTime);
        }
        
        private void RewardOnLifetimeEnded(object sender, EventArgs e)
        {
            transform.DOScale(Vector3.zero, _scaleTime);
            transform.DOMove(_destructionPosition, _moveTime).SetEase(Ease.OutCubic).OnComplete(() =>
            {
                _rewardScoreCounter.UpdateScore(_reward.Value);
                Destroy(gameObject);
            });
        }
    }
}