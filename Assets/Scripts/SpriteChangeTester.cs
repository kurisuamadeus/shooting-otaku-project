using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SpriteChangeTester : MonoBehaviour
{


    public Sprite spriteReplacement;
    private Sprite spriteDefault;
    private SpriteRenderer objRenderer;
    public bool setDefault;
    public bool changeSprite;

    public bool returnToDefault;
    


    
    // Start is called before the first frame update
    void Start()
    {
        objRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteDefault = objRenderer.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(changeSprite){
            
            objRenderer.sprite = spriteReplacement;
            changeSprite = false;
        }

        if(returnToDefault){
            objRenderer.sprite = spriteDefault;
            returnToDefault = false;
        }
        if(setDefault){
            spriteDefault = objRenderer.sprite;
            setDefault = false;
        }
        
    }
}
