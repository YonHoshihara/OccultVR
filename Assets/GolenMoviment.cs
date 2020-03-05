using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolenMoviment : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player_positon;
    public float rotationSpeed;
    public float moveSpeed;
    public float min_distance;
    private Golen_atack golen_atack;
    private GolenSoundController sound;
    void Start()
    {
        player_positon = GameObject.FindWithTag("Player").GetComponent<Transform>();
        golen_atack = GetComponent<Golen_atack>();
        sound = GetComponent<GolenSoundController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Rotate the object
        Vector3 direction = player_positon.position - transform.position;
        direction = new Vector3(direction.x, 0, direction.z);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction.normalized), rotationSpeed * Time.deltaTime);
        //Move towards the player
        if (direction.magnitude > min_distance)
        {
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
        }
        else
        {
            golen_atack.is_atack = true;
            sound.stopWalkSound(false);
          //  sound.playAtackSound();
            GetComponent<GolenMoviment>().enabled = false;

        }
        
    }
}
