using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarioHandler : MonoBehaviour
{
    //Sistema d'inventari per al jugador
    private GameObject hand;
    private Inventario inventarioPlayer = new Inventario();

    // Start is called before the first frame update
    void Start()
    {
        hand =  GameObject.FindGameObjectsWithTag("Hand")[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f ) // forward
        {
            nextItem();
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f ) // backwards
        {
            changeObject(inventarioPlayer.previousItem());
        }
    }

    public void addObject(GameObject objActual){
        inventarioPlayer.AddNewObject(objActual);
    }
    public void removeObject(GameObject objActual){
        inventarioPlayer.RemoveObject(objActual);
    }
    public void nextItem(){
        if(inventarioPlayer.currentLength() != -1){
            changeObject(inventarioPlayer.nextItem());
        }else{
            this.enabled = false;
        }
    }
    void changeObject(GameObject objActual)
    {
        clearHand();
         foreach (Transform child in hand.transform) {
           if(child.gameObject.tag  == objActual.tag){
                child.gameObject.SetActive(true);
           }
        }
        
    }

    void clearHand(){
        foreach (Transform child in hand.transform) {
            child.gameObject.SetActive(false);
        }
    }
}
