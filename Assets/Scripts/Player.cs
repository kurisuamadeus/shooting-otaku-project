using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{

    //サウンド
    public AudioPlayerHandler SEPlayer;

    //武器
    public Weapons[] weapons;
    public int weaponIndex;


    //玉
    public int ammoMax;
    public int ammoCurr;
    
    

    //リロード
    private float reloadTimer;
    public bool isReloading;
    public float reloadTime;
    
    

    //ショット
    private bool shotIsFired;
    public float shotInterval;
    private int weaponCooldown;
    public GameObject bullet;
    private Vector3 bulletDest;

    //UI
    public UITextUpdater reloadButtonUI;
    public UITextUpdater ammoDisplayUI;

    //EXTRA
    public GameObject pauseMenu;
    private bool isPaused;
    
    // Start is called before the first frame update
    void Start()
    {
        WeaponChange(0);
        GamePaused();

    }

    // Update is called once per frame
    void Update()
    {

        ammoDisplayUI.UpdateText(ammoCurr + " / " + ammoMax);

        if(Time.timeScale != 0 && isReloading == false && (Input.touchCount == 1  || Input.GetKeyDown(KeyCode.Mouse0)) && ammoCurr > 0 && shotIsFired == false){
            
            if(Input.touchCount == 1){
                bulletDest = Input.GetTouch(0).position;
                if(EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId) == false){
                    Fire();
                }
            }else{
                if(EventSystem.current.IsPointerOverGameObject() == false){
                    Fire();
                }
            }
            

        }
    }

    public void Reload(){

        if(Time.timeScale != 0){
            if(isReloading){
                // isReloading = false;
            }else if(isReloading == false && ammoCurr < ammoMax){
                isReloading = true;
                StartCoroutine(ReloadProcess());
                switch (weaponIndex)
                {
                    case 0:
                    SEPlayer.PlayAudioGroup(3);
                    break;
                    case 1:
                    SEPlayer.PlayAudioGroup(4);
                    break;
                    case 2:
                    SEPlayer.PlayAudioGroup(5);
                    break;
                    
                }
            }
        }
        
        
    }

    IEnumerator ReloadProcess(){
        
        Debug.Log("ReloadProcessing");
        for(reloadTimer = 0; reloadTimer < reloadTime * 10; reloadTimer++){
            Debug.Log("ReloadProcess: " + (reloadTimer/reloadTime * 10) + "%");
            reloadButtonUI.UpdateText((reloadTime - (reloadTimer/10)) + "s");
            if(isReloading == false){
                
                break;
            }
            yield return new WaitForSeconds(0.1f);
        }
        if(isReloading == true){
            ammoCurr = ammoMax;
            Debug.Log("ReloadComplete");
        }else{
            Debug.Log("ReloadCanceled");
        }
        isReloading = false;
        reloadTimer = 0;
        reloadButtonUI.UpdateTextToDefault();

    }
    void Fire(){
        
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            
            if(weaponIndex == 1){

                Vector2 randomlocation = new Vector2();
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                for(int i = 0; i < 5; i++){
                    randomlocation = new Vector3(Random.Range(mousePos.x - 1f, mousePos.x + 1f), Random.Range(mousePos.y - 1f, mousePos.y + 1f), Input.mousePosition.z);
                    Instantiate(bullet, randomlocation, new Quaternion(0,0,0,1));
                }
                StartCoroutine("FireCooldown");

            }else{
                Instantiate(bullet, Camera.main.ScreenToWorldPoint(Input.mousePosition), new Quaternion(0,0,0,1));
                StartCoroutine("FireCooldown");
            }
            
        }else{
            if(weaponIndex == 1){

                Vector2 randomlocation = new Vector2();
                for(int i = 0; i < 5; i++){
                    randomlocation = new Vector3(Random.Range(bulletDest.x - 1f, bulletDest.x + 1f), Random.Range(bulletDest.y - 1f, bulletDest.y + 1f), bulletDest.z);
                    Instantiate(bullet, randomlocation, new Quaternion(0,0,0,1));
                }
                StartCoroutine("FireCooldown");

            }else{
                Instantiate(bullet, bulletDest, new Quaternion(0,0,0,1));
                StartCoroutine("FireCooldown");
            }
            
        }

        switch (weaponIndex)
        {
            case 0:
            SEPlayer.PlayAudioGroup(0);
            break;
            case 1:
            SEPlayer.PlayAudioGroup(1);
            break;
            case 2:
            SEPlayer.PlayAudioGroup(2);
            break;
            
        }

    }
    IEnumerator FireCooldown (){
        shotIsFired = true;
        ammoCurr--;
        Debug.Log("shotisfired");
        for(int i = 0; i < shotInterval * 10; i++){
            
            yield return new WaitForSeconds(0.1f);
        }
        shotIsFired = false;
        
    }

    public void WeaponChange(int weaponID){

        if(Time.timeScale != 0 && isReloading == false){
            InventoryWeaponUpdate(weaponIndex);
            weaponIndex = weaponID;
            ammoCurr = weapons[weaponID].ammoCurr;
            ammoMax = weapons[weaponID].ammoMax;
            reloadTime = weapons[weaponID].reloadTime;
            shotInterval = weapons[weaponID].shotInterval;
        }

        
        

    }

    void InventoryWeaponUpdate(int weaponID){

            weapons[weaponID].ammoCurr = ammoCurr;
            

    }

    public void GamePaused(){

        if(isPaused){
            isPaused = false;
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }else{
            isPaused = true;
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }

    }



}

[System.Serializable]
public class Weapons{

    public int ammoMax;
    public int ammoCurr;
    public float reloadTime;
    public float shotInterval;
    public float damage;

}