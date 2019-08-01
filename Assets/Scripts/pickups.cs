using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickups : MonoBehaviour
{
    private GameController gameController;

    public int scoreValue;


    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent <GameController>();
        }
    }

    void OnTriggerEnter(Collider other){

        if(other.tag == "Player"){

            gameObject.SetActive(false);
            gameController.AddScore(scoreValue);
        }
    }

}
