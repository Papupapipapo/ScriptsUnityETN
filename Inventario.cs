using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario
{
    public List<GameObject> _gameObjects = new List<GameObject>();
    public int indexItem = 0;
    // Start is called before the first frame update

    public void AddNewObject( GameObject _tempObject){ //Añadir objeto
        _gameObjects.Add(_tempObject);
    }
    public void RemoveObject( GameObject _tempObject){ //Añadir objeto
        _gameObjects.Remove(_tempObject);
    }
    public GameObject previousItem(){ //Mira objeto previo i si outofbounds vuelve al final
        if(currentLength() >= 0){
            if(indexItem > 0 ){
                indexItem--;
            }else{  
                indexItem = currentLength();
            }
        }
        return ElementIndex();
    }

    public GameObject nextItem(){ //Mira objeto siguiente i si outofbounds vuelve al final
        if(currentLength() >= 0){
            
            if(indexItem < currentLength()){
                indexItem++;
            }else{ 
                indexItem = 0;
            }
        }
        return ElementIndex();
    }

    private GameObject ElementIndex(){
        return _gameObjects[indexItem];
        
    }

    public int currentLength(){
        return _gameObjects.Count - 1 ;
    }
}
