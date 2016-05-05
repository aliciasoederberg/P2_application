using UnityEngine;
using System.Collections;

public class CollisionSound : MonoBehaviour {

    public AudioSource Sound;
    public float destructionTimer = 10.0f;



    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "Character")
        {
            Sound.Play();
            GameObject.Destroy(gameObject, destructionTimer);
        }
    }
}
