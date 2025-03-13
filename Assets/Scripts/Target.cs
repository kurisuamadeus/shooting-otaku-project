using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public Entity data;
    private Vector3 pos;
    public ScoreHandler scoreDisplay;

    // Start is called before the first frame update
    void Start()
    {
        scoreDisplay = GameObject.FindGameObjectWithTag("ScoreDisplay").GetComponent<ScoreHandler>();
        Debug.Log(scoreDisplay.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        OutOfBorderChecker();
        gameObject.GetComponent<SpriteRenderer>().sprite = data.sprite;
        
        pos = gameObject.transform.position;
        if(data.動き == Movement.右から左え){
            
            gameObject.transform.position = new Vector3(pos.x - data.速度 * Time.deltaTime, pos.y, pos.z);
        }else if(data.動き == Movement.左から右え){
            gameObject.transform.position = new Vector3(pos.x + data.速度 * Time.deltaTime, pos.y, pos.z);
        }
        gameObject.GetComponent<BoxCollider2D>().size = new Vector3(gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size.x, gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size.y / 2, gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size.z);
        gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0, gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size.y/4);
    }

    void OnTriggerEnter2D(Collider2D coll){
        if(coll.gameObject.tag == "Bullet"){
            
            Debug.Log(data.スコア);

            if(data.HP <= 1){
                StartCoroutine("Dead");
            }else{
                data.HP--;
            }


            
        }
    }

    void OutOfBorderChecker(){

        if(gameObject.transform.position.x > 15 || gameObject.transform.position.x < -15){

            switch (data.タイプ)
            {
            
                case Entityタイプ.一般人:
                    scoreDisplay.score = scoreDisplay.score + data.スコア;
                break;
                case Entityタイプ.敵:
                    scoreDisplay.score = scoreDisplay.score - data.スコア;
                break;
            
            }
            Destroy(gameObject);
        }

    }
    
    IEnumerator Dead(){

        switch (data.タイプ)
        {
            
            case Entityタイプ.一般人:
                scoreDisplay.score = scoreDisplay.score - data.スコア;
            break;
            case Entityタイプ.敵:
                scoreDisplay.score = scoreDisplay.score + data.スコア;
            break;
            
        }

        
        gameObject.GetComponent<ParticleSystem>().Play();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSecondsRealtime(0.5f);
        Destroy(gameObject);
    }

    

    

}
