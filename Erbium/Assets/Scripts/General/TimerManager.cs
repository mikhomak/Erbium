using System;
using General.Util;
using UnityEngine;

namespace General {
    public class TimerManager : MonoBehaviour {
        private ObjectPool<Timer> timerPool;

        public static TimerManager Instance;

        private void Awake() {
            if (Instance == null) {
                Instance = this;
            }
            else if (Instance != this) {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);
        }

        private void Start() {
            timerPool = new ObjectPool<Timer>(10);
        }


        void FixedUpdate() {
            foreach (var timer in timerPool.getAll()) {
                timer.updateTimer(Time.deltaTime);
            }
        }


        private void releaseFromPool(Timer timer) {
            timer.resetTimer();
            timerPool.release(timer);
        }

        public void startTimer(float time, Action timerEndEvent) {
            Timer timer = timerPool.get();
            timer.Action = timerEndEvent;
            timer.EndTime = time;
            timer.TimerManager = this;
        }

        private struct Timer {
            private float endTime;
            private Action action;
            private TimerManager timerManager;


            public TimerManager TimerManager {
                set => timerManager = value;
            }

            public float EndTime {
                set => endTime = value;
            }

            public Action Action {
                set => action = value;
            }

            public void updateTimer(float time) {
                endTime -= time;
                if (endTime < 0) {
                    action?.Invoke();
                    if (timerManager != null) {
                        timerManager.releaseFromPool(this);
                    }
                }
            }

            public void resetTimer() {
                endTime = 0;
                action = null;
                timerManager = null;
            }
        }
    }
}