using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextoExplicativo : MonoBehaviour
{
    protected EditarTexto textHandler;
    protected RayCast2 ray;
    protected string str;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        textHandler = GameObject.Find("Canvas").GetComponent<EditarTexto>();
        ray = GameObject.Find("pauPlayer").GetComponent<RayCast2>();
    }

    // Update is called once per frame
    protected virtual void OnMouseOver()
    {
        str = "Pulsa [E] para interactuar con " + this.gameObject.tag;
        textHandler.ActualizarTexto(str);
    }

    protected virtual void OnMouseExit()
    {
        textHandler.ActualizarTexto("");
    }
}
