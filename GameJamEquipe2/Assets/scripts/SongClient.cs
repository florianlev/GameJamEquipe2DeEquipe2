using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongClient : MonoBehaviour
{
    // Start is called before the first frame update
    private Timer timer;

    private AudioSource audioSource;
    public AudioClip scarred;



    void Start()
    {
        timer = FindObjectOfType<Timer>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!timer.playerIsAlive)
        {
            audioSource.clip = scarred;
            audioSource.Play();
        }
    }
}
