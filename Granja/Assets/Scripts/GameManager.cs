using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager: MonoBehaviour {
    // Start is called before the first frame update
    public GameObject creationMenu, objectTree, objectTractor, objectStone, objectPlant, selectedObject, newObject;

    public enum StateSelector {
        Create,
        CameraMove,
        Idle,
    }

    public enum CreationSelector {
        None,
        Tree,
        Tractor,
        Stone,
        Plant,
        Wait,
    }

    StateSelector currentState = StateSelector.Idle;
    CreationSelector selectedOption = CreationSelector.None;

    void Start () {
        LeanTween.moveLocalX (creationMenu, -1300f, 0f);
    }

    // Update is called once per frame
    void Update () {

        switch (currentState) {

            case StateSelector.Create:
                LeanTween.moveLocalX (creationMenu, -730f, 0.75f).setEaseOutBounce ();
                break;

            case StateSelector.CameraMove:
                CameraMovement ();
                break;

            case StateSelector.Idle:
                break;
        }

        switch (selectedOption) {

            case CreationSelector.None:
                selectedObject = null;
                break;

            case CreationSelector.Tree:
                selectedObject = objectTree;
                selectedOption = CreationSelector.Wait;
                break;

            case CreationSelector.Tractor:
                selectedObject = objectTractor;
                selectedOption = CreationSelector.Wait;
                break;

            case CreationSelector.Stone:
                selectedObject = objectStone;
                selectedOption = CreationSelector.Wait;
                break;

            case CreationSelector.Plant:
                selectedObject = objectPlant;
                selectedOption = CreationSelector.Wait;
                break;

            case CreationSelector.Wait:
                CreatedObject ();
                break;


        }

        void CameraMovement () {

            if (Input.GetMouseButtonUp (0)) {
                Vector2 mousePos = Input.mousePosition;
                Vector2 mouseDelta = mousePos - (Vector2) Input.mousePosition;
                Camera.main.transform.position = new Vector3 (mouseDelta.x, Camera.main.transform.position.y, mouseDelta.y);
                if (Input.GetMouseButtonUp (0)) {
                    currentState = StateSelector.Idle;
                }
            }
        }

        void CreatedObject () {
            Vector2 mousePos = Input.mousePosition;
            Ray detectRay = Camera.main.ScreenPointToRay (mousePos);
            RaycastHit hitInfo;
            newObject = selectedObject;
            selectedObject = null;
            Instantiate (newObject);
            newObject.SetActive (false);

            if (Physics.Raycast (detectRay, out hitInfo) == true) {
                Ray newRay = Camera.main.ScreenPointToRay (mousePos);
                RaycastHit hitInfoTwo;

                newObject.transform.position = hitInfo.point + Vector3.up * selectedObject.transform.localScale.y / 2f;
            }

            newObject.SetActive (true);

            if (Input.GetMouseButtonUp (0)) {
                selectedOption = CreationSelector.None;

            }
        }
    }
    public void ClickedCreate () {
        currentState = StateSelector.Create;
        Debug.Log ("Clicked create");
    }

    public void ClickedCamera () {
        currentState = StateSelector.CameraMove;
        Debug.Log ("Clicked camera");
    }

    public void ClickedEscape () {
        LeanTween.moveLocalX (creationMenu, -1300, 1f).setEaseOutCubic ();
    }

    public void ClickedTree () {
        selectedOption = CreationSelector.Tree;
    }

    public void ClickedTractor () {
        selectedOption = CreationSelector.Tractor;
    }

    public void ClickedStone () {
        selectedOption = CreationSelector.Stone;
    }

    public void ClickedPlant () {
        selectedOption = CreationSelector.Plant;
    }


}
