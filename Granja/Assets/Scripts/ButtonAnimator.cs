using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimator: MonoBehaviour {

    bool buttonSmall = true;
    Vector3 originalSize;

    void Start () {
        originalSize = gameObject.transform.localScale;
    }

    public void ScaleButton () {
        buttonSmall = !buttonSmall;

        if (buttonSmall == true) {
            LeanTween.scale (gameObject, originalSize, .2f).setEaseOutCubic (); ;

        } else {
            LeanTween.scale (gameObject, transform.localScale * 1.15f, .2f).setEaseInCubic ();
        }
    }
}