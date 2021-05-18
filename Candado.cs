using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candado : MonoBehaviour
{
    public int num1;
    public int num2;
    public int num3;
    public int num4;

    void Awake()//Randomizer
    {
        num1 = Random.Range(1, 9);
        num2 = Random.Range(1, 9);
        num3 = Random.Range(1, 9);
        num4 = Random.Range(1, 9);
    }

    void Start(){ //NUMEROS
        GameObject.Find("Numero1").GetComponent<Renderer>().material =  Resources.Load("Numeros/Materials/" + num1, typeof(Material)) as Material;
        GameObject.Find("Numero2").GetComponent<Renderer>().material =  Resources.Load("Numeros/Materials/" + num2, typeof(Material)) as Material;
        GameObject.Find("Numero3").GetComponent<Renderer>().material =  Resources.Load("Numeros/Materials/" + num3, typeof(Material)) as Material;
        GameObject.Find("Numero4").GetComponent<Renderer>().material =  Resources.Load("Numeros/Materials/" + num4, typeof(Material)) as Material;
    }
}
