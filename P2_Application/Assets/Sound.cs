using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class Sound : MonoBehaviour {

    public AudioSource sound;
    private bool inTheZone = false;

    private float fadeSpeed = 0.5f;



    void Update()
    {

        if (inTheZone == true)
        {
            sound.volume = 0.0f;
            sound.Play();
            StartCoroutine("FadeIn");
            
            print("PLAAAAAY!!!");
        }

        if (inTheZone == false)
        {
            StartCoroutine("FadeOut");
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


    public IEnumerator FadeOut()
    {
        while (sound.volume > 0.1)
        {
            sound.volume -= 0.1f * Time.deltaTime;
            //sound.volume = Mathf.Lerp(sound.volume, 0.0f, fadeSpeed * Time.deltaTime);
            yield return null;
        }
        sound.volume = 0.0f;
        sound.Stop();
        /*while (sound.volume > 0.1f)
        {
            sound.volume -= 0.1f * Time.deltaTime;
        }
        sound.volume = 0;
        sound.Stop();
        playing = false;*/
    }

    public IEnumerator FadeIn()
    {
        while (sound.volume < 0.9)
        {
            sound.volume += 0.01f * Time.deltaTime;
            //sound.volume = Mathf.Lerp(sound.volume, 1.0f, fadeSpeed * Time.deltaTime);
            yield return null;
        }
        sound.volume = 1.0f;

        /*sound.Play();
        sound.volume = volumeLow;
        playing = true;

        while (sound.volume < 1.0f)
        {
            sound.volume += 0.0001f * Time.deltaTime;
        }*/
    }

}
