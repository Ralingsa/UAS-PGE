using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneCtrl : MonoBehaviour
{
    public bool isEscapeToExit;

    public void mulaiPermainan()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("gameplay");
    }

    public void kemabaliKeMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("menu");
    }

    public void retry()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("gameplay");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isEscapeToExit)
            {
                Application.Quit();
            }
            else
            {
                kemabaliKeMenu();
            }
        }
    }
}
