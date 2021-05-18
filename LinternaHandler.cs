using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinternaHandler : MonoBehaviour
{
    Light luzLinterna;
    public bool hayLuz = false;
    SC_FPSController playerController;
    public float contador = 0;
    public int pilasDisponibles = 0;
    public int vidaPorPila = 50;
    Text displayBaterias;
    // Start is called before the first frame update
    void Awake(){
        playerController = this.gameObject.GetComponent<SC_FPSController>();
        displayBaterias = GameObject.Find("Canvas").transform.GetChild(4).GetChild(1).GetChild(2).gameObject.GetComponent<Text>();
    }
    void Start()
    {
        luzLinterna = GameObject.Find("Luz Linterna").GetComponent<Light>();
       
        GameObject.Find("Canvas").GetComponent<Barras>().enabled = true;
    }

    void Update(){
    if(!luzLinterna.enabled && !hayLuz) //No tiene luz
        {
            if(contador > 0.75f)
            {
                if(getVida() > 0)
                {
                    setVida(-2);
                }
                contador = 0f;
            }
            else
            {
                contador += 1 * Time.deltaTime;
            }
        }
        else //Tiene luz
        {
            if(contador > 1f)
            {
                if(getVida() < 100)
                {
                   setVida(1);
                }
                contador = 0f;
            }
            else
            {
                contador += 1 * Time.deltaTime;
            }
        }

        if(getVida() == 0)
        {
            GameManager.Instance.loadDeath();
        }
    }
       
    void setVida(int vidaAdicional){
        playerController.vida += vidaAdicional;
    }
    int getVida(){
        return playerController.vida;
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Water")
        {
            playerController.walkingSpeed = 1f;
            playerController.runningSpeed = 2.5f;
        }
        else if(other.gameObject.tag == "Luz")
        {
            hayLuz = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Water")
        {
            playerController.walkingSpeed = 18f;
            playerController.runningSpeed = 28f;
        }
        else if(other.gameObject.tag == "Luz")
        {
            hayLuz = false;
        }
    }

    //BATERIA SISTEMA
    public void addBateria(){
        pilasDisponibles++;
        updateText();
    }
    public bool hasBateria(){
        return pilasDisponibles > 0;
    }

    public void quitarBateria(){
        pilasDisponibles--;
        updateText();
    }
    void updateText(){
        displayBaterias.text = pilasDisponibles.ToString();
    }
}
