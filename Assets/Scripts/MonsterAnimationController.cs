using System;
using System.Collections;
using System.Collections.Generic;
//using System.Runtime.Remoting.Metadata.W3cXsd2001;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAnimationController : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    private float anim_lenght;
    private AnimatorClipInfo[] currentClipInfo;
    private bool isAtacking = false;
    public string damageTrigger;
    public string atackTrigger;
    public string dieTrigger;
    public string walkTrigger;
    public NavMeshAgent agent;
    public DamageController damageController;


    // Update is called once per frame

    IEnumerator Start()
    {
        while (true)
        {
            if (damageController.die)
            {
                anim.SetTrigger(dieTrigger);
            }

            if (!damageController.die)
            {
                if ((agent.remainingDistance <= agent.stoppingDistance) && (agent.remainingDistance != 0))
                {
                    anim.SetTrigger(atackTrigger);
                    isAtacking = true;
                }
            }
            if ((damageController.recievedDamage) && (!damageController.die))
            {
                if (isAtacking)
                {
                    anim.SetTrigger(damageTrigger);
                    yield return new WaitForSeconds(getAnimationTime());
                    anim.SetTrigger(atackTrigger);
                }
                else
                {
                    anim.SetTrigger(damageTrigger);
                    yield return new WaitForSeconds(getAnimationTime());
                    anim.SetTrigger(walkTrigger);
                }
                
            }
            yield return new WaitForSeconds(.01f);
        }
    }

    public float getAnimationTime()
    {
        currentClipInfo = anim.GetCurrentAnimatorClipInfo(0);
        anim_lenght = currentClipInfo[0].clip.length;
        return anim_lenght-0.2f;
    }
}
