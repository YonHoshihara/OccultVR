using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallMoviment : MonoBehaviour
{
    float time;
    public float fireSpeed;
    public Vector3 direction;
    public GameObject explosion;
    public Transform scope;
    public Transform hand;
     void Start()
    {
        scope = GameObject.FindGameObjectWithTag("scope").GetComponent<Transform>();
        hand = GameObject.FindGameObjectWithTag("right_palm").GetComponent<Transform>();
        direction = scope.position - hand.position;
        direction = new Vector3(direction.x, 0, direction.z);
        GetComponent<Rigidbody>().AddForce(direction.normalized * fireSpeed);
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction.normalized, 1, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
