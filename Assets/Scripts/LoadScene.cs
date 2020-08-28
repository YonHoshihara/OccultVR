using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{   
    
    // Start is called before the first frame update
    public string SceneName;
    public GameObject fire;
    public GameObject fade;
    void Start()
    {
        
    }
    public void Load()
    {
        StartCoroutine(StartGame());
    }
    private IEnumerator StartGame()
    {
        fire.SetActive(true);
      
        yield return new WaitForSeconds(5f);
        fade.SetActive(true);
        fire.SetActive(false);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneName);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
