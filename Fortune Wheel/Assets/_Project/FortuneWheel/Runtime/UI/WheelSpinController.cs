using System.Linq;
using _Project.FortuneWheel.Runtime;
using _Project.Scripts.Runtime;
using DG.Tweening;
using UnityEngine;

public class WheelSpinController : MonoBehaviour
{
    [Range(1, 20)] [SerializeField] private int _numberOfWheelRotations = 10;

    [SerializeField] private WheelGenerator _wheelGenerator;
    
    public int SpinResult { get; private set; }
    
    public void Spin()
    {
        // choose random number on a wheel
        var resultIndex = Random.Range(0, _wheelGenerator.WheelNumbers.Count);
        SpinResult = _wheelGenerator.WheelNumbers[resultIndex];

        _wheelGenerator.LastGeneratedReward = _wheelGenerator.CurrentReward;
        
        Debug.Log($"Result: {SpinResult} {_wheelGenerator.LastGeneratedReward}");

        AnimateWheelSpin(resultIndex);
    }

    private void AnimateWheelSpin(int targetWheelPieceNumber)
    {
        var targetAngle = targetWheelPieceNumber * RuntimeConstants.WheelSettings.WheelPieceAngle;
        var targetRotationVector = new Vector3(0, 0, 360 * _numberOfWheelRotations + targetAngle + RuntimeConstants.WheelSettings.WheelPieceAngle * 0.5f);

        transform.DORotate(targetRotationVector, 5f, RotateMode.FastBeyond360).SetEase(Ease.OutCubic);
    }
}
