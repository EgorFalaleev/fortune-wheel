using System;
using _Project.FortuneWheel.Runtime;
using UnityEngine;

namespace _Project.Scripts.Runtime
{
    public class WheelStateController : MonoBehaviour
    {
        [SerializeField] private WheelGenerator _wheelGenerator;
        
        private bool _isCooldownState;
        private float _cooldownTimer;
        private float _wheelGeneratorTimer;
        
        private void Start()
        {
            _isCooldownState = true;
            _cooldownTimer = RuntimeConstants.WheelSettings.CooldownTime;
            _wheelGeneratorTimer = RuntimeConstants.WheelSettings.CooldownWheelGenerateTime;
        }

        private void Update()
        {
            if (!_isCooldownState)
                return;
            
            _cooldownTimer -= Time.deltaTime;
            _wheelGeneratorTimer -= Time.deltaTime;

            // exit cooldown state
            if (_cooldownTimer < 0)
            {
                _isCooldownState = false;
                _cooldownTimer = RuntimeConstants.WheelSettings.CooldownTime;
            }

            // generate new wheel
            if (_wheelGeneratorTimer < 0)
            {
                _wheelGenerator.GenerateWheel();
                _wheelGeneratorTimer = RuntimeConstants.WheelSettings.CooldownWheelGenerateTime;
            }
        }
    }
}