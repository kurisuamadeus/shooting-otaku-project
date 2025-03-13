using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeDisplayHandler : MonoBehaviour
{

    public int minutes;
    public int seconds;
    private bool clockIsTicking;

    public bool ClockIsTicking{

        get { return clockIsTicking;}

    }

    private Text timeDisplay;


    // Start is called before the first frame update
    void Start()
    {
        timeDisplay = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(clockIsTicking == false && Time.timeScale != 0){
            StartCoroutine(UpdateTime());
        }

        if(minutes < 10){

            if(seconds < 10){
                timeDisplay.text = "0" + minutes + " : " + "0" + seconds;
            }else{
                timeDisplay.text = "0" + minutes + " : " + seconds;
            }
        }else{
            if(seconds < 10){
                timeDisplay.text = minutes + " : " + "0" + seconds;
            }else{
                timeDisplay.text = minutes + " : " + seconds;
            }

        }

    }


    IEnumerator UpdateTime(){

        clockIsTicking = true;

        yield return new WaitForSecondsRealtime(1);

        if(Time.timeScale != 0){
            if(seconds == 59){
                minutes++;
                seconds = 0;
            }else{
                seconds++;
            }
        }

        

        clockIsTicking = false;
    }


}
