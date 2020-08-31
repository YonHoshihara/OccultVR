using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCollisionController : MonoBehaviour
{
    // Start is called before the first frame update
    public DamageController damageController;
    public string atackTag;
    public int damage;
    public GolenSoundController sound;
    private IEnumerator OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == atackTag)
        {
            sound.playDamageSound(false);
            damageController.setDamage(damage);
            yield return new WaitForSeconds(.2f);
        }
        yield return new WaitForSeconds(.2f);
    }
}
