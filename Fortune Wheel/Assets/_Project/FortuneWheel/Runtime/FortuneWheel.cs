using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = System.Random;

namespace _Project.Scripts.Runtime
{
    public class FortuneWheel : MonoBehaviour
    {
        [SerializeField] private TMP_Text[] _wheelNumbersTexts;

        private WheelData _wheelData;

        private void Start()
        {
            _wheelData = new WheelData(12);
            _wheelData.GenerateWheelNumbers();

            foreach (var number in _wheelData.WheelNumbers)
            {
                Debug.Log($"{number} ");
            }

            for (int i = 0; i < _wheelNumbersTexts.Length; i++)
            {
                _wheelNumbersTexts[i].text = _wheelData.WheelNumbers[i].ToString();
            }

            Spin();
        }

        public void Spin()
        {
            var resultIndex = UnityEngine.Random.Range(0, _wheelData.WheelNumbers.Count);
            Debug.Log($"Result: {_wheelData.WheelNumbers[resultIndex]}");
        }
    }

    public class WheelData
    {
        public List<int> WheelNumbers { get; }

        private int _wheelSize;
        private Random _random;

        public WheelData(int wheelSize)
        {
            _wheelSize = wheelSize;
            WheelNumbers = new List<int>();
            _random = new Random();
        }

        public void GenerateWheelNumbers()
        {
            WheelNumbers.Clear();

            while (WheelNumbers.Count != _wheelSize)
            {
                var nextNumber = _random.Next(1, 21) * 5;

                // add only unique numbers 
                if (!WheelNumbers.Contains(nextNumber))
                    WheelNumbers.Add(nextNumber);
            }
        }
    }
}