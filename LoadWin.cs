using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadWin : MonoBehaviour
{
    //Carrega la victoria del jugador
   void OnTriggerEnter(){
       GameManager.Instance.FinalCounter = GameObject.Find("Contador").GetComponent<Text>().text;
       GameManager.Instance.UnloadLevel("Finished_Map");
       GameManager.Instance.LoadLevel("Ganar");
       Cursor.lockState = CursorLockMode.None;
       Cursor.visible = true;
   }
}
