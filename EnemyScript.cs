using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public float speed = 5f;
    public float rotate_Speed = 50f;
    public bool canShoot;
    public bool canMove = true;
    public bool canRotate;
    public float bound_x = -11f;
    public Transform Attackpoint;
    public GameObject EmenyBullet;

    private AudioSource enemyDestroy;

    public AudioSource lazerE;


    private void Awake() {
        enemyDestroy = GetComponent<AudioSource>();
    }

    private void Start() {
        if(canRotate){
            if(Random.Range(0,2)>0){
                rotate_Speed=Random.Range(rotate_Speed,rotate_Speed+20f);
                rotate_Speed*=-1;
            }
            else{
                rotate_Speed=Random.Range(rotate_Speed,rotate_Speed+20f);

            }
        }
        if(canShoot){
            Invoke("shootThePlayer",Random.Range(1f,2f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
        Rotate();
    }
    void MoveEnemy(){
        if(canMove){
            Vector3 temp = transform.position ; 
            temp.x-=speed*Time.deltaTime;
            transform.position = temp;

            if(temp.x <bound_x){
                gameObject.SetActive(false);
            }
        }
    }
    void Rotate(){
        if(canRotate){
            transform.Rotate(new Vector3(0f,0f,rotate_Speed*Time.deltaTime),Space.World);
        }
    }
    void shootThePlayer(){
        lazerE.Play();
        GameObject bullet = Instantiate(EmenyBullet,Attackpoint.position,Quaternion.identity);
        bullet.GetComponent<Bullets>().isEnemyBullet=true;
        if(canShoot){
            Invoke("shootThePlayer",Random.Range(1f,1.75f));
        }
    }
    void TurnOff(){
        

        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D target) {
        if(target.tag=="Bullet"){
            canMove=false;
            if(canShoot){
                canShoot=false;
                CancelInvoke("shootThePlayer");
            }

            Invoke("TurnOff",0.5f);
            enemyDestroy.Play();
        }
    }
}
