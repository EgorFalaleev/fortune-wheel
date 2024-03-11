﻿using UnityEngine;

namespace _Project.FortuneWheel.Runtime
{
    public static class RuntimeConstants
    {
        public static class WheelConfig
        {
            public const int WheelSize = 12;
            public const float CooldownTime = 10f;
            public const float CooldownWheelGenerateTime = 1f;
            public const float WheelPieceAngle = 30f; // a single wheel piece occupies 360 / 12 = 30 degrees
        }

        public static class RewardSpawnerConfig
        {
            public const int MaxRewardsToSpawn = 20;
        }
    }
}