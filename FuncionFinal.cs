using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class FuncionFinal : MonoBehaviour
{
    private string record;
    private string player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.Instance.PlayerName;
        record = GameManager.Instance.FinalCounter;

        gameObject.GetComponent<Text>().text = player + ": Tu record es " + record + "!";

        if(player != "Anonimo")
        {
            StartCoroutine(GetRequest("https://hotelelectric.cat/UnityProject/Utilities/insertarRecord.php?Jugador="+player+"&Record="+record));
        }
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
        }
    }
}
