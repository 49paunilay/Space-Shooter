using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed=5f;
    public float miny;
    public float maxy;
    public GameObject Player_Bullet;
    public Transform AttackPoint;
    public float AttackTimer=0.45f;
    private float currentAttackTimer;
    public bool canShoot;
    public AudioSource playerdestroy;
    public AudioSource Player_Bullet_sound;
    public Text scoretext;
    public int score = 1;
    
    void Start()
    {
        currentAttackTimer=AttackTimer;
        
    }
    void Update()
    {
        MoveShip();
        Attack();
        score++;
        scoretext.text = score + "";
        
    }
    void MoveShip(){
        if(Input.GetAxisRaw("Vertical")>0){
            Vector3 primaryPosition = transform.position;
            primaryPosition.y+=speed*Time.deltaTime;
            if(primaryPosition.y > maxy){
                primaryPosition.y = maxy;
            }
            transform.position = primaryPosition;

        }
        else if(Input.GetAxisRaw("Vertical")<0){
            Vector3 primaryPosition = transform.position;
            primaryPosition.y-=speed*Time.deltaTime;
            if(primaryPosition.y < miny){
                primaryPosition.y = miny;
            }
            transform.position = primaryPosition;

        }
    }
    void Attack(){
        AttackTimer+=Time.deltaTime;
        if(AttackTimer>currentAttackTimer){
            canShoot=true;
        }
        if(Input.GetKey(KeyCode.Q)){
            if(canShoot){
                canShoot=false;
                AttackTimer=0f;
                Player_Bullet_sound.Play();
                Instantiate(Player_Bullet,AttackPoint.position,Quaternion.identity);

            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="EnemyBullet"){
            Debug.Log("Enemy Bullets");

        }
        if(other.tag=="ene"){
            
            StartCoroutine(KillThePlayer());

        }
    }
    IEnumerator KillThePlayer(){
        Vector3 mypos = transform.position;
        playerdestroy.Play();
        score=0;
        transform.position = new Vector3(100f,100f,100f);
        yield return new WaitForSeconds(3f);
        
        transform.position = mypos;
        
    }
}
