using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionController : MonoBehaviour
{
    public string currentGesture = " ";
    string lastGesture;
    string stateMachine = "";
    public GameObject transitionFeedback;
    public GameObject creditsFeedback;
    public string startGesture;
    public string creditsGesture;
    private bool canIStartgame;
    IEnumerator Start()
    {
        canIStartgame = true;
        while (true)
        {
            if (currentGesture == "CLOSE")
            {
                StartCoroutine(StartMagic());
                yield return new WaitForSeconds(5f);
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
                if (secont_gesture == startGesture)
                {
                    transitionFeedback.SetActive(true);
                    yield return new WaitForSeconds(2);
                    SceneManager.LoadScene("Game");   
                }
                
                if (secont_gesture == creditsGesture)
                {
                    creditsFeedback.SetActive(true);
                    canIStartgame = false;
                    yield return new WaitForSeconds(2);
                    creditsFeedback.SetActive(false);
                    canIStartgame = true;
                }
                yield return new WaitForSeconds(.01f);
            }
        }
    }    
}
