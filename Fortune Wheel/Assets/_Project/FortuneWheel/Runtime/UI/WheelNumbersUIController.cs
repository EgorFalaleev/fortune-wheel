using System;
using FortuneWheel.Runtime.Wheel;
using TMPro;
using UnityEngine;

namespace FortuneWheel.Runtime.UI
{
    public class WheelNumbersUIController : MonoBehaviour
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