using UnityEngine;
using System.Collections;

public class BreathingCircle : MonoBehaviour {

    public int DelayInhale;
    public int DelayExhale;
    public int HoldBreath;
    bool iCanInhale;
    bool iCanExhale;
    bool iCanHold;
    bool iCanHoldE;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Controller());
    }

    // Update is called once per frame
    void Update()
    {

        if (iCanInhale == true && iCanHold == true)
        {
            StopCoroutine(Exhale());
            StartCoroutine(Inhale());
            iCanHold = false;
        }
        else if (iCanExhale == true && iCanHoldE == true)
        {
            StopCoroutine(Inhale());
            StartCoroutine(Exhale());
            iCanHoldE = false;
        }
    }

    public IEnumerator Controller()
    {
        while (true)
        {

            print("Heyoo");
            iCanInhale = true;
            iCanHold = true;
            yield return new WaitForSeconds(3f);
            iCanInhale = false;
            print("Holding Breath");
            yield return new WaitForSeconds(1f);
            print("I will Exhale now");
            iCanHoldE = true;
            iCanExhale = true;
            yield return new WaitForSeconds(6f);
            iCanExhale = false;
            print("I have Exhaled");
            yield return new WaitForSeconds(1f);

        }
    }

    public IEnumerator Inhale()
    {
        while (true)
        {
            print("IIIIIINHALING");
            this.transform.localScale += new Vector3(0.1f, 0.1f, 0f);
            yield return new WaitForSeconds(0.1f);
        }
    }

    public IEnumerator Exhale()
    {
        while (true)
        {
            print("Exhaaaaaling");
            this.transform.localScale -= new Vector3(0.05f, 0.05f, 0f);
            yield return new WaitForSeconds(0.1f);
        }
    }


}

