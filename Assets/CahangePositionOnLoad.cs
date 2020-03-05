using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement
;
public class CahangePositionOnLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Game")
        {
            GetComponent<Transform>().position = new Vector3(0.9f, 1.81f, -13.9f);
            GetComponent<CahangePositionOnLoad>().enabled = false;
        }
        
    }
}
