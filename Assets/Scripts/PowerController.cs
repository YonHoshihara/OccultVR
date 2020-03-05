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
    public GameObject defense_fire;
    public GameObject fire3;
    public GameObject hand_magic_atack;
    public GameObject hand_magic_defense;
    public GameObject fireball;
    public GameObject right_scope;
    public GameObject left_scope;
    private GolenSoundController sound;
    private PlayerDamage player;
    //public bool is_start_magic = false;
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
                    yield return new WaitForSeconds(5f);
                    hand_magic_atack.SetActive(false);
                    StopCoroutine(StartMagic());
                    sound.stopRoarSound(false);
                   // Debug.Log("Ending_Magic");
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
                    hand_magic_atack.SetActive(false);
                    sound.stopRoarSound(false);
                    sound.playAtackSound(false);
                    //Debug.Log("Shooting");
                    Instantiate_Prefab(fireball, right_scope.transform.position);
                    // Debug.Log("BOLA DE FOGO, METEOOOORO");
                    //yield return new WaitForSeconds(.5f);
                    break;

                }



                if (secont_gesture == "LOVE")
                {
                    hand_magic_atack.SetActive(false);
                    defense_fire.SetActive(true);
                    sound.stopRoarSound(false);
                    sound.playAtackSound(false);
                    yield return new WaitForSeconds(2f);
                    defense_fire.SetActive(false);
                    break;

                }


                yield return new WaitForSeconds(.1f);
            }

        }




    }

    void Instantiate_Prefab(GameObject obj, Vector3 instantate_positon)
    {
        Instantiate(obj, instantate_positon, Quaternion.identity);
    }
    IEnumerator StartDefense()
    {
        while (true)
        {
            string secont_gesture = currentGesture;
            if (secont_gesture == "OPEN")
            {
                hand_magic_defense.SetActive(false);
                Debug.Log("MURALHA DE CRISTAL");
                fire3.SetActive(true);
                //yield return new WaitForSeconds(.5f);
                break;

            }

            if (secont_gesture == "LOVE")
            {

                hand_magic_defense.SetActive(false);
                Debug.Log("VENTO IMPETUOSO");
                //yield return new WaitForSeconds(.5f);
                break;

            }
            yield return new WaitForSeconds(.1f);
        }

    }

    IEnumerator Die()
    {
        //hand_magic_atack.SetActive(false);
        hand_magic_atack.SetActive(false);
        defense_fire.SetActive(false);

        yield return new WaitForSeconds(0);
    }
    void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            Debug.Log("Shooting");
            Instantiate_Prefab(fireball, right_scope.transform.position);
        }
    }
}
