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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == monster_tag)
        {
            Debug.Log("PLayer Damage");
            sound.playDamageSound(false);
            playercontroler.player_receive_damage(.5f);
        }  
    }
    public void damage_sound()
    {
        sound.playDamageSound(false);
    }
  
}
