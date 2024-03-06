using System;
using System.Collections;
using System.Collections.Generic;
using _Project.FortuneWheel.Runtime;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class WheelGenerator : MonoBehaviour
{
    public event EventHandler OnWheelGenerated;
    
    public List<int> WheelNumbers { get; private set; }

    public void GenerateWheel()
    {
        WheelNumbers = new List<int>();

        // fill the list with unique values
        while (WheelNumbers.Count != RuntimeConstants.WheelSettings.WheelSize)
        {
            var nextNumber = Random.Range(1, 21) * 5;
            
            if (!WheelNumbers.Contains(nextNumber))
                WheelNumbers.Add(nextNumber);
        }
        
        if (OnWheelGenerated != null)
            OnWheelGenerated(this, EventArgs.Empty);
    }
}
