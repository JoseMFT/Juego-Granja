using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager: MonoBehaviour {
    // Start is called before the first frame update
    public GameObject creationMenu, objectTree, objectTractor, objectStone, objectPlant, selectedObject, newObject;
    public CanvasGroup ImageCreationMenu;

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
        LeanTween.moveLocalX (creationMenu, -1000f, 0f);
        creationMenu.SetActive (false);
        LeanTween.alphaCanvas (ImageCreationMenu, 0f, 0f);
    }

    // Update is called once per frame
    void Update () {

        switch (currentState) {

            case StateSelector.Create:
                LeanTween.alphaCanvas (ImageCreationMenu, 0.6078f, 0.5f).setEaseInCubic ();
                creationMenu.SetActive (true);
                LeanTween.moveLocalX (creationMenu, -730f, 1f).setEaseInBounce ();
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
            Ray moveRay = Camera.main.ScreenPointToRay (mousePos);
            RaycastHit hitInfo;
            newObject = selectedObject;
            selectedObject = null;
            Instantiate (newObject);
            newObject.SetActive (false);

            if (Physics.Raycast (moveRay, out hitInfo) == true) {
                newObject.transform.position = hitInfo.point + Vector3.up * selectedObject.transform.localScale.y / 2f;
            }

            selectedObject.SetActive (true);

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
        LeanTween.moveLocalX (creationMenu, -1000, 1f).setEaseOutCubic ().setOnComplete (MenuFalse);
    }

    public void MenuFalse () {
        creationMenu.SetActive (false);
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
