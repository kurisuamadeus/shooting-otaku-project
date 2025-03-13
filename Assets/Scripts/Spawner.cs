using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public Camera cam;
    public GameObject target;
    public GameObject[] spawnPoint;
    public SpawnList[] targetToSpawn;
    private GameObject spawnedTarget;
    public TimeDisplayHandler timeIndicator;
    public EntityDatabase entityDatabase;

    public bool spawnIsRandom;
    public float 敵率;
    public float spawn率;
    public bool randomSpawnLimiter;
    private int randomTargetID;
    private int spawnCount;
    private Movement random動き;
    private TimeIndicator currTime;
    private TimeIndicator lastSpawn = new TimeIndicator(0,0,0);
    private bool isSpawning;

    
    // public TimeIndicator spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("datalength" + entityDatabase.entityDataList.Length);
    }

    // Update is called once per frame
    void Update()
    {

        if(lastSpawn.minutes != timeIndicator.minutes){
            lastSpawn = new TimeIndicator(0, timeIndicator.minutes, timeIndicator.seconds);
        }

        // if(isSpawning == false){
        //     isSpawning = true;
        //     currTime = new TimeIndicator(0, timeIndicator.minutes, timeIndicator.seconds);
        //     SpawnUpdate();
            
        // }else{

        //     if(currTime.seconds < timeIndicator.seconds || currTime.minutes < timeIndicator.minutes){
        //         isSpawning = false;
        //     }

        // }

        // if(spawnIsRandom && randomSpawnLimiter){

        //     if(timeIndicator.minutes < 1 && (timeIndicator.seconds < lastSpawn.seconds + 5)){

        //     }else if(timeIndicator.minutes < 2 && (timeIndicator.seconds < lastSpawn.seconds + 4)){

        //     }else if(timeIndicator.minutes > 2 && (timeIndicator.seconds < lastSpawn.seconds + 3)){

        //     }else{
        //         SpawnUpdate();
        //         lastSpawn = new TimeIndicator(0, timeIndicator.minutes, timeIndicator.seconds);
        //     }

        // }else if(spawnIsRandom){

        //     if(timeIndicator.seconds < lastSpawn.seconds + 3){

        //     }else{
        //         SpawnUpdate();
        //         lastSpawn = new TimeIndicator(0, timeIndicator.minutes, timeIndicator.seconds);
        //     }

        // }

        if(spawnIsRandom && randomSpawnLimiter &&((timeIndicator.minutes < 1 && (timeIndicator.seconds < lastSpawn.seconds + 5)) ||
            (timeIndicator.minutes < 2 && (timeIndicator.seconds < lastSpawn.seconds + 4)) ||
            (timeIndicator.minutes >= 2 && (timeIndicator.seconds < lastSpawn.seconds + 3))
            )){
                //Debug.Log("here");
                Debug.Log(lastSpawn.minutes + "min " + lastSpawn.seconds + "sec");
                
        }else if((timeIndicator.seconds < lastSpawn.seconds + 2) && randomSpawnLimiter == false && spawnIsRandom){

            Debug.Log(lastSpawn.minutes + "min " + lastSpawn.seconds + "sec");

        }else{

            SpawnUpdate();
            lastSpawn = new TimeIndicator(0, timeIndicator.minutes, timeIndicator.seconds);

        }  

    

        

        
        
    }

    private void SpawnUpdate(){

        if(spawnIsRandom){
                
            RandomSpawn();

        }else{

            for(int i = 0; i < spawnPoint.Length; i++){

                for(int j = 0; j < targetToSpawn.Length; j++){

                    if(targetToSpawn[j].spawnTime.seconds == timeIndicator.seconds 
                    && targetToSpawn[j].spawnTime.minutes == timeIndicator.minutes
                    && targetToSpawn[j].spawnPointID == i
                    && targetToSpawn[j].IsSpawned == false){
                        
                        targetToSpawn[j].IsSpawned = true;
                        spawnedTarget = Instantiate(target, spawnPoint[i].transform.position, target.transform.rotation);
                        Target targetData = spawnedTarget.GetComponent<Target>();
                        
                        targetData.data.Entity名 = entityDatabase.entityDataList[targetToSpawn[j].targetToSpawnID].Entity名;
                        targetData.data.HP = entityDatabase.entityDataList[targetToSpawn[j].targetToSpawnID].HP;
                        targetData.data.タイプ = entityDatabase.entityDataList[targetToSpawn[j].targetToSpawnID].タイプ;
                        targetData.data.速度 = entityDatabase.entityDataList[targetToSpawn[j].targetToSpawnID].速度;
                        targetData.data.動き = targetToSpawn[j].動き;
                        targetData.data.sprite = entityDatabase.entityDataList[targetToSpawn[j].targetToSpawnID].sprite;
                        targetData.data.スコア = entityDatabase.entityDataList[targetToSpawn[j].targetToSpawnID].スコア;
                        
                        Debug.Log(spawnedTarget.transform.position);

                    }

                }

            }
        }
        

    }

    private void RandomSpawn(){

        for(int i = 0; i < spawnPoint.Length; i++){
            

            // if(randomSpawnLimiter){
            //     if(timeIndicator.minutes < 1 && spawnCount >= 2){

            //         Debug.Log("BREAK " + i);
            //         spawnCount = 0;
            //         break;

            //     }else if(timeIndicator.minutes < 2 && spawnCount >= 3){

            //         Debug.Log("BREAK " + i);
            //         spawnCount = 0;
            //         break;

            //     }
            // }else{
            //     if(spawnCount >= Random.Range(3, 5)){
            //         Debug.Log("BREAK " + i);
            //         spawnCount = 0;
            //         break;
            //     }
            // }
            
            if(((timeIndicator.minutes < 1 && spawnCount >= 2) ||
            (timeIndicator.minutes < 2 && spawnCount >= 3) 
            )&& randomSpawnLimiter){
                //Debug.Log("here");
                //Debug.Log(lastSpawn.seconds);
                Debug.Log("BREAK " + i);
                spawnCount = 0;
                break;
            }else if(spawnCount >= Random.Range(2, 5) && randomSpawnLimiter == false){

                Debug.Log("BREAK " + i);
                spawnCount = 0;
                break;

            }


                int randomForSpawnRate = Random.Range(0, 100);
                int randomForEnemySpawn = Random.Range(0, 100);
                Debug.Log(randomForSpawnRate + " XXX " + randomForEnemySpawn + " === " + i);

            if(randomForSpawnRate <= spawn率){

                if(randomForEnemySpawn <= 敵率){

                    do{

                        randomTargetID = Random.Range(0, entityDatabase.entityDataList.Length);
                        Debug.Log("rantargid" + randomTargetID);   

                    }while(entityDatabase.entityDataList[randomTargetID].タイプ != Entityタイプ.敵 && entityDatabase.entityDataList[randomTargetID] != null);

                }else{

                    do{

                        randomTargetID = Random.Range(0, entityDatabase.entityDataList.Length);   
                        Debug.Log("rantargid" + randomTargetID);   

                    }while(entityDatabase.entityDataList[randomTargetID].タイプ != Entityタイプ.一般人 && entityDatabase.entityDataList[randomTargetID] != null);
                }

                spawnedTarget = Instantiate(target, spawnPoint[i].transform.position, target.transform.rotation);
                Target targetData = spawnedTarget.GetComponent<Target>();
                Debug.Log(i);   
                if(spawnedTarget.transform.position.x > 0){
                    random動き = Movement.右から左え;
                }else{
                    random動き = Movement.左から右え;
                }

                targetData.data.Entity名 = entityDatabase.entityDataList[randomTargetID].Entity名;
                targetData.data.HP = entityDatabase.entityDataList[randomTargetID].HP;
                targetData.data.タイプ = entityDatabase.entityDataList[randomTargetID].タイプ;
                targetData.data.速度 = entityDatabase.entityDataList[randomTargetID].速度;
                targetData.data.動き = random動き;
                targetData.data.sprite = entityDatabase.entityDataList[randomTargetID].sprite;
                targetData.data.スコア = entityDatabase.entityDataList[randomTargetID].スコア;

                spawnCount++;
                
            }

            
            
        }
        
        
        spawnCount = 0;
        
        
    }
}


[System.Serializable]
public class SpawnList
{

    public int targetToSpawnID;
    public Movement 動き;
    public TimeIndicator spawnTime;
    public int spawnPointID;
    private bool isSpawned;

    public bool IsSpawned{

        get {return isSpawned;}
        set {isSpawned = value;}

    }

}


[System.Serializable]
public class TimeIndicator
{
    public int hours;
    public int minutes;
    public int seconds;
    

    public TimeIndicator(int hours, int minutes, int seconds){
        
        this.hours = hours;
        this.minutes = minutes;
        this.seconds = seconds;
        

    }

}

