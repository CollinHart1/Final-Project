using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explode;
    public GameObject playerExplode;
    public AudioSource source;
    public AudioClip clip1;
    public int scoreValue;

    private GameController gameController;

    void Start(){
        source.clip = clip1;

        GameObject gameControllerObject = GameObject.FindWithTag ("GameController");

        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent <GameController>();
        }
    }
    void OnTriggerEnter(Collider other){
        if (other.CompareTag ("Boundry") || other.CompareTag ("Enemy") || other.CompareTag ("Faster"))
        {
            return;
        }
        if (explode != null)
        {
            Instantiate (explode, transform.position, transform.rotation);
        }

        if (other.tag == "Player")
        {
            Instantiate (playerExplode, other.transform.position, other.transform.rotation);
            source.Play();
            gameController.gameOver();
        }

        gameController.AddScore(scoreValue);
        Destroy(gameObject);
        Destroy(other.gameObject);
        
    }
}
