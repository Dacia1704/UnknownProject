using System.Collections.Generic;
using UnityEngine;

namespace ImprovedTimer
{
    public static class TimerManager
    {
        private static List<Timer> timers = new();
        private static List<Timer> sweep = new();
        
        public static void RegisterTimer(Timer timer) => timers.Add(timer);
        public static void DeregisterTimer(Timer timer) => timers.Remove(timer);

        public static void UpdateTimers()
        {
            if (timers.Count == 0) return;
            
            sweep.Clear();
            sweep.AddRange(timers);

            foreach (var timer in sweep)
            {
                timer.Tick();
            }
        }

        public static void Clear()
        {
            sweep.Clear();
            sweep.AddRange(timers);

            foreach (var timer in sweep)
            {
                
            }
            
            timers.Clear();
            sweep.Clear();
        }


    }
}