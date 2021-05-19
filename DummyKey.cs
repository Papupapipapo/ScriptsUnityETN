using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyKey : PopUpManager
{
     
    //Un text que apareixerá si el jugador vol saltarse el nivell
    protected void OnDestroy(){
        popUpM.ShowMessage("Para cambiar de objeto, usa la rueda del ratón",3);
    }
}
