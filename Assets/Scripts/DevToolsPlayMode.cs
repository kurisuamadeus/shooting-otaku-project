using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DevToolsPlayMode : MonoBehaviour
{

    public DebugMenu debugMenu;

    private DebugMenu currValue;

    // Start is called before the first frame update
    void Start()
    {
        currValue = debugMenu;
        debugMenu.speed.normal = true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currValue.speed.fast2x);
        
        if(debugMenu.speed.normal && ValueChanging()){
            
            debugMenu.speed.fast2x = false;
            debugMenu.speed.fast4x = false;
            
            Debug.Log("1test");

        }else if(debugMenu.speed.fast2x && ValueChanging()){

            debugMenu.speed.normal = false;
            debugMenu.speed.fast4x = false;
            
            Debug.Log("2test");

        }else if(debugMenu.speed.fast4x && ValueChanging()){

            debugMenu.speed.normal = false;
            debugMenu.speed.fast2x = false;
            currValue.speed.fast4x = true;
            

        }

        if(ValueChanging()){
            currValue = debugMenu;
        }

        

    }

    bool ValueChanging(){

        if(currValue.speed.normal != debugMenu.speed.normal){
            
            return true;

        }else if(currValue.speed.fast2x != debugMenu.speed.fast2x){

            return true;

        }else if(currValue.speed.fast4x != debugMenu.speed.fast4x){

            return true;

        }else{

            return false;
        }


        
    }

}

[System.Serializable]
public class DebugMenu{

    public Speed speed;


}
[System.Serializable]
public class Speed{

    public bool normal;
    public bool fast2x;
    public bool fast4x;

}
