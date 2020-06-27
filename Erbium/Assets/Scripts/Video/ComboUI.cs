using System;
using General;
using UnityEngine;
using UnityEngine.UI;

public class ComboUI : MonoBehaviour {
    [SerializeField] private GameObject firstCombo;
    [SerializeField] private Text textFirst;
    [SerializeField] private GameObject secondCombo;
    [SerializeField] private Text textSecond;
    [SerializeField] private GameObject thirdCombo;
    [SerializeField] private Text textThird;
    [SerializeField] private int counter = 0;
    private readonly string FAST = "FAST";
    private readonly string STRONG = "STRONG";

    private bool remove;
    private float timer;

    private void FixedUpdate() {
        if (remove) {
            timer -= Time.deltaTime;
            if (timer < 0f) {
                remove = false;
                removeCombos();
                timer = 2f;
            }
        }
    }

    public void addCombo(bool fast) {
        counter++;
        string currentCombo = fast ? FAST : STRONG;
        switch (counter) {
            case 1:
                firstCombo.SetActive(true);
                textFirst.text = currentCombo;
                break;
            case 2:
                secondCombo.SetActive(true);
                textSecond.text = currentCombo;
                break;
            case 3:
                thirdCombo.SetActive(true);
                textThird.text = currentCombo;
                break;
            default:
                break;
        }

        if (counter == 3) {
            remove = true;
            counter = 0;
        }
    }

    public void removeCombos() {
        firstCombo.SetActive(false);
        secondCombo.SetActive(false);
        thirdCombo.SetActive(false);
    }
}