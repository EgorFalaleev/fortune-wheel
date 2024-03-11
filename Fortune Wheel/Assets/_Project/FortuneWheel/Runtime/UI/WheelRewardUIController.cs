﻿using System;
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
        [SerializeField] private WheelSpinController _wheelSpinController; 

        private void Start()
        {
            _rewardText.gameObject.SetActive(false);
            _rewardImage.gameObject.SetActive(true);
        }

        private void OnEnable()
        {
            _wheelGenerator.OnWheelGenerated += WheelGeneratorOnWheelGenerated;
            _wheelSpinController.OnSpinAnimationFinished += WheelSpinControllerOnSpinAnimationFinished;
        }
        
        private void OnDisable()
        {
            _wheelGenerator.OnWheelGenerated -= WheelGeneratorOnWheelGenerated;
            _wheelSpinController.OnSpinAnimationFinished -= WheelSpinControllerOnSpinAnimationFinished;
        }
        
        
        private void WheelSpinControllerOnSpinAnimationFinished(object sender, EventArgs e)
        {
            _rewardImage.gameObject.SetActive(false);
            _rewardText.gameObject.SetActive(true);
            _rewardText.text = "0";
        }

        private void WheelGeneratorOnWheelGenerated(object sender, EventArgs e)
        {
            _rewardText.gameObject.SetActive(false);
            _rewardImage.gameObject.SetActive(true);
            _rewardImage.sprite = _wheelGenerator.RewardTypeToSpritesDictionary[_wheelGenerator.CurrentReward];
        }
    }
}