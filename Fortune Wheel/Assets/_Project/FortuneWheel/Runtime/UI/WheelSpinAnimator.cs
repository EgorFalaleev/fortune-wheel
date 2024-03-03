using _Project.Scripts.Runtime;
using DG.Tweening;
using UnityEngine;

public class WheelSpinAnimator : MonoBehaviour
{
    [Range(1, 20)] [SerializeField] private int _numberOfWheelRotations = 10;
    
    // a single wheel piece occupies 360 / 12 = 30 degrees
    private const float WHEEL_PIECE_SECTOR = 30f;
    
    public void AnimateSpin()
    {
        var result = GetComponent<FortuneWheel>().Result;

        var targetAngle = result * WHEEL_PIECE_SECTOR;
        var targetRotationVector = new Vector3(0, 0, 360 * _numberOfWheelRotations + targetAngle + WHEEL_PIECE_SECTOR * 0.5f);
        
        transform.DORotate(targetRotationVector, 5f, RotateMode.FastBeyond360).SetEase(Ease.OutCubic);
    }
}
