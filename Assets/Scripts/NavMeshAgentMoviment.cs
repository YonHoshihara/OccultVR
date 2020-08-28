using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgentMoviment : MonoBehaviour
{
    public string targetTag;
    public NavMeshAgent agent;
    private Transform target;
    private bool canIMove;
    public Animator anim;
    private AnimatorClipInfo[] currentClipInfo;
    private float anim_lenght;
    public MonsterAnimationController animationController;
    public DamageController damageController;
    IEnumerator Start()
    {
        target = GameObject.FindGameObjectWithTag(targetTag).GetComponent<Transform>();
        currentClipInfo = anim.GetCurrentAnimatorClipInfo(0);
        anim_lenght = currentClipInfo[0].clip.length;
        canIMove = false;
        yield return new WaitForSeconds(anim_lenght);
        canIMove = true;
        while (true)
        {
            if (canIMove)
            {
                agent.SetDestination(target.position);
            }

            if ((damageController.recievedDamage) || (damageController.die))
            {
                agent.isStopped = true;
                yield return new WaitForSeconds(animationController.getAnimationTime());
            }

            if ((!damageController.recievedDamage) && (!damageController.die))
            {
                agent.isStopped = false;
            }

            yield return new WaitForSeconds(.01f);
        }
    }
}
