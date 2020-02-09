using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    int score = 0;
    public static ScoreManager scoreManager;
    public Text scoreText;

    private void Start()
    {
        if(ScoreManager.scoreManager==null)
        {
            ScoreManager.scoreManager = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(this.scoreText == null)
        {
            this.scoreText = GameObject.Find("Text").GetComponent<Text>();
            this.scoreText.text = this.score.ToString();
        }
    }

    public void RaiseScore (int s)
    {
        score += s;
        Debug.Log(score);
        scoreText.text = score.ToString();

        if(this.score == 3)
        {
            SceneManager.LoadScene("2");
        }
    }
}
