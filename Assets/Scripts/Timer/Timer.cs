using System;
using UnityEngine;

namespace ImprovedTimer
{
    public abstract class Timer: IDisposable
    {
        public float CurrentTime { get;protected set; }
        public bool IsRunning { get; protected set; }

        protected float initialTime;
        
        public Action OnTimeStart = delegate { };
        public Action OnTimeStop = delegate { };

        public float Progress => Mathf.Clamp(CurrentTime / initialTime, 0, 1);

        protected Timer(float value)
        {
            initialTime = value;
        }
        public virtual void Start()
        {
            CurrentTime = initialTime;
            if (!IsRunning)
            {
                IsRunning = true;
                TimerManager.RegisterTimer(this);
                OnTimeStart.Invoke();
            }
        }

        public virtual void Stop()
        {
            if (IsRunning)
            {
                IsRunning = false;
                TimerManager.DeregisterTimer(this);
                OnTimeStop.Invoke();
            }
        }
        
        public abstract void Tick();
        public abstract bool IsFinished { get; }
        
        public void Resume() => IsRunning = true;
        public void Pause() => IsRunning = false;
        public virtual void Reset() => CurrentTime = initialTime;

        public virtual void Reset(float newTime) {
            initialTime = newTime;
            Reset();
        }
        
        
        
        protected bool disposed;
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;

            if (disposing)
            {
                TimerManager.DeregisterTimer(this);
            }
            
            disposed= true;
            
        }

        ~Timer()
        {
            Dispose(false);
        }

    }
}