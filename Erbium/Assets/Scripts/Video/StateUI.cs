using System;
using System.Collections;
using System.Collections.Generic;
using Characters.Movement;
using UnityEngine;
using UnityEngine.UI;

public class StateUI : MonoBehaviour {
    [SerializeField] private Image groundImage;
    [SerializeField] private Image midairImage;
    [SerializeField] private Image crouchImage;
    [SerializeField] private Image slideImage;
    [SerializeField] private Image attackImage;
    [SerializeField] private Color primaryColor;
    [SerializeField] private Color secondlyColor;


    private void Start() {
        changeColorByDefault();
        groundImage.color = primaryColor;
    }

    public void changeColor(MovementEnum movementEnum) {
        changeColorByDefault();
        switch (movementEnum) {
            case MovementEnum.Ground:
                groundImage.color = primaryColor;
                break;
            case MovementEnum.Midair:
                midairImage.color = primaryColor;
                break;
            case MovementEnum.Crouch:
                crouchImage.color = primaryColor;
                break;
            case MovementEnum.Slide:
                slideImage.color = primaryColor;
                break;
            case MovementEnum.Attack:
                attackImage.color = primaryColor;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(movementEnum), movementEnum, null);
        }
    }

    private void changeColorByDefault() {
        groundImage.color = secondlyColor;
        midairImage.color = secondlyColor;
        crouchImage.color = secondlyColor;
        slideImage.color = secondlyColor;
        attackImage.color = secondlyColor;
    }
}
