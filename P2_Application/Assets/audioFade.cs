using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class audioFade : MonoBehaviour {

    public AudioSource sound;
    private GameObject fish;

    void Start()
    {
        fish = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (fish.transform.position.y < -2)
        {
            sound.minDistance = 5;
        }

    }

    /*void OnTriggerStay2D(Collider2D other)
    {
        if (other.attachedRigidbody)
        {
            sound.minDistance = 5;
            sound.volume = 1;
            print("IM HERE");

        }

    }*/
}
