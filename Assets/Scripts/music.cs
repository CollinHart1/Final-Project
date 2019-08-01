using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    public AudioSource source1;
    public AudioClip clip1;
    public GameObject player;

    void Start()
    {
        source1.clip = clip1;
        source1.Play();

        if(player == false){
            source1.Stop();
        }
    }
}
