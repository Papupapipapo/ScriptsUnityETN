using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyFlash : PopUpManager
{
     
    //Un text que apareixerÃ¡ si el jugador vol saltarse el nivell
    protected void OnDestroy(){
        popUpM.ShowMessage("Apreta [F] para encender la linterna",3);
        
    }
}
