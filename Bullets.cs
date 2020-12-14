using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public float speed = 4f;
    public float deactivate=6f;
    public bool isEnemyBullet = false;
    
    void Start()
    {

        
        if(isEnemyBullet){
            speed*=-1f;
        }
        Invoke("DestroyBullet",deactivate);
        
    }

    void Update()
    {
        MoveBullet();
        
    }
    void MoveBullet(){
        Vector3 primary = transform.position;
        
        primary.x=primary.x+speed*Time.deltaTime;
        transform.position=primary;
       
    }
    void DestroyBullet(){
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Bullet" || other.tag=="ene"){
            gameObject.SetActive(false);
        }
    }
}
