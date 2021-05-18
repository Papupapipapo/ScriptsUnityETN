using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpTriggerLantern : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject light in GameObject.FindGameObjectsWithTag("Luz")){
           if(light.name == "LuzFarola") light.SetActive(false);
        }
        Destroy(GameObject.Find("ColliderForDummies"));
        Destroy(this);
    }
}
