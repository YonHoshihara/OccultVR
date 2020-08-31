using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;

public class GameController : MonoBehaviour
{
    public PlayerController player;
    public GameObject game_over_feedback;
    public GameObject damage_feedback;
    public Rigidbody leap_rig;
    public Socket sk;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (true)
        {
            if (player.playerLife <= 0)
            {
                gameOver();
                yield break;
            }
            yield return new WaitForSeconds(.1f);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator game_over()
    {
        sk.StopGestureDetection();
        game_over_feedback.SetActive(true);
        damage_feedback.SetActive(true);
        leap_rig.useGravity = true;
        yield return new WaitForSeconds(5f);
        game_over_feedback.SetActive(false);
        damage_feedback.SetActive(false);
        leap_rig.useGravity = false;
        SceneManager.LoadScene("Menu");
        yield break;
    }
      private void gameOver()
    {
        StartCoroutine(game_over());
    }

}
