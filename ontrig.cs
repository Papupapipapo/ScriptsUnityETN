using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ontrig : MonoBehaviour
{
    //Al atacar s'activa aquest script i comprova que si el collider que té la hacha es choca amb alguna valla, si ho fa el trenca
    public float breakForce = 3f;
    private Collider ownColl;

    void Awake(){
        ownColl = this.gameObject.GetComponent<Collider>();
    }
     void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag != "Valla"){
            return;
        }
        GameObject broken = Resources.Load("Enviroment/Destructible/Broken Tablon") as GameObject;
        Instantiate(broken, other.transform.position,other.transform.rotation);
        
        Destroy(other.gameObject);
        foreach(Rigidbody rb in broken.GetComponentsInChildren<Rigidbody>()){
            Vector3 force = (rb.transform.position - transform.position).normalized * breakForce;
            rb.AddForce(force);
        }
        this.enabled = false;
        ownColl.enabled = false;
    }
}
