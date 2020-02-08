using System;
using General;
using UnityEngine;

public class TimerManager : MonoBehaviour {
    private ObjectPool<Timer> timerPool;

    public static TimerManager instance = null;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else if (instance != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        timerPool = new ObjectPool<Timer>(10);
    }


    void Update() {
        foreach (var timer in timerPool.getAll()) {
            timer.updateTimer(Time.deltaTime);
        }
    }


    public void releaseFromPool(Timer timer) {
        timer.resetTimer();
        timerPool.release(timer);
    }

    public void startTimer(float time, Action timerEndEvent) {
        Timer timer = timerPool.get();
        timer.Action = timerEndEvent;
        timer.EndTime = time;
        timer.TimerManager = this;
    }
}

public class Timer {
    private float endTime;
    private Action action;
    private TimerManager timerManager;

    public TimerManager TimerManager {
        get => timerManager;
        set => timerManager = value;
    }

    public float EndTime {
        get => endTime;
        set => endTime = value;
    }

    public Action Action {
        get => action;
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