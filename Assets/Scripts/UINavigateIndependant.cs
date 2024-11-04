using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UINavigateIndependant : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    public void ChooseScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
