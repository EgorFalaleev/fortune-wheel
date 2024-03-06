﻿using System;
using TMPro;
using UnityEngine;

namespace _Project.FortuneWheel.Runtime.UI
{
    public class WheelUIController : MonoBehaviour
    {
        [SerializeField] private TMP_Text[] _wheelNumbersTexts;
        
        [SerializeField] private WheelGenerator _wheelGenerator;

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
            DisplayWheelNumbers();
        }

        private void DisplayWheelNumbers()
        {
            for (int i = 0; i < _wheelNumbersTexts.Length; i++)
            {
                _wheelNumbersTexts[i].text = _wheelGenerator.WheelNumbers[i].ToString();
            }
        }
    }
}