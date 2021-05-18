using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barras : MonoBehaviour
{
    SC_FPSController controlador;
    Linterna controlador2;
    GameObject barra;
    GameObject barra2;
    GameObject bateriaContainer;
    // Start is called before the first frame update
    void Start()
    {
        controlador = GameObject.Find("pauPlayer").GetComponent<SC_FPSController>();
        barra = this.transform.GetChild(2).gameObject;
        controlador2 =GameObject.FindGameObjectsWithTag("Linterna")[0].GetComponent<Linterna>();
        bateriaContainer = this.transform.GetChild(4).gameObject;
        barra2 = bateriaContainer.transform.GetChild(0).gameObject;
        bateriaContainer.SetActive(true);
        barra.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        barra.GetComponent<Slider>().value = controlador.vida;
        barra2.GetComponent<Slider>().value = controlador2.duracion_linterna;
    }
}
