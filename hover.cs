using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // This is so that it should find the Text component
using UnityEngine.Events; // This is so that you can extend the pointer handlers
using UnityEngine.EventSystems;

public class hover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //Per al texte que surti groc al hover
    // Start is called before the first frame update
    public void OnPointerEnter(PointerEventData eventData) 
    {
        gameObject.GetComponent<Text>().color = Color.yellow; // Changes the colour of the text
    }
 
    public void OnPointerExit(PointerEventData eventData) 
    {
        gameObject.GetComponent<Text>().color = Color.white; // Changes the colour of the text
    }
}
