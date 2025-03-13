using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("さよなら");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    IEnumerator さよなら(){

        float duration = gameObject.GetComponent<ParticleSystem>().main.duration;
        gameObject.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSecondsRealtime(duration);
        Destroy(gameObject);

    }


}
