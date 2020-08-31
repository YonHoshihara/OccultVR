using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public GameObject transitionFeedback;
    public GameObject creditsFeedback;
    public string startGesture;
    public string creditsGesture;
    private bool canIStartgame;
    public Socket socket;
    public GameObject startSelectedFeedback;
    public GameObject playerCollider;
    public GameObject menuObject;

    IEnumerator Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        sound = GetComponent<GolenSoundController>();
        while (true)
        {
            if (sceneName == "Menu")
            {
                canIStartgame = true;
                if (currentGesture == "CLOSE")
                {
                    
                    if (canIStartgame)
                    {
                        startSelectedFeedback.SetActive(true);
                        StartCoroutine(SceneTransitions());
                        sound.playRoarSound(false);
                        yield return new WaitForSeconds(5f);
                        startSelectedFeedback.SetActive(false);
                        sound.stopRoarSound(false);
                        StopCoroutine(SceneTransitions());
                    }
                    
                }
                stateMachine = currentGesture;
                yield return new WaitForSeconds(.02F);
            }

            if (sceneName == "Game")
            {
                if (currentGesture == "CLOSE")
                {
                    StartCoroutine(StartMagic());
                    hand_magic_atack.SetActive(true);
                    sound.playRoarSound(false);
                    yield return new WaitForSeconds(5f);
                    hand_magic_atack.SetActive(false);
                    sound.stopRoarSound(false);
                    StartCoroutine(StartMagic());
                }
                stateMachine = currentGesture;
                yield return new WaitForSeconds(.02F);
            }
        }
        
        IEnumerator StartMagic()
        {
            while (true)
            {
                string secont_gesture = currentGesture;
                if ((secont_gesture == "OPEN")||(secont_gesture == "FIRE")||(secont_gesture == "TWO") ||(secont_gesture == "THREE"))
                {
                    Instantiate_Prefab(fireball, right_scope.transform.position);
                    sound.playAtackSound(false);
                    break;
                }
                if (secont_gesture == "LOVE")
                {
                    meteor.SetActive(true);
                    yield return new WaitForSeconds(.5f);
                    playerCollider.SetActive(false);
                    firestormCollider.SetActive(true);
                    sound.playWalkSound(false);
                    yield return new WaitForSeconds(2f);
                    sound.playAtackSound(false);
                    yield return new WaitForSeconds(2f);
                    playerCollider.SetActive(true);
                    firestormCollider.SetActive(true);
                    meteor.SetActive(false);
                }
                yield return new WaitForSeconds(.01f);
            }
        }

        IEnumerator SceneTransitions()
        {
            while (true)
            {
                string secont_gesture = currentGesture;
                if (canIStartgame)
                {
                    if (secont_gesture == startGesture)
                    {
                        startSelectedFeedback.SetActive(false);
                        sound.stopRoarSound(false);
                        transitionFeedback.SetActive(true);
                        socket.StopGestureDetection();
                        yield return new WaitForSeconds(2);
                        SceneManager.LoadScene("Game");
                    }

                    if (secont_gesture == creditsGesture)
                    {
                        sound.stopRoarSound(false);
                        startSelectedFeedback.SetActive(false);
                        menuObject.SetActive(false);
                        creditsFeedback.SetActive(true);
                        canIStartgame = false;
                        yield return new WaitForSeconds(5);
                        menuObject.SetActive(true);
                        creditsFeedback.SetActive(false);
                        menuObject.SetActive(true);
                        yield return new WaitForSeconds(.5f);
                        canIStartgame = true;
                    }
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
