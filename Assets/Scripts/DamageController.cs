using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    // Start is called before the first frame update
    public int life;
    public bool recievedDamage;
    public bool die;
    private IEnumerator damageCourotine;
    void Start()
    {
        recievedDamage = false;
        die = false;
    }
    private IEnumerator Damage(int damage)
    {
        recievedDamage = true;
        life -= damage;
        if (life <= 0)
        {
            die = true;
        }
        yield return new WaitForSeconds(.01f);
        recievedDamage = false;
    }
    public void setDamage(int damage)
    {
        damageCourotine = Damage(damage);
        StartCoroutine(damageCourotine);
    }
}
