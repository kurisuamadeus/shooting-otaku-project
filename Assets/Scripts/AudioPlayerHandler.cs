using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayerHandler : MonoBehaviour
{

    public AudioToPlay[] audioToPlays;
    public AudioGroup[] audioGroupsToPlay;
    AudioSource audioSource;
    private int groupAudioIndex;
    public bool ignoreTimeScale;
    public PlayBGMSettings playBGM;
    

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 0 && ignoreTimeScale == false){

            audioSource.Pause();

        }else if(Time.timeScale != 0 && ignoreTimeScale == false){

            audioSource.UnPause();

        }
        
        if(audioSource.isPlaying == false && playBGM.playBGM && Time.timeScale != 0 && ignoreTimeScale == false){

            if(playBGM.playBGMSingle){
                PlayAudioSingleLoop(playBGM.bgmAudioSingleID);
            }else if(playBGM.playSortedBGM){
                PlayAudioGroupSortedLoop(playBGM.bgmAudioGroupID);
            }else if(playBGM.playRandomBGM){
                PlayAudioGroupRandomLoop(playBGM.bgmAudioGroupID);
            }

        }else if(audioSource.isPlaying == false && playBGM.playBGM && ignoreTimeScale){

            if(playBGM.playBGMSingle){
                PlayAudioSingleLoop(playBGM.bgmAudioSingleID);
            }else if(playBGM.playSortedBGM){
                PlayAudioGroupSortedLoop(playBGM.bgmAudioGroupID);
            }else if(playBGM.playRandomBGM){
                PlayAudioGroupRandomLoop(playBGM.bgmAudioGroupID);
            }

        }

    }

    public void PlayAudioSingleLoop(int audioID){

        audioSource.clip = audioToPlays[audioID].clip;
        audioSource.loop = true;
        audioSource.Play();

    }
    public void PlayAudioGroupSortedLoop(int groupID){

        
        if(audioSource.isPlaying == false){

            if(groupAudioIndex == audioGroupsToPlay[groupID].clip.Length-1){
               audioSource.clip = audioGroupsToPlay[groupID].clip[groupAudioIndex].clip;
                groupAudioIndex = 0;
            }else{
                 audioSource.clip = audioGroupsToPlay[groupID].clip[groupAudioIndex].clip;
                 groupAudioIndex++;
            }
                
            audioSource.Play();
        }
        audioSource.loop = false;
        

    }
    public void PlayAudioGroupRandomLoop(int groupID){

        
        if(audioSource.isPlaying == false){

            audioSource.clip = audioGroupsToPlay[groupID].clip[Random.Range(0, audioGroupsToPlay[groupID].clip.Length-1)].clip;
            audioSource.Play();
        }
        audioSource.loop = false;
        

    }

    public void PlayAudioGroup(int groupID){


        for(int i = 0; i < audioGroupsToPlay[groupID].clip.Length; i++){

            StartCoroutine(AudioStart(audioGroupsToPlay[groupID].clip[i].clip, audioGroupsToPlay[groupID].clip[i].delay));

        }



    }

    public void PlayAudio(int audioID){

        StartCoroutine(AudioStart(audioToPlays[audioID].clip, audioToPlays[audioID].delay));

    }
    public void PlayAudio(int audioID, float customDelay){

        StartCoroutine(AudioStart(audioToPlays[audioID].clip, customDelay));

    }

    IEnumerator AudioStart(AudioClip clip, float delay){

        yield return new WaitForSeconds(delay);
        audioSource.PlayOneShot(clip);


    }

  


}

[System.Serializable]
public class AudioToPlay{

    public string audioLabel;
    public AudioClip clip;
    public float delay;



}
[System.Serializable]
public class AudioGroup{

    public string audioGroupLabel;
    public AudioToPlay[] clip;

}

[System.Serializable]
public class PlayBGMSettings{

    public bool playBGM;
    public bool playBGMSingle;
    public int bgmAudioSingleID;
    public bool playSortedBGM;
    public bool playRandomBGM;
    public int bgmAudioGroupID;

}
