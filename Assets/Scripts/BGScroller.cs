using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizeZ;
    public float newScroll;

    private GameController gameController;
    
    private Vector3 startPosition;
    void Start()
    {
        startPosition = transform.position;

        GameObject gameControllerObject = GameObject.FindWithTag ("GameController");

        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent <GameController>();
        }
    }

    void Update()
    {
        float newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSizeZ);

        transform.position = startPosition + Vector3.forward * newPosition;
    }

    void FixedUpdate()
    {
        if(gameController.score >= 100){
            scrollSpeed = newScroll;
        }
    }
}
