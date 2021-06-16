using System;
using General.Util;
using UnityEngine;

namespace General
{
    public class TimerManager : MonoBehaviour
    {
        private ObjectPool<Timer> _timerPool;

        public static TimerManager instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            _timerPool = new ObjectPool<Timer>(10);
        }


        void FixedUpdate()
        {
            foreach (var timer in _timerPool.getAll())
            {
                timer.UpdateTimer(Time.deltaTime);
            }
        }


        private void ReleaseFromPool(Timer timer)
        {
            timer.ResetTimer();
            _timerPool.Release(timer);
        }

        public void StartTimer(float time, Action timerEndEvent)
        {
            Timer timer = _timerPool.get();
            timer.action = timerEndEvent;
            timer.endTime = time;
            timer.timerManager = this;
        }

        private struct Timer
        {
            private float _endTime;
            private Action _action;
            private TimerManager _timerManager;


            public TimerManager timerManager
            {
                set => _timerManager = value;
            }

            public float endTime
            {
                set => _endTime = value;
            }

            public Action action
            {
                set => _action = value;
            }

            public void UpdateTimer(float time)
            {
                _endTime -= time;
                if (_endTime < 0)
                {
                    _action?.Invoke();
                    if (_timerManager != null)
                    {
                        _timerManager.ReleaseFromPool(this);
                    }
                }
            }

            public void ResetTimer()
            {
                _endTime = 0;
                _action = null;
                _timerManager = null;
            }
        }
    }
}