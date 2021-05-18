using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public static void LoadLevel(string level)
    {
        // Load the level named "HighScore".
        GameManager.Instance.LoadLevel(level);
    }
}
