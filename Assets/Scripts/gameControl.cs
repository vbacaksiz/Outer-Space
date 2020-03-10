using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameControl : MonoBehaviour
{
    public GameObject asteroid;
    public Vector3 randomPos;
    public float starting;
    public float creating;
    public float loop;
    public Text text;
    public Text text2;
    public Text text3;
    bool gameOverControl=false;
    bool tryAgain = false;

    GameObject asteroidControl;
    asteroidControl asteroidSpeed;

    int score;
    void Start()
    {
        score = 0;
        text.text = "Score = " + score;
        StartCoroutine(create());
        asteroidControl = GameObject.FindGameObjectWithTag("asteroid");
        asteroidSpeed = asteroid.GetComponent<asteroidControl>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)&&tryAgain)
        {
            SceneManager.LoadScene("SpaceShooter");
        }
    }

    IEnumerator create()
    {
        
        yield return new WaitForSeconds(starting);
        asteroidSpeed.fxSpeed = -3f;
        while (true)
        {
            for(int i=0;i<10;i++)
            {
                Vector3 vec = new Vector3(Random.Range(randomPos.x, -randomPos.x), 0, randomPos.z);
                Instantiate(asteroid, vec, Quaternion.identity);
                yield return new WaitForSeconds(creating);
            }
            asteroidSpeed.fxSpeed = asteroidSpeed.fxSpeed * 1.15f;
            if (gameOverControl)
            {
                text3.text = "PRESS Q FOR TRY AGAIN";
                tryAgain = true;
                break;
            }
        }
        yield return new WaitForSeconds(loop);
    }
    public void UpperScore(int newScore)
    {
        score += newScore;
        text.text = "Score = " + score;
    }
    public void gameOver()
    {
        
        gameOverControl = true;
        text2.text = "GAME OVER";
    }
}
