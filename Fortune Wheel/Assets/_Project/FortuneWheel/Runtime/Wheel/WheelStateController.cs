﻿using System;
using UnityEngine;

namespace FortuneWheel.Runtime.Wheel
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
            if (CooldownTimer < 1f)
            {
                _isCooldownState = false;
                CooldownTimer = RuntimeConstants.Wheel.CooldownTime;
                
                if (OnCooldownStateExit != null)
                    OnCooldownStateExit(this, EventArgs.Empty);
            }

            // generate new wheel
            if (_wheelGeneratorTimer < 0)
            {
                _wheelGenerator.GenerateWheel();
                _wheelGeneratorTimer = RuntimeConstants.Wheel.CooldownWheelGenerateTime;
            }
        }

        public void EnterCooldownState()
        {
            _isCooldownState = true;
            CooldownTimer = RuntimeConstants.Wheel.CooldownTime;
            _wheelGeneratorTimer = RuntimeConstants.Wheel.CooldownWheelGenerateTime;

            if (OnCooldownStateEnter != null)
                OnCooldownStateEnter(this, EventArgs.Empty);
        }
    }
}