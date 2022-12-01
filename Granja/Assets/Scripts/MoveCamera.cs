using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera: MonoBehaviour {
    // Start is called before the first frame update
    Vector3 oldMousePosition;

    void Start () {
        oldMousePosition = Input.mousePosition;
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetMouseButton (0)) {
            ActionMoveCamara ();
        }

        oldMousePosition = Input.mousePosition;
    }

    void ActionMoveCamara () {
        Vector3 deltaPos = oldMousePosition - Input.mousePosition;
        Camera.main.transform.position += new Vector3 (deltaPos.x, 0.0f, deltaPos.y);
        /*if (Input.GetMouseButtonUp (0)) {
            gameObject.GetComponent<MoveCamera>.enabled (false);
        }*/

    }
}


