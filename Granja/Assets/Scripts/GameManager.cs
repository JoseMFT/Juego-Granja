using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager: MonoBehaviour {
    // Start is called before the first frame update
    public GameObject creationMenu, mainMenu, cameraMessage;

    void Start () {
        LeanTween.moveLocalX (creationMenu, -1300f, 0f);
    }

    // Update is called once per frame

    public void ClickedCreate () {
        LeanTween.moveLocalX (creationMenu, -730f, 1f).setEaseOutBounce ();
        LeanTween.moveLocalY (mainMenu, -110f, 1f).setEaseInCubic ();
        Debug.Log ("Clicked create");
    }

    public void ClickedCamera () {
        LeanTween.moveLocalY (cameraMessage, 110, 1f).setEaseOutBounce ();
        LeanTween.moveLocalY (mainMenu, -110f, 1f).setEaseInCubic ();

        Debug.Log ("Clicked camera");
    }

    public void ClickedEscape () {
        LeanTween.moveLocalX (creationMenu, -1300, 1f).setEaseOutCubic ().setOnComplete (() => {
            LeanTween.moveLocalY (mainMenu, 110f, 1f).setEaseInCubic ();
        });

    }

}
