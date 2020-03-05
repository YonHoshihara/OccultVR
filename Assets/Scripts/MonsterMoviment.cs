using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class MonsterMoviment : MonoBehaviour
{
    public float speed,time;
    public Transform target;
   // public Transform destination;
    // Start is called before the first frame update
    void Start()
    {
     
        Vector3 addForceVector = target.position - gameObject.transform.position;
        addForceVector = addForceVector.normalized;
        addForceVector.z = addForceVector.z * speed;
       // addForceVect = ador.x = 0;
       // addForceVector.y = 0;
       // addForceVector.z = speed;
        gameObject.GetComponent<Rigidbody>().AddForce(addForceVector);

      //  GetComponent<NavMeshAgent>().SetDestination(destination.position);
    }

    // Update is called once per frame
    void LateUpdate()
    {
       // time += Time.deltaTime;
       // if (time > 10) Destroy(gameObject);
    }
}
