using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class buttonSubclassOVerride : Button, IPointerDownHandler
{
    //Botó que fara que el boto es fagi pantalla sencera, carrega nivell i arregla ratoli.
    public override void OnPointerDown (UnityEngine.EventSystems.PointerEventData eventData)
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Screen.fullScreen = !Screen.fullScreen;
        GameManager.Instance.LoadLevel("Finished_Map");
        gameObject.transform.parent.parent.gameObject.SetActive(false);
    }
}
