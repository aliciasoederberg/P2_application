using UnityEngine;
using System.Collections;

public class Hardcodedsound : MonoBehaviour {

    public AudioSource soundTop;
    public AudioSource soundMiddle;
    public AudioSource soundBottom;
    private GameObject fish;

    // Use this for initialization
    void Start () {

        fish = GameObject.FindGameObjectWithTag("Player");

    }
	
	// Update is called once per frame
	void Update () {

        if (fish.transform.position.y > -2)
        {
            StartCoroutine("FadeIn");
        }
        /*else
        {
            StartCoroutine("FadeOut");
        }*/

    }

    public IEnumerator FadeIn()
    {
        soundBottom.volume = 0.0f;
        soundBottom.Play();
        while (soundBottom.volume < 0.9)
        {
            soundBottom.volume += 0.001f * Time.deltaTime;
            yield return null;
        }
        soundBottom.volume = 1.0f;

    }

    public IEnumerator FadeOut()
    {
        while (soundBottom.volume > 0.1)
        {
            soundBottom.volume -= 0.001f * Time.deltaTime;
            yield return null;
        }
        soundBottom.volume = 0.0f;
        soundBottom.Stop();
    }

}
