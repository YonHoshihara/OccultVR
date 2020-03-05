using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golen_atack : MonoBehaviour
{
    // Start is called before the first frame update
    public bool is_atack;
    private Animator anim;
    //private GolenSoundController sound;
    void Start()
    {
        anim = GetComponent<Animator>();
        //sound = GetComponent<GolenSoundController>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (is_atack)
        {
            anim.SetTrigger("Atack");
            //sound.playAtackSound();
            //yield return new WaitForSeconds(.5f);
        }
      // is_atack = false;
    }
}
