using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour {

    public AudioSource sound;
    private float volumeLow = 0.00001f;
    private float volumeHigh = 1.0f;
    private bool inTheZone = false;
    private bool playing = false;

    void Update()
    {

        if (inTheZone == true && playing == false)
        {
            FadeMusicIn();
            print("PLAAAAAY!!!");
        }

        if (inTheZone == false)
        {
            FadeMusicOut();
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "Mini_Squid_Lid")
        {
            inTheZone = true;
            print("registered!");
        }

    }

    void OnTriggerExit2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "Mini_Squid_Lid")
        {
            inTheZone = false;
            print("outofzone");
        }
    }

    public void FadeMusicOut()
    {
        while (sound.volume > 0.1f)
        {
            sound.volume -= 0.1f * Time.deltaTime;
        }
        sound.volume = 0;
        sound.Stop();
        playing = false;
    }

    public void FadeMusicIn()
    {
        sound.Play();
        sound.volume = volumeLow;
        playing = true;

        while (sound.volume < 1.0f)
        {
            sound.volume += 0.0001f * Time.deltaTime;
        }
    }

}
