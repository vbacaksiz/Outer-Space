using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidDestroy : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExp;

    GameObject gameControl;
    gameControl control;

    void Start()
    {
        gameControl = GameObject.FindGameObjectWithTag("gameControl");
        control = gameControl.GetComponent<gameControl>();
    }

    void OnTriggerEnter(Collider col)
    {
        
        if (col.tag != "Limit")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            control.UpperScore(10);
        }
        if(col.tag == "Player")
        {
            Instantiate(playerExp, col.transform.position, col.transform.rotation);
            control.gameOver();
        }
    }
}
