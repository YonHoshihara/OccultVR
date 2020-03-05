using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;

public class PlayerDamage : MonoBehaviour
{
    // Start is called before the first frame update
    public string monster_tag; 
    public int playerLife;
    public GameObject damage_feedback;
    public GameObject gameOver;
    public GolenSoundController sound;
    public bool is_dead;
    public Rigidbody leap_rig;
    public Socket sk;
    void Start()
    {
        is_dead = false;
        sound = GetComponent<GolenSoundController>();
        leap_rig = GameObject.FindGameObjectWithTag("leap_rig").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == monster_tag)
        {
            //  yield return new WaitForSeconds(5f);

            
            playerLife--;
            sound.playDamageSound(false);
            damage_feedback.SetActive(true);
            yield return new WaitForSeconds(1f);
            damage_feedback.SetActive(false);
           // Debug.Log("Getting Damage");
           // Debug.Log(playerLife);
            if (playerLife < 0)
            {
                Thread ts = sk.mThread;
                ts.Abort();
                is_dead = true;
                gameOver.SetActive(true);
                damage_feedback.SetActive(true);
                leap_rig.useGravity = true;
                yield return new WaitForSeconds(5f);
                gameOver.SetActive(false);
                damage_feedback.SetActive(false);
                is_dead = false;
                leap_rig.useGravity = false;
                SceneManager.LoadScene("Menu");
            }

        }
        yield return new WaitForSeconds(.2f);
    }

    
}
