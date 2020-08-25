using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    // Start is called before the first frame update
    public int life;
    public bool recievedDamage;
    public bool die;
    IEnumerator Start()
    {
        recievedDamage = false;
        die = false;

        while (true)
        {
            if (life <= 0)
            {
                die = true;
            }

            if (Input.GetKeyDown("l"))
            {
                StartCoroutine(setDamage(1));
            }

            yield return new WaitForSeconds(.01f);
        }
    }
    public IEnumerator setDamage(int damage)
    {
        recievedDamage = true;
        life--;
        yield return new WaitForSeconds(.01f);
        recievedDamage = false;
    }
}
