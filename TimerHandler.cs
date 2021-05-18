using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class TimerHandler : MonoBehaviour
{
    private EditarTexto textHandler;
    private int segundos = 0;
    private int minutos = 0;
    private int horas = 0;
    private float contador = 0;

    void Start()
    {
        textHandler = GameObject.Find("Canvas").GetComponent<EditarTexto>();
    }

    // Update is called once per frame
    void Update()
    {
        if(contador > 1f)
        {
            segundos += (int)Math.Round(contador);
            if(segundos == 60)
            {
                minutos++;
                segundos = 0;
            }
             if(minutos == 60)
            {
                horas++;
                minutos = 0;
            }

            string timer = (horas < 10 ? "0" : "") + horas.ToString() + ":" + (minutos < 10 ? "0" : "") + minutos.ToString() + ":" + (segundos < 10 ? "0" : "") + segundos.ToString();

            textHandler.ActualizarReloj(timer);
            contador = 0f;
        }
        else
        {
            contador += 1 * Time.deltaTime;
        }
    }
}
