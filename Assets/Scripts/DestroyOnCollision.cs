using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public string tag;
    public float destroyTime;
    public int life;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == tag)
        {
            Destroy(other.gameObject);
            Debug.Log("Detroyed");
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            anim.SetTrigger("Die");
            yield return new WaitForSeconds(destroyTime);
            Destroy(gameObject);
        }

        yield return new WaitForSeconds(0.0f);
    }
}
