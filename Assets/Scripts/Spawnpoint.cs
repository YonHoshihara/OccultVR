using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnpoint : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject objectToSpawn;
    //public SpawnObjects spawnContoller;
    public float startTime;
    public float repeatTime;
    public PlayerDamage player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player_damage").GetComponent<PlayerDamage>();
        InvokeRepeating("SpawnMonster",startTime,repeatTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnMonster()
    {
       
            Instantiate(objectToSpawn, transform.position, transform.rotation);
        
        
    }
}
