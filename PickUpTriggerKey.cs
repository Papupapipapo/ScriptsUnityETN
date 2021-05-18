using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpTriggerKey : MonoBehaviour
{
    //Un event al agafar la clau
    GameObject marcoContainer;
    GameObject marco;
    GameObject broken;
    void Start()
    {
        marcoContainer = GameObject.Find("Marco_MaderaIsla");
        marco = marcoContainer.transform.GetChild(0).gameObject;
        broken = marcoContainer.transform.GetChild(1).gameObject;
        Vector3 auxPos = marco.transform.position;

        broken.transform.position = auxPos;
        broken.GetComponent<AudioSource>().Play(0);
        Destroy(marco);
        Destroy(this);
    }
}
