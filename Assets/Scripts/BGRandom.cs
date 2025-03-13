using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGRandom : MonoBehaviour
{

    public Sprite[] bgList;
    private Image bgImage;


    // Start is called before the first frame update
    void Start()
    {
        bgImage = gameObject.GetComponent<Image>();
        if(bgList.Length != 0){
            bgImage.sprite = bgList[Random.Range(0, bgList.Length-1)];
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
