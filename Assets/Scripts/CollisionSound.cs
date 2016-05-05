using UnityEngine;
using System.Collections;

public class CollisionSound : MonoBehaviour {

    public AudioSource Sound;

 
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "Character")
        {
        Sound.Play();   
        }
    }
}
