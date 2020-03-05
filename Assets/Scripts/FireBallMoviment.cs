using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallMoviment : MonoBehaviour
{
    float time;
    public float fireSpeed;
    public Vector3 direction;
    public GameObject explosion;
    public bool is_explosion;
    public Transform scope_atack;
    public Transform hand;   // public Transform direcional_start;
   // public Transform directional_end;
     void Start()
    {
        scope_atack = GameObject.FindGameObjectWithTag("scope_atack").GetComponent<Transform>();
        hand = GameObject.FindGameObjectWithTag("right_palm").GetComponent<Transform>();
        direction = scope_atack.position - hand.position;
        direction = new Vector3(direction.x,0, direction.z);
        GetComponent<Rigidbody>().AddForce(direction.normalized * fireSpeed);
        
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction.normalized, 1, 0.0f);

        transform.rotation = Quaternion.LookRotation(newDirection);
    }
     
    public void Shoot()
    {
       
    }
    void LateUpdate()
    {
        //
        //  if (transform.up.y < 0){
        //    transform.position += 1 * transform.up * fireSpeed * Time.deltaTime;
        //  Debug.Log(transform.up);
        //}
        //else
        //{
        //  transform.position += -1 * transform.up * fireSpeed * Time.deltaTime;
        //}


        time += Time.deltaTime;
        if (time > 4) Destroy(gameObject);
    }


     IEnumerator OnTriggerEnter(Collider col)
    {
       
        if (col.gameObject.tag == "enemy")
        {
            
           // print(col.gameObject.name);
            if (is_explosion)
            {
                explosion.SetActive(true);
                yield return new WaitForSeconds(.5f);
                Destroy(this.gameObject);
            }
            else
            {
                yield return new WaitForSeconds(0f);
                Destroy(this.gameObject);
            }
            
        }

        

    }
}
