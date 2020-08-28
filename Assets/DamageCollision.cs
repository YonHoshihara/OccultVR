using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollision : MonoBehaviour
{
    // Start is called before the first frame update
    public  string power_tag;
    Animator anim;
    public int life;
    bool is_alive;
    private GolenSoundController sound;
    IEnumerator Start()
    {

        sound = GetComponent<GolenSoundController>();
        anim = gameObject.GetComponent<Animator>();
        sound.playRoarSound(false);
        yield return new WaitForSeconds(2f);
        anim.SetTrigger("Walk");
        sound.playWalkSound(true);
        is_alive = true;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == power_tag)
        {
            life--;
            if(life == 0)
            {

                GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
            
                sound.playDieSound(false);
                anim.SetTrigger("Die");
                yield return new WaitForSeconds(10f);
                Destroy(gameObject);
            }

            bool is_atack = true;
           if (is_atack)
            {
                sound.playDamageSound(false);
                anim.SetTrigger("Damage");
                yield return new WaitForSeconds(1f);
                anim.SetTrigger("Atack");
                sound.playAtackSound(false);
            }
            else{
                
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                sound.playDamageSound(false);
                anim.SetTrigger("Damage");

                yield return new WaitForSeconds(1f);
                anim.SetTrigger("Walk");
               
                sound.playWalkSound(true);
            }


        }
        else
        {
            if (col.gameObject.tag == "firestorm")
            {

                if (is_alive)
                {
                    life--;

                   // Debug.Log(life);
                    if (life == 0)
                    {
                        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                              
                        
                        //yield return new WaitForSeconds(.5f);
                        GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 250));
                        yield return new WaitForSeconds(.5f);
                        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                        sound.playDieSound(false);
                        anim.SetTrigger("Die");
                        GetComponent<SphereCollider>().enabled = false;
                        yield return new WaitForSeconds(10f);
                        Destroy(gameObject);
                    }

                   
                    else
                    {
                        if (life > 0)
                        {
                           
                            sound.playDamageSound(false);
                            anim.SetTrigger("Damage");
                            GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 250));
                            yield return new WaitForSeconds(1f);
                            anim.SetTrigger("Walk");
                            GetComponent<Rigidbody>().velocity = (new Vector3(0, 0, 0));
                            
                        }
                        
                    }
                }



            }
        }
    }

    //Just for gollen
    /*
    IEnumerator OnTriggerStay(Collider col)
    {
       // Debug.Log("firestorm");
        if (col.gameObject.tag == "firestorm")
        {

            if (is_alive)
            {
                life--;
                
                Debug.Log(life);
                if (life == 0)
                {
                    is_alive = false;
                    anim.SetTrigger("Iddle");
                    GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                    GetComponent<GolenMoviment>().enabled = false;
                    yield return new WaitForSeconds(3f);
                    anim.SetTrigger("Die");
                    yield return new WaitForSeconds(10f);
                    Destroy(gameObject);
                }

                bool is_atack = golen_atack.is_atack;
                if (is_atack)
                {
                    anim.SetTrigger("Damage");
                    yield return new WaitForSeconds(2f);
                    anim.SetTrigger("Atack");
                }
                else
                {
                    anim.SetTrigger("Damage");
                    GetComponent<GolenMoviment>().enabled = false;
                    GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                    yield return new WaitForSeconds(1.05f);
                    anim.SetTrigger("Walk");
                    GetComponent<GolenMoviment>().enabled = true;
                }
            }   
            


        }
    }

*/
}
