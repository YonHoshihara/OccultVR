using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerController : MonoBehaviour
{
 
    public string currentGesture = " ";
    string lastGesture;
    string stateMachine = "";
    public GameObject fire;
    private Animation atk_scope_anim;
    public GameObject hand_magic_atack;
    public GameObject hand_magic_defense;
    public GameObject right_scope;
    private GolenSoundController sound;
    private PlayerDamage player;
    public PlayerDamage damage;
    IEnumerator Start()
    {
       
        atk_scope_anim = GetComponent<Animation>();
        sound = GetComponent<GolenSoundController>();
        player = GameObject.FindGameObjectWithTag("player_damage").GetComponent<PlayerDamage>();

        while (true)
        {
           
                if (currentGesture == "CLOSE")
                {
                  //  Debug.Log("Starting Magic");
                    sound.playRoarSound(false);
                    StartCoroutine(StartMagic());
                    hand_magic_atack.SetActive(true);
                    yield return new WaitForSeconds(3f);
                    hand_magic_atack.SetActive(false);
                    StopCoroutine(StartMagic());
                    sound.stopRoarSound(false);
                }
                /*
                 if (currentGesture == "THUMB")
                 {
                     Debug.Log("Starting Defense");
                     hand_magic_defense.SetActive(true);
                     StartCoroutine(StartDefense());
                     yield return new WaitForSeconds(5f);
                     hand_magic_defense.SetActive(false);
                     StopCoroutine(StartDefense());
                     Debug.Log("Ending_Defense");
                 }
                 */
                stateMachine = currentGesture;
                yield return new WaitForSeconds(.2F);
            
          
        }
        IEnumerator StartMagic()
        {
            while (true)
            {


                string secont_gesture = currentGesture;
                if (secont_gesture == "OPEN")
                {
                    if (!fire.activeInHierarchy)
                    {
                        hand_magic_atack.SetActive(false);
                        sound.stopRoarSound(false);
                        sound.playAtackSound(false);
                        fire.SetActive(true);
                        damage.player_receive_damage(0.1f);
                    }
                   
                }

                if ((secont_gesture != "OPEN") && fire.activeInHierarchy)
                {
                    fire.SetActive(false);
                    StopCoroutine(StartMagic());
                }

                yield return new WaitForSeconds(.1f);
            }

        }




    }

    void Instantiate_Prefab(GameObject obj, Vector3 instantate_positon)
    {
        Instantiate(obj, instantate_positon, Quaternion.identity);
    }
    
}
