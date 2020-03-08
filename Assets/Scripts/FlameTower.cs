using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameTower : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform scopeAtack;
    public Transform rightPalm;
    private Vector3 direction;
    private Vector3 rotationDirection;
    void Start()
    {
       
    }

    // Update is called once per frame
    void LateUpdate()
    {
        direction = scopeAtack.position - rightPalm.position;
        direction = new Vector3(direction.x, 0, direction.z);
        float step = 1 * Time.deltaTime;
        rotationDirection = Vector3.RotateTowards(transform.forward, direction.normalized, step, 0.0f);
        transform.rotation = Quaternion.LookRotation(rotationDirection);

    }

}
