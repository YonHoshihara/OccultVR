using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ignoreColision : MonoBehaviour
{
    // Start is called before the first frame update
    public int layer_1;
    public int layer_2;
    void Start()
    {
        Physics.IgnoreLayerCollision(layer_1, layer_2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
