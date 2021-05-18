using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textoExplicativoPuerta : TextoExplicativo
{
    
    Puerta puertaScript;
    protected override void Start()
    {
        base.Start();
        puertaScript = this.gameObject.GetComponent<Puerta>();
    }

    protected override void OnMouseOver()
    {
        if(puertaScript.locked){
            str = "Puerta cerrada, encuentra la llave y pulsa [E]";
            textHandler.ActualizarTexto(str);
            return;
        }
        str = "Pulsa [E] para abrir la puerta";
        textHandler.ActualizarTexto(str);
    }
}
