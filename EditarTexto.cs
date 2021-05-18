using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditarTexto : MonoBehaviour
{
    [SerializeField] public Text contador;
    [SerializeField] public Text texto;

    public void ActualizarTexto(string str)
    {
        texto.text = str;
    }

    public void ActualizarReloj(string str)
    {
        contador.text = str;
    }
}
