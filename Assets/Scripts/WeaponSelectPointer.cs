using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelectPointer : MonoBehaviour
{

    public Player player;

    void Start(){

        

    }

    public void MoveToTarget(GameObject target){

        if(Time.timeScale != 0 && player.isReloading == false){

            gameObject.transform.position = new Vector3(target.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        
        }

        


    }

}
