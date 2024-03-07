using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using _Project.FortuneWheel.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class WheelGenerator : MonoBehaviour
{
    public event EventHandler OnWheelGenerated;

    public List<int> WheelNumbers { get; private set; }
    public RewardType CurrentReward { get; private set; }
    public RewardType LastGeneratedReward { get; set; }

    private List<RewardType> _possibleRewards;

    private void Awake()
    {
        WheelNumbers = new List<int>();
        _possibleRewards = new List<RewardType>();
    }

    private void Start()
    {
        // all rewards are possible at the start of the game
        _possibleRewards = Enum.GetValues(typeof(RewardType)).Cast<RewardType>().ToList();

        GenerateWheel();
    }

    public void GenerateWheel()
    {
        WheelNumbers.Clear();

        // fill the list with unique values
        while (WheelNumbers.Count != RuntimeConstants.WheelSettings.WheelSize)
        {
            var nextNumber = Random.Range(1, 21) * 5;

            if (!WheelNumbers.Contains(nextNumber))
                WheelNumbers.Add(nextNumber);
        }

        while (CurrentReward == LastGeneratedReward)
            CurrentReward = (RewardType)Random.Range(0, Enum.GetValues(typeof(RewardType)).Length);

        if (OnWheelGenerated != null)
            OnWheelGenerated(this, EventArgs.Empty);
    }
}

public enum RewardType
{
    Crystal,
    Coin,
    Ruby
}