using System;
using _Project.FortuneWheel.Runtime;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class WheelSpinController : MonoBehaviour
{
    [Range(1, 20)] [SerializeField] private int _numberOfWheelRotations = 10;

    [SerializeField] private WheelGenerator _wheelGenerator;

    public event EventHandler OnSpinAnimationStarted;
    public event EventHandler OnSpinAnimationFinished;
    
    public int SpinResult { get; private set; }
    
    public void Spin()
    {
        // choose random number on a wheel
        var resultIndex = Random.Range(0, _wheelGenerator.WheelNumbers.Count);
        SpinResult = _wheelGenerator.WheelNumbers[resultIndex];
        
        Debug.Log($"Result: {SpinResult}");

        AnimateWheelSpin(resultIndex);
    }

    private void AnimateWheelSpin(int targetWheelPieceNumber)
    {
        if (OnSpinAnimationStarted != null)
            OnSpinAnimationStarted(this, EventArgs.Empty);
        
        var targetAngle = targetWheelPieceNumber * RuntimeConstants.Wheel.WheelPieceAngle;
        var targetRotationVector = new Vector3(0, 0, 360 * _numberOfWheelRotations + targetAngle + RuntimeConstants.Wheel.WheelPieceAngle * 0.5f);

        transform.DORotate(targetRotationVector, 5f, RotateMode.FastBeyond360).SetEase(Ease.OutCubic).OnComplete(() =>
        {
            if (OnSpinAnimationFinished != null)
                OnSpinAnimationFinished(this, EventArgs.Empty);
        });
    }
}
