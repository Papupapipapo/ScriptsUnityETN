using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    //Un manager general de tot, es molt important i molt util per a persistencia de dades i canviar nivells.
    public GameObject [] SystemPrefabs;

    private string _playerName = "Dummy";
    private string _finalCounter;

    public string PlayerName{
        get => _playerName;
        set => _playerName = value;
    }

    public string FinalCounter{
        get => _finalCounter;
        set => _finalCounter = value;
    }

    private string _currentlevelName = string.Empty;

    List<AsyncOperation> _loadOperations;
    List<GameObject> _instancedSystemPrefabs;
    // Start is called before the first frame update
    private void Start()
    {
        _instancedSystemPrefabs = new List<GameObject>();
        _loadOperations = new List<AsyncOperation>();
          
        DontDestroyOnLoad(gameObject);
        InstantiateSystemPrefabs();
       
    }
    void OnLoadOperationComplete(AsyncOperation ao)
    {
        if(_loadOperations.Contains(ao)){
            _loadOperations.Remove(ao);
        }
        Debug.Log("Load Complete");
    }
    void OnUnloadOperationComplete(AsyncOperation ao)
    {
        Debug.Log("UnLoad Complete");
    }

    void InstantiateSystemPrefabs(){
        GameObject prefabInstance;
        for(int i = 0; i < SystemPrefabs.Length;++i){
            prefabInstance = Instantiate(SystemPrefabs[i]);
            _instancedSystemPrefabs.Add(prefabInstance);
        }
    }
    public void LoadLevel(string levelName){
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        if(ao == null){
            Debug.LogError("[GameManager] Couldn't load level " + levelName);
            return;
        }
        ao.completed += OnLoadOperationComplete;
        _loadOperations.Add(ao);
        _currentlevelName = levelName;
    }

    public void UnloadLevel(string levelName){
        AsyncOperation ao = SceneManager.UnloadSceneAsync(levelName );
        ao.completed += OnUnloadOperationComplete;
    }

    protected override void OnDestroy(){
        base.OnDestroy();

        for(int i = 0; i < _instancedSystemPrefabs.Count;i++){
            Destroy(_instancedSystemPrefabs[i]);
        }
        _instancedSystemPrefabs.Clear();
    }

    public void loadDeath()
    {
       UnloadLevel("Finished_Map");
       LoadLevel("Perder");
       Cursor.lockState = CursorLockMode.None;
       Cursor.visible = true;
    }
}
