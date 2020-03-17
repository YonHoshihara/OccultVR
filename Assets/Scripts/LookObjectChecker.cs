using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookObjectChecker : MonoBehaviour
{
    // Start is called before the first frame update

    private IEnumerator Start()
    {
        while (true)
        {
            int layerMask = 1 << 11;

            RaycastHit hit;
            Debug.DrawRay(transform.position, transform.forward * 10, Color.red);

            if (Physics.Raycast(transform.position, transform.forward * 10, out hit, Mathf.Infinity, layerMask))
            {
                if (hit.collider.gameObject.tag == "interactive")
                {
                    hit.collider.gameObject.GetComponent<InteractionDetector>().set_onview(true);
                }
            }

            yield return new WaitForSeconds(.5f);
        }

    }

}
