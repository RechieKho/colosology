namespace General.Other
{
    public class Freezer
    {
        public delegate void FreezeTrigger(bool __freeze);
        public static FreezeTrigger trigger;

        public static void Freeze()
        {
            trigger?.Invoke(true);
        }

        public static void Unfreeze()
        {
            trigger?.Invoke(false);
        }
    }
}

