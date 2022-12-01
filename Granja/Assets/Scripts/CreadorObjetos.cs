/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreadorObjetos: MonoBehaviour {

    public GameObject objetoACrear;
    GameObject objetoRecienCreado;

    [SerializeField]
    GameManager controller;

    public void SetObjetoACrear (GameObject prefab) {
        objetoACrear = prefab;
        controller.ClickedEscape ();
    }

    private void OnEnable () {
        objetoRecienCreado = Instantiate (objetoACrear);
        objetoRecienCreado.transform.position = hitInfo.point + Vector3.up + 2f;

    }
    private void Update () {

        if (Input.GetMouseButtonUp (0)) {


        } else {

            if (Input.GetMouseButton (0)) {

                Ray rayo = Camera.main.ScreenPointToRay (Input.mousePosition);
                RaycastHit hitInfo;
            }
        }
    }
}
*/
