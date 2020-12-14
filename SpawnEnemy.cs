using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public float miny=-4.7f,maxY =4.7f;
    public GameObject[] asteroid;
    public GameObject EnemyPrefab;
    public float spawnTime=2f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawntheEnemy",spawnTime);
        
    }
    void SpawntheEnemy(){
        float temp=Random.Range(maxY,miny);
        Vector3 primary = transform.position;
        primary.y = temp;

        if(Random.Range(0,2)>0){
            Instantiate(asteroid[Random.Range(0,asteroid.Length)],primary,Quaternion.identity);
        }
        else{
            Instantiate(EnemyPrefab , primary,Quaternion.Euler(0f,0f,90f));
            
        }
        Invoke("SpawntheEnemy",spawnTime);

    }
}
