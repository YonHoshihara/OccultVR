using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveMonsterPrefab : MonoBehaviour
{
    // Start is called before the first frame update
    public float destroyTime;
    public DamageController damageController;
    IEnumerator Start()
    {
        while (true)
        {
            if (damageController.die)
            {
                yield return new WaitForSeconds(destroyTime);
                Destroy(gameObject);
            }
        yield return new WaitForSeconds(.1f);
        }
    }
}
