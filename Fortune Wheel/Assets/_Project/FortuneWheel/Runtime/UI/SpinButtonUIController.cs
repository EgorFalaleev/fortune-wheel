using System;
using _Project.Scripts.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.FortuneWheel.Runtime.UI
{
    public class SpinButtonUIController : MonoBehaviour
    {
        [SerializeField] private Button _spinButton;
        [SerializeField] private TMP_Text _spinButtonText;

        [SerializeField] private WheelStateController _wheelStateController;

        private bool _isTimerRunning;

        private void OnEnable()
        {
            _wheelStateController.OnCooldownStateEnter += WheelStateControllerOnCooldownStateEnter;
            _wheelStateController.OnCooldownStateExit += WheelStateControllerOnCooldownStateExit;
        }

        private void OnDisable()
        {
            _wheelStateController.OnCooldownStateEnter -= WheelStateControllerOnCooldownStateEnter;
            _wheelStateController.OnCooldownStateExit -= WheelStateControllerOnCooldownStateExit;
        }

        private void WheelStateControllerOnCooldownStateEnter(object sender, EventArgs e)
        {
            _isTimerRunning = true;
            DisableButton();
        }

        private void WheelStateControllerOnCooldownStateExit(object sender, EventArgs e)
        {
            _isTimerRunning = false;
            EnableButton();
        }

        private void Update()
        {
            if (!_isTimerRunning)
                return;

            DisplayTimer();
        }

        private void DisplayTimer()
        {
            var cooldownTimeInSeconds = Mathf.FloorToInt(_wheelStateController.CooldownTimer);
            _spinButtonText.text = cooldownTimeInSeconds.ToString();
        }

        private void DisableButton()
        {
            _spinButton.interactable = false;
        }

        private void EnableButton()
        {
            _spinButton.interactable = true;
            _spinButtonText.text = "Испытать удачу!";
        }
    }
}