using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerController : MonoBehaviour
{
    public string currentGesture = " ";
    string lastGesture;
    string stateMachine = "";
    public GameObject meteor;
    public GameObject fireball;
    public GameObject firestormCollider;
    public GameObject hand_magic_atack;
    public GameObject right_scope;
    private GolenSoundController sound;
    public PlayerController playerController;

    IEnumerator Start()
    {
        sound = GetComponent<GolenSoundController>();
        while (true)
        {
                if (currentGesture == "CLOSE")
                {
                    sound.playAtackSound(false);
                    StartCoroutine(StartMagic());
                    hand_magic_atack.SetActive(true);
                    yield return new WaitForSeconds(5f);
                    hand_magic_atack.SetActive(false);
                    StopCoroutine(StartMagic());
                }
                stateMachine = currentGesture;
                yield return new WaitForSeconds(.02F);
        }
        IEnumerator StartMagic()
        {
            while (true)
            {
                string secont_gesture = currentGesture;
                if ((secont_gesture == "OPEN")||(secont_gesture == "FIRE")||(secont_gesture == "TWO") ||(secont_gesture == "THREE"))
                {
                    Instantiate_Prefab(fireball, right_scope.transform.position);
                    break;
                }
                if (secont_gesture == "LOVE")
                {
                    meteor.SetActive(true);
                    yield return new WaitForSeconds(.5f);
                    firestormCollider.SetActive(true);
                    yield return new WaitForSeconds(2f);
                    firestormCollider.SetActive(true);
                    meteor.SetActive(false);
                }
                yield return new WaitForSeconds(.01f);
            }
        }
    }
    void Instantiate_Prefab(GameObject obj, Vector3 instantate_positon)
    {
        Instantiate(obj, instantate_positon, Quaternion.identity);
    }
    
}
