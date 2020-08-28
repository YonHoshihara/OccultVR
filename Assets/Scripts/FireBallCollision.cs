using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallCollision : MonoBehaviour
{
    // Start is called before the first frame update
    public string collisionTag;
    public GameObject explosion;
    IEnumerator OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == collisionTag)
        {
           explosion.SetActive(true);  
           yield return new WaitForSeconds(.5f);
           Destroy(this.gameObject);
        }
    }
}
