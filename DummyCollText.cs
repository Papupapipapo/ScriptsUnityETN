using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyCollText : MonoBehaviour
{
    //Un text que apareixerá si el jugador vol saltarse el nivell
    protected EditarTexto textHandler;
    float timeShown = 0;
    protected void Start(){
        textHandler = GameObject.Find("Canvas").GetComponent<EditarTexto>();
    }
    protected void OnTriggerEnter(Collider Other){
        if(Other.transform.gameObject.tag == "Player")
            StartCoroutine(ShowMessageCoroutine(3));
    }

    IEnumerator ShowMessageCoroutine(float timeToShow = 3)
    {
    textHandler.ActualizarTexto("Esta muy oscuro, creo que he visto una linterna cerca de la fuente");
    while (timeShown < timeToShow)
     {
         timeShown += Time.deltaTime;
         yield return null;
     }
    textHandler.ActualizarTexto("");
    }
}
