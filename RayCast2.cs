using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast2 : MonoBehaviour
{
    public bool ejecutando;
    private handHandler  handHandler;
    private handActions handAction;
    private GameObject candado; //Guarda el objecto Candado el cual contiene los child de los cifrados
    private Vueltas vueltasActualobj; //Script que controla las vueltas del cifrado actual
    private Vueltas [] vueltasHandler = new Vueltas [4]; //Contiene los hijos del candado, osea los cifrados
    private Candado candadoHandler; //Script del candado para saber cifrado correcto
    private int [] cifraActual; //Int de array de todos los numeros que tenemos
    private string combFinal; //Combinacion final 
    public string keyId = string.Empty; //Quina clau te
    private InventarioHandler inventarioHandler; 

    // Start is called before the first frame update
    void Awake(){
        handHandler = GetComponent<handHandler>();
        handAction = GetComponent<handActions>();
        inventarioHandler = GetComponent<InventarioHandler>();
    }
    void Start()
    {
        cifraActual = new int [4];
        ejecutando = false; 
        candado = GameObject.Find("Candado");
        candadoHandler = candado.GetComponent<Candado>();
        combFinal = candadoHandler.num1.ToString() + candadoHandler.num2.ToString() + candadoHandler.num3.ToString() + candadoHandler.num4.ToString();
        
        for(int i = 0; i <vueltasHandler.Length; i++){
            vueltasHandler[i] =  candado.transform.GetChild(i).GetComponent<Vueltas>();
        }
    }

    public void puerta( GameObject objHit){
            Puerta puertaScript = objHit.GetComponent<Puerta>();
            door = objHit.transform.parent.gameObject.transform;

            if(puertaScript.locked){
                if(keyId == string.Empty){
                    return;
                }
                if(!puertaScript.keyTag.Contains(keyId)){    //Es el tag esperat per aquesta porta
                    return;
                }
                clearHandObj();
                keyId = string.Empty;
                puertaScript.locked = false;
            }

            if(puertaScript.cerrada)
            {
                StartCoroutine("OpenDoor");
            }
            else
            {
                StartCoroutine("CloseDoor");
            }
            
            puertaScript.cerrada = !puertaScript.cerrada;
            this.enabled = false;
    }

    void clearHandObj(){
            foreach (Transform child in this.gameObject.transform.GetChild(1).GetChild(0).gameObject.transform) {
                    if(child.gameObject.tag == keyId){
                        inventarioHandler.removeObject(child.gameObject);
                        GameObject.Destroy(child.gameObject);
                        inventarioHandler.nextItem();
                    }
                        
                }
    }

    public void cifra( GameObject objHit){
         //Cogemos la Animacion que hara que rote el numero
                Animator anim = objHit.GetComponent<Animator>();
                vueltasActualobj = objHit.GetComponent<Vueltas>();
                //Si no se esta ejecutando, ejecutamos la animacion y sumamos vuelta y comprobamos numeros
                if(!ejecutando)
                {
                    anim.SetTrigger("Input");
                    vueltasActualobj.vuelta++;

                    if(vueltasActualobj.vuelta == 10)//Si llega a 10 reseteamos el numero
                    {
                        vueltasActualobj.vuelta = 1;
                    }

                    //Recogemos los numeros y los comparamos

                    for(int i = 0; i < cifraActual.Length; i++){
                        cifraActual[i] = vueltasHandler[i].vuelta;
                    }

                    string combActual = returnCombinacion(cifraActual);

                   /*  //Desarollar
                    Debug.Log(combActual);
                    Debug.Log(combFinal); */

                    if(combActual == combFinal)
                    {
                        GameObject.Find("Porton").transform.GetChild(0).GetComponent<Animator>().SetTrigger("Abrir");
                    }
                }
                this.enabled = false;
    }

    private string returnCombinacion(int[] arr){
        string combinacion = "";
         for(int i = 0; i < arr.Length; i++){
             combinacion +=  arr[i].ToString();
         }
         return combinacion;
    }

    public Transform door; 
    public float endRotation; 
    public float startRotation; 
    public float speed;
    IEnumerator OpenDoor ()
    {
        while (door.transform.rotation.y < endRotation)
        {
            door.Rotate(0, -speed * Time.deltaTime, 0);
            yield return null;
        }
    }

    IEnumerator CloseDoor ()
    {
        while (door.transform.rotation.y > startRotation)
        {
            door.Rotate(0, speed * Time.deltaTime, 0);
            yield return null;
        }
    }
}
