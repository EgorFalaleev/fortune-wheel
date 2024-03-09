using System;
using System.Collections.Generic;
using _Project.Scripts.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.FortuneWheel.Runtime.UI
{
    public class WheelRewardUIController : MonoBehaviour
    {
        [SerializeField] private Image _rewardImage;
        [SerializeField] private TMP_Text _rewardText;
        
        [SerializeField] private WheelGenerator _wheelGenerator;
        [SerializeField] private WheelStateController _wheelStateController;

        [Serializable]
        private class RewardTypeToSprite
        {
            public RewardType type;
            public Sprite sprite;
        }

        // fake dictionary made for inspector setup
        [SerializeField] private List<RewardTypeToSprite> _rewardTypeToSpritesList;

        // real dictionary for code 
        private Dictionary<RewardType, Sprite> _rewardTypeToSpritesDictionary;

        private void Awake()
        {
            _rewardTypeToSpritesDictionary = new Dictionary<RewardType, Sprite>();

            // fill the real dictionary with values from inspector
            foreach (var entry in _rewardTypeToSpritesList)
            {
                _rewardTypeToSpritesDictionary.Add(entry.type, entry.sprite);
            }
        }

        private void Start()
        {
            _rewardText.gameObject.SetActive(false);
            _rewardImage.gameObject.SetActive(true);
        }

        private void OnEnable()
        {
            _wheelGenerator.OnWheelGenerated += WheelGeneratorOnWheelGenerated;
        }

        private void OnDisable()
        {
            _wheelGenerator.OnWheelGenerated -= WheelGeneratorOnWheelGenerated;
        }

        private void WheelGeneratorOnWheelGenerated(object sender, EventArgs e)
        {
            _rewardImage.sprite = _rewardTypeToSpritesDictionary[_wheelGenerator.CurrentReward];
        }
    }
}