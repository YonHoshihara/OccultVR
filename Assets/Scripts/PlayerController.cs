using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float playerLife;
    public PlayerDamage player_damage;
    public GameObject damage_feedback;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator set_damage_feedback()
    {
        damage_feedback.SetActive(true);
        yield return new WaitForSeconds(1f);
        damage_feedback.SetActive(false);
        yield break;
    }
    public void player_receive_damage(float damage)
    {
        player_damage.damage_sound();
        playerLife = playerLife - damage;
        StartCoroutine(set_damage_feedback());
    }
}
