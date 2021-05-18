using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Reload : MonoBehaviour {
	Button btn;
	public string nombreNivel;
	void Start () 
    {
		btn = GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
    {
       	Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
		GameManager.Instance.UnloadLevel(nombreNivel);
        GameManager.Instance.LoadLevel("Finished_Map");
	}
}