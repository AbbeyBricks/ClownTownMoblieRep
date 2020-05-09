using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public string Test;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadSceneAsync(Test);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

public void MainMenu()
    {
    Time.timeScale = .5f;
    SceneManager.LoadSceneAsync("MainMenu");
    }
}
