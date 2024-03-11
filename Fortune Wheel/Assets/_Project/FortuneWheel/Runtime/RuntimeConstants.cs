namespace _Project.FortuneWheel.Runtime
{
    public static class RuntimeConstants
    {
        public static class Wheel
        {
            public const int WheelSize = 12;
            public const float CooldownTime = 1f;
            public const float CooldownWheelGenerateTime = 1f;
            public const float WheelPieceAngle = 30f; // a single wheel piece occupies 360 / 12 = 30 degrees
        }

        public static class RewardSpawner
        {
            public const int MaxRewardsToSpawn = 20;
        }

        public static class Tags
        {
            public const string Finish = "Finish";
        }
    }
}