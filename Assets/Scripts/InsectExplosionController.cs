﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class InsectExplosionController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject explosionObject;
    public DamageController damageController;
    public MonsterAnimationController animationController;
    public NavMeshAgent agent;
    public float explosionTime;
    IEnumerator Start()
    {
        while (true)
        {
            if (!damageController.die)
            {
                if ((agent.remainingDistance <= agent.stoppingDistance) && (agent.remainingDistance != 0))
                {
                    yield return new WaitForSeconds(animationController.getAnimationTime());
                    explosionObject.SetActive(true);
                    yield return new WaitForSeconds(explosionTime);
                    damageController.life = 0;
                    explosionObject.SetActive(false);
                }
            }
            yield return new WaitForSeconds(.01f);
        }
    }   
}