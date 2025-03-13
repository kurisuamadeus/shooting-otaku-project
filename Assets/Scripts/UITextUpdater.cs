using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextUpdater : MonoBehaviour
{
    public Text textToUpdate;
    private string textDefaultValue;
    // Start is called before the first frame update
    void Start()
    {
        textDefaultValue = textToUpdate.text;
    }

    public void UpdateText(string newTextValue){
        textToUpdate.text = newTextValue;

    }

    public void UpdateTextToDefault(){

        textToUpdate.text = textDefaultValue;
    }



}
