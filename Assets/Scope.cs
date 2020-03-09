using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform base_hand;
    public float calibration;
  


    // Update is called once per frame
    void Update()
    {
        
        
        Vector3 hand = new Vector3(base_hand.position.x, base_hand.position.y -.8f ,base_hand.position.z);
        gameObject.transform.position = hand - 1f * base_hand.forward;
        
    }
}
