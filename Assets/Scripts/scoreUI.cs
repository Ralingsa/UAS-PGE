using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class scoreUI : MonoBehaviour
{
    public Text txtScore;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        txtScore.text = data.Score.score + "";
        if (data.Score.score == 10)
        {
            SceneManager.LoadScene("win");
        }
    }
}
