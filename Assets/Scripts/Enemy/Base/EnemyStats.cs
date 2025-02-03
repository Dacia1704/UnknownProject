using System;

[Serializable]
public class EnemyStats: Stats
{
        public float BaseDistanceTrigger { get; private set; }
        public float DropRate { get; private set; }
}