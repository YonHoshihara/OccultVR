using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateFireball : MonoBehaviour
{
    public  GameObject instantiate_hand;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, instantiate_hand.transform.position, .03f);
    }
}
