using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpTriggerLantern : MonoBehaviour
{
    // Event que pasa al agfar la lanterna que apaga tot i una barrera invisble
    void Start()
    {
        foreach (GameObject light in GameObject.FindGameObjectsWithTag("Luz")){
           if(light.name == "LuzFarola") light.SetActive(false);
        }
        Destroy(GameObject.Find("ColliderForDummies"));
        Destroy(this);
    }
}
