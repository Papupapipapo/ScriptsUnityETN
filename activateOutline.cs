using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateOutline : MonoBehaviour
{
    //Per als materials amb outline li fará que si els mira se dibuixi la linea i es borri al sortir
    private Component[] _renderChildren;
    public float firstWidth;
    public float secondWidth;
    private EditarTexto textHandler;
    // Start is called before the first frame update
    void Start(){
        _renderChildren = GetComponentsInChildren<Renderer>();
        textHandler = GameObject.Find("Canvas").GetComponent<EditarTexto>();
    }
    void OnMouseOver() //Al estar al damunt
    {
        foreach (Renderer r in _renderChildren){
            r.material.SetFloat("_FirstOutlineWidth",firstWidth);
            r.material.SetFloat("_SecondOutlineWidth",secondWidth);
        }
        string str = "Pulsa [E] para coger " + this.gameObject.tag;
        textHandler.ActualizarTexto(str);
    }
    void OnMouseExit() //Al sortir
    {
        unloadOutline();
        textHandler.ActualizarTexto("");
    }
    
    void OnDestroy(){ //Per si hi ha mes instancies d'aquest objecte
        unloadOutline();
        textHandler.ActualizarTexto("");
    }

    void unloadOutline(){
        foreach (Renderer r in _renderChildren){
            r.material.SetFloat("_FirstOutlineWidth",0);
            r.material.SetFloat("_SecondOutlineWidth",0);
        }
    }
}
