using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handActions : MonoBehaviour
{
    //Les accions que pot fer la má
    private GameObject hand;
    private int childrenCountHand;
    private GameObject child;
    public Animator anim;
    // Start is called before the first frame update
    void Awake()
    {
        hand =  GameObject.FindGameObjectsWithTag("Hand")[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){ //Al apretar el ratoli esq mirara el que te a la má i quina acció fará
            childrenCountHand = hand.transform.childCount; //Desactivado dado que ya no puede pasar este bug
            if(hand.transform.childCount == 0){
                return;
            } 
            checkObject();
        }
    }

    void checkObject(){ //Mira quin es el objecte que tenim a la má
        child = hand.transform.GetChild(0).gameObject;
        switch(child.tag){
            case "Hacha":
            if(anim == null){
                anim = child.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Animator>();
            }
                attacc();
                break;
        }
    }

    void attacc(){ //Fa animació de atacar
      
       anim.SetTrigger("Misco");
    }
}
