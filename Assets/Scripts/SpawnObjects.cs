using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    // Start is called before the first frame update
   
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn(GameObject obj, Vector3 position, Quaternion rotation)
    {

        Instantiate(obj, position, rotation);
    }
}
