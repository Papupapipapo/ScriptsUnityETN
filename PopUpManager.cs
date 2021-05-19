using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    protected EditarTexto textHandler;
    float timeShown = 0;
    protected PopUpManager popUpM;
    private Coroutine currentCoroutine = null;
    protected virtual void Start(){
        textHandler = GameObject.Find("Canvas").GetComponent<EditarTexto>();
        popUpM = GameObject.Find("Canvas").GetComponent<PopUpManager>();
    }
    
    public void ShowMessage(string txt,float timeToShow){
        textHandler.ActualizarTexto(txt);
        Invoke("clearText", timeToShow);
    }
    void clearText(){
        textHandler.ActualizarTexto("");
    }
    protected virtual IEnumerator ShowMessageCoroutine(string txt,float timeToShow = 3)
    {
    textHandler.ActualizarTexto(txt);
    while (timeShown < timeToShow)
     {
         timeShown += Time.deltaTime;
         yield return null;
     }
    textHandler.ActualizarTexto("");
    StopCoroutine(currentCoroutine);
    }
}
