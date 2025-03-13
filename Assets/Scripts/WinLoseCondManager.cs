using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinLoseCondManager : MonoBehaviour
{

    public UITextUpdater scoreRequiredText;
    public UITextUpdater timeLimitText;
    public GameObject gameOverScreen;
    public AudioPlayerHandler gameOverSound;
    public ScoreHandler scoreHandler;
    public TimeDisplayHandler timeDisplayHandler;
    public Conditions winCond;
    public ConditionsUpdate winCondUpdate;
    public Conditions loseCond;
    public ConditionsUpdate loseCondUpdate;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        scoreRequiredText.UpdateText(loseCond.score.scoreRequired.ToString("D9"));
        timeLimitText.UpdateText(loseCond.score.timeLimit.minutes.ToString("D2") + " : " + loseCond.score.timeLimit.seconds.ToString("D2"));

        if(loseCond.enabled && scoreHandler.score < loseCond.score.scoreRequired){

            scoreRequiredText.gameObject.GetComponent<Image>().color = new Color32(255, 148, 148, 200);

        }else if(loseCond.enabled && scoreHandler.score >= loseCond.score.scoreRequired){

            scoreRequiredText.gameObject.GetComponent<Image>().color = new Color32(148, 255, 148, 200);

        }


        if(loseCond.enabled && timeDisplayHandler.minutes >= loseCond.score.timeLimit.minutes && timeDisplayHandler.seconds >= loseCond.score.timeLimit.seconds && scoreHandler.score < loseCond.score.scoreRequired){

            gameOverScreen.SetActive(true);
            gameOverSound.PlayAudioSingleLoop(0);
            Time.timeScale = 0;
            

        }

        if(loseCond.enabled && loseCondUpdate.enabled && loseCondUpdate.isEndless && timeDisplayHandler.minutes >= loseCond.score.timeLimit.minutes && timeDisplayHandler.seconds >= loseCond.score.timeLimit.seconds){

            loseCond.score.Increase(loseCondUpdate.scoreReqIncrease.scoreRequired, loseCondUpdate.scoreReqIncrease.timeLimit);

        }

    }
}

[System.Serializable]
public class ConditionsUpdate{

    public bool enabled;
    public ScoreRequirement[] scoreRequiredList;
    public bool isEndless;
    public ScoreRequirement scoreReqIncrease;
    

}
[System.Serializable]
public class Conditions{

    public bool enabled;
    public ScoreRequirement score;

}
[System.Serializable]
public class ScoreRequirement{

    public int scoreRequired;
    public TimeIndicator timeLimit;
    public void Increase(int score, TimeIndicator time){

        scoreRequired = scoreRequired + score;
        timeLimit.hours = timeLimit.hours + time.hours;
        timeLimit.minutes = timeLimit.minutes + time.minutes;
        timeLimit.seconds = timeLimit.seconds + time.seconds;
    }
    

}
