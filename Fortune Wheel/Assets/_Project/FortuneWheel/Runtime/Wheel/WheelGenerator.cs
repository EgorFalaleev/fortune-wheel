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

    private List<RewardType> _possibleRewards;
    private int _rewardIndex;

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

        // get random reward type
        _rewardIndex = GetRandomIndexExcludingCurrent(_rewardIndex, _possibleRewards.Count);
        CurrentReward = _possibleRewards[_rewardIndex];
        
        if (OnWheelGenerated != null)
            OnWheelGenerated(this, EventArgs.Empty);
    }

    private int GetRandomIndexExcludingCurrent(int currentIndex, int listCount)
    {
        // calculates a valid index randomly, excluding currentIndex 
        return (currentIndex + Random.Range(1, listCount)) % listCount;
    }
}

public enum RewardType
{
    Diamond,
    Coin,
    Ruby
}