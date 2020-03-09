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
    public PlayerController playerController;
   
    IEnumerator Start()
    {
       
        atk_scope_anim = GetComponent<Animation>();
        sound = GetComponent<GolenSoundController>();

        while (true)
        {
           
                if (currentGesture == "CLOSE")
                {
                //  Debug.Log("Starting Magic");
                // sound.playRoarSound(false);
                    sound.playAtackSound(false);
                    StartCoroutine(StartMagic());
                    hand_magic_atack.SetActive(true);
                    yield return new WaitForSeconds(3f);
                    hand_magic_atack.SetActive(false);
                    StopCoroutine(StartMagic());
                    //sound.stopRoarSound(false);
                }
                
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
                        sound.stopAtackSound(false);
                        sound.playRoarSound(true);
                        fire.SetActive(true);
                        playerController.player_receive_damage(0.5f);
                    }
                   
                }

                if ((secont_gesture != "OPEN") && fire.activeInHierarchy)
                {
                    sound.stopRoarSound(false);
                    fire.SetActive(false);
                    yield break;
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
