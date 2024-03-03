using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace _Project.Scripts.Runtime
{
    public class FortuneWheel : MonoBehaviour
    {
        private WheelData _wheelData;

        private void Start()
        {
            _wheelData = new WheelData(12);
            _wheelData.GenerateWheelNumbers();

            foreach (var number in _wheelData.WheelNumbers)
            {
                Debug.Log($"{number} ");
            }
        }
    }

    public class WheelData
    {
        public HashSet<int> WheelNumbers { get; }

        private int _wheelSize;
        private Random _random;

        public WheelData(int wheelSize)
        {
            _wheelSize = wheelSize;
            WheelNumbers = new HashSet<int>();
            _random = new Random();
        }
        
        public void GenerateWheelNumbers()
        {
            WheelNumbers.Clear();
            
            while (WheelNumbers.Count != _wheelSize)
            {
                var nextNumber = _random.Next(1, 21) * 5;

                WheelNumbers.Add(nextNumber);
            }
        }
    }
}