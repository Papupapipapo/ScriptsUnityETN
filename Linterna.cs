using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linterna : MonoBehaviour
{
    Light luzLinterna;
    private float contador = 0;
    public int duracion_linterna = 100;
    public int cantidad_bateria_linterna = 50;
    private LinternaHandler linternaH;
    void Start()
    {
        luzLinterna = GameObject.Find("Luz Linterna").GetComponent<Light>();
        linternaH = this.gameObject.transform.parent.transform.parent.transform.parent.GetComponent<LinternaHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) )
        {
            if(duracion_linterna > 0){
                 luzLinterna.enabled = !luzLinterna.enabled;
            }else if(linternaH.hasBateria()){ //Sitema pila
                    linternaH.quitarBateria();
                    duracion_linterna = cantidad_bateria_linterna;
                    luzLinterna.intensity = 3;
                    luzLinterna.enabled = !luzLinterna.enabled;
            }
        }

        

        if(luzLinterna.enabled)
        {
            if(contador > 0.5f)
            {
                duracion_linterna--;
                
                if(duracion_linterna == 0)
                {
                    if(linternaH.hasBateria()){ //Sitema pila
                        linternaH.quitarBateria();
                        duracion_linterna = cantidad_bateria_linterna;
                    }else{
                         luzLinterna.enabled = false;
                    }
                   
                }
                else if(duracion_linterna < 50 && luzLinterna.intensity != 1.5f)
                {
                    StartCoroutine("LuzParpadea");
                    luzLinterna.intensity = 1.5f;
                }
                else if(duracion_linterna < 10)
                {
                    StartCoroutine("LuzParpadea");
                }

                contador = 0f;
            }
            else
            {
                contador += 1 * Time.deltaTime;
            }
        }
    }

    IEnumerator LuzParpadea()
    {
        luzLinterna.enabled = !luzLinterna.enabled;
        yield return new WaitForSeconds(0.1f);
        luzLinterna.enabled = !luzLinterna.enabled;
        yield return new WaitForSeconds(0.4f);
        luzLinterna.enabled = !luzLinterna.enabled;
        yield return new WaitForSeconds(0.01f);
        luzLinterna.enabled = !luzLinterna.enabled;

    }
}
