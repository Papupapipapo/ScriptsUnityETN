using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyAxe : PopUpManager
{
     
    //Un text que apareixerá si el jugador vol saltarse el nivell
    protected void OnDestroy(){
        popUpM.ShowMessage("Apreta el boton raton izq. para atacar",3);
    }
}
