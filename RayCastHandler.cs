using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastHandler : MonoBehaviour
{
    //Aqui aguanta el usuari interactuar amb objectes
    private Camera camera;
    private handHandler  handHandler;

    // Start is called before the first frame update
    void Awake()
    {
        camera = Camera.main;
        handHandler = GetComponent<handHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            getObject();
        }
    }

    void getObject(){ //Mir a aon esta mirant el usuari i si dona algun collider i si el collider te tag doncs pasarem al script comprovant
        Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)){
             if(hit.collider != null){
                if(hit.transform.gameObject.tag != null){
                    handHandler.enabled = true;
                    handHandler.checkSwitchInteract(hit.transform.gameObject);
                }
             }
        }
    }
}
