using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handHandler : MonoBehaviour
{
    private GameObject hand;
    private GameObject handL;
    private GameObject handKey;
    private handActions handAction;
    private RayCastHandler rayCastH;
    private RayCast2 rayCastAux;
    private InventarioHandler inventarioHandler;
    private LinternaHandler linternaH;
    
    // Start is called before the first frame update
   void Awake() //Fem cache de objectes que podrem voler tenir
    {
        hand =  GameObject.FindGameObjectsWithTag("Hand")[0];
        handL =  GameObject.FindGameObjectsWithTag("HandL")[0];
        handAction =  GetComponent<handActions>();
        rayCastAux = GetComponent<RayCast2>();
        inventarioHandler = GetComponent<InventarioHandler>();
        linternaH = GetComponent<LinternaHandler>();
        
    }

    public void checkSwitchInteract(GameObject obj){ //Funcio que li donem un gameobject el cual el jugador pot mirar i li diem que comprovi quin d'aquests es
        switch(obj.tag){
            case "Llave":
                Destroy(obj);
                instanceObjectHand("HandKey");
                auxEnableKey();
                break;
             case "Llave_Antigua":
                Destroy(obj);
                instanceObjectHand("HandKey2");
                auxEnableKey();
                break;
            case "Hacha":
                Destroy(obj);
                instanceObjectHand("HachaDefHand");
                break;
            case "Linterna":
                Destroy(obj);
                instanceObjectHandL("Linterna");
                break;
            case "Pilas":
                Destroy(obj);
                linternaH.addBateria();
                break;
            case "Puerta":
                auxEnable();
                rayCastAux.puerta(obj);
                break;
            case "Cifra":
                auxEnable();
                rayCastAux.cifra(obj);
                break;
        }
    }
    
    public void auxEnable () {
        rayCastAux.enabled = true;
    }
    public void auxEnableKey () {
        rayCastAux.enabled = true;
        foreach (Transform child in hand.transform) {
            if(child.gameObject.tag.Contains("Key")){
                 rayCastAux.keyId = child.gameObject.tag;
            }
        }
    }
    void instanceObjectHand(string nameObject){ //Posa un prefab que li demanem amb la orientacio i posició correcte a la má del jugador
        handAction.enabled = true;
        if(inventarioHandler.enabled == false){
            inventarioHandler.enabled = !inventarioHandler.enabled;
        }

        foreach (Transform child in hand.transform) {
           
           child.gameObject.SetActive(false);
        }
        
        handKey = Instantiate(Resources.Load("HandItems/" + nameObject)) as GameObject; //Resources.Load mira dins de la carpeta resources i afegeix un prefab
        inventarioHandler.addObject(handKey);
        handKey.transform.SetParent(hand.transform, false); //Fa que el scale no es trenqui
        handKey.transform.parent = hand.transform; //Otorga padre
        handKey.transform.position = hand.transform.position;
        handKey.transform.rotation = hand.transform.rotation;
    }

    void instanceObjectHandL(string nameObject){ //Posa un prefab que li demanem amb la orientacio i posició correcte a la má del jugador
        this.gameObject.GetComponent<LinternaHandler>().enabled = true;
        
        handKey = Instantiate(Resources.Load("HandItems/" + nameObject)) as GameObject; //Resources.Load mira dins de la carpeta resources i afegeix un prefab
        
        handKey.transform.SetParent(handL.transform, false); //Fa que el scale no es trenqui
        handKey.transform.parent = handL.transform; //Otorga padre
        handKey.transform.position = handL.transform.position;
        handKey.transform.rotation = handL.transform.rotation;
    }
    public void clearHand(){ //Agafa tots els fills de la má i els borra, solament será un normalment
        foreach (Transform child in hand.transform) {
           
            GameObject.Destroy(child.gameObject);
        }
        this.enabled = false;
        handAction.enabled = false;
    }
}
