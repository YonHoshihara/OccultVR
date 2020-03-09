using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;

public class PlayerDamage : MonoBehaviour
{
    // Start is called before the first frame update
    public string monster_tag; 
    public GameObject damage_feedback;
    public GameObject gameOver;
    public GolenSoundController sound;
    public PlayerController playercontroler;

    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == monster_tag)
        {  
            sound.playDamageSound(false);
            playercontroler.player_receive_damage(.5f);
        }  
    }
    public void damage_sound()
    {
        sound.playDamageSound(false);
    }
  
}
