using System;
using _Project.FortuneWheel.Runtime;
using UnityEngine;

namespace _Project.Scripts.Runtime
{
    public class WheelStateController : MonoBehaviour
    {
        [SerializeField] private WheelGenerator _wheelGenerator;

        public float CooldownTimer { get; private set; }

        public event EventHandler OnCooldownStateEnter;
        public event EventHandler OnCooldownStateExit;

        private bool _isCooldownState;
        private float _wheelGeneratorTimer;

        private void Start()
        {
            EnterCooldownState();
        }

        private void Update()
        {
            if (!_isCooldownState)
                return;

            CooldownTimer -= Time.deltaTime;
            _wheelGeneratorTimer -= Time.deltaTime;

            // exit cooldown state
            if (CooldownTimer < 0)
            {
                _isCooldownState = false;
                CooldownTimer = RuntimeConstants.WheelConfig.CooldownTime;
                
                if (OnCooldownStateExit != null)
                    OnCooldownStateExit(this, EventArgs.Empty);
            }

            // generate new wheel
            if (_wheelGeneratorTimer < 0)
            {
                _wheelGenerator.GenerateWheel();
                _wheelGeneratorTimer = RuntimeConstants.WheelConfig.CooldownWheelGenerateTime;
            }
        }

        private void EnterCooldownState()
        {
            _isCooldownState = true;
            CooldownTimer = RuntimeConstants.WheelConfig.CooldownTime;
            _wheelGeneratorTimer = RuntimeConstants.WheelConfig.CooldownWheelGenerateTime;

            if (OnCooldownStateEnter != null)
                OnCooldownStateEnter(this, EventArgs.Empty);
        }
    }
}