using UnityEngine;
using UnityEngine.UI;

namespace _Project.FortuneWheel.Runtime.Rewards
{
    public class Reward : MonoBehaviour
    {
        public int Value { get; private set; }

        public void Initialize(int value, Sprite sprite)
        {
            Value = value;
            GetComponent<Image>().sprite = sprite;
        }
    }
}