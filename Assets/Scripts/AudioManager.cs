using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

    public AudioMixer mixer;
    public AudioSounds audioSounds = new AudioSounds();
    public Slider sliderMaster;
    public Slider sliderBGM;
    public Slider sliderSE;
    string[] soundsNaming = new string[3];
        

    // Start is called before the first frame update
    void Start()
    {
        soundsNaming[0] = "SoundMaster";
        soundsNaming[1] = "SoundBGM";
        soundsNaming[2] = "SoundSE";

        LoadSoundSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
        SoundSettingsUpdate();
        
    }

    private void SoundSettingsUpdate(){

        
        
        mixer.SetFloat(soundsNaming[0], sliderMaster.value);
        mixer.SetFloat(soundsNaming[1], sliderBGM.value);
        mixer.SetFloat(soundsNaming[2], sliderSE.value);
        
        Debug.Log(PlayerPrefs.GetFloat(soundsNaming[0]));
        Debug.Log(PlayerPrefs.GetFloat(soundsNaming[1]));
        Debug.Log(PlayerPrefs.GetFloat(soundsNaming[2]));

    }

    public void SaveSoundSettings(){

        PlayerPrefs.SetFloat(soundsNaming[0], sliderMaster.value);
        PlayerPrefs.SetFloat(soundsNaming[1], sliderBGM.value);
        PlayerPrefs.SetFloat(soundsNaming[2], sliderSE.value);

    }
    public void LoadSoundSettings(){
        
        audioSounds.Master = PlayerPrefs.GetFloat(soundsNaming[0], 0);
        audioSounds.BGM = PlayerPrefs.GetFloat(soundsNaming[1], 0);
        audioSounds.SE = PlayerPrefs.GetFloat(soundsNaming[2], 0);
        sliderMaster.value = audioSounds.Master;
        sliderBGM.value = audioSounds.BGM;
        sliderSE.value = audioSounds.SE;

    }

}

[System.Serializable]
public class AudioSounds{

    public float Master;
    public float BGM;
    public float SE;

}
