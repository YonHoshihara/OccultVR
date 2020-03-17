using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDetector : MonoBehaviour
{
    // Start is called before the first frame update
    public string active_gesture; 
    public PowerController power_controller;
    public GameObject icon;
    public float interaction_time;
    private string current_gesture;
    private bool is_onview;
    private float timer = 0.0f;
    IEnumerator Start()
    {
        while (true)
        {
            current_gesture = power_controller.currentGesture;
            if (is_onview)
            {
                active_icon(true);

               
                timer += Time.deltaTime;

                if ((current_gesture == active_gesture) && (timer < interaction_time))
                {
                    //Debug.Log("Power Active");
                    push_power();
                    GetComponent<InteractionDetector>().enabled = false;
                }
                
                if (timer > interaction_time)
                {
                    active_icon(false);
                    set_onview(false);
                }

            } 
            if (!is_onview)
            {
                active_icon(false);
                timer = 0.0f;
            }
            yield return new WaitForSeconds(.5f);
        }


    }

    

    // Update is called once per frame
    void Update()
    {
        current_gesture = power_controller.currentGesture;
    }

    private void active_icon(bool value)
    {
        icon.SetActive(value);
    }

    public  void set_onview(bool value)
    {
        this.is_onview = value;
    }

    private void push_power()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * 500);
    }
    
}
