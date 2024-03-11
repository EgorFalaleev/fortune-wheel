using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace _Project.FortuneWheel.Runtime.Rewards
{
    public class Reward : MonoBehaviour
    {
        [Range(0.5f, 1f)] [SerializeField] private float _minRewardLifetime;
        [Range(1.5f, 3f)] [SerializeField] private float _maxRewardLifetime;

        public int Value { get; private set; }
        private float _lifetime;

        public event EventHandler OnLifetimeEnded;

        private void Start()
        {
            StartCoroutine(LifetimeCoroutine());
        }

        public void Initialize(int value, Sprite sprite)
        {
            Value = value;
            _lifetime = Random.Range(_minRewardLifetime, _maxRewardLifetime);
            GetComponent<Image>().sprite = sprite;
        }

        private IEnumerator LifetimeCoroutine()
        {
            yield return new WaitForSeconds(_lifetime);

            if (OnLifetimeEnded != null)
                OnLifetimeEnded(this, EventArgs.Empty);
        }
    }
}