using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class Salir : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void CambiarURL();

    Button btn;

	void Start() 
    {
		btn = GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
    {
        CambiarURL();
	}
}
