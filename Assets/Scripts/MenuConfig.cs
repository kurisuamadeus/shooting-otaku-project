using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuConfig : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeLang(int langCode){

        PlayerPrefs.SetInt("Lang", langCode);

    }

    public void GoToScene(int sceneID){

        SceneManager.LoadScene(sceneID);


    }

    public void AudioMasterChange(float vol){

        PlayerPrefs.SetFloat("SoundMaster", vol);

    }
    public void AudioBGMChange(float vol){

        PlayerPrefs.SetFloat("SoundBGM", vol);

    }
    public void AudioSEChange(float vol){

        PlayerPrefs.SetFloat("SoundSE", vol);

    }
    




}
