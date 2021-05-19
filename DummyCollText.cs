using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyCollText : PopUpManager
{
    protected virtual void OnTriggerEnter(Collider Other){
        if(Other.transform.gameObject.tag == "Player")
            popUpM.ShowMessage("Esta muy oscuro, creo que he visto una linterna cerca de la fuente",3);
    }

    
}
