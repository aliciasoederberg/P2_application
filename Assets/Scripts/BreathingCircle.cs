 using UnityEngine;
using System.Collections;

public class BreathingCircle : MonoBehaviour {

    public float InhaleTime = 3;
    public float ExhaleTime = 6;
    public float HoldBreath = 1;
    public float InhaleSizeShift = 0.01f;
    public float ExhaleSizeshift = 0.005f;
    bool iCanInhale;
    bool iCanExhale;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Controller());
    }

    // Update is called once per frame
    void Update()
    {
         if(iCanInhale == true)
        {
            this.transform.localScale += new Vector3(InhaleSizeShift, InhaleSizeShift, 0f);
        }
         else if(iCanExhale == true)
        {
            this.transform.localScale += new Vector3(-ExhaleSizeshift, -ExhaleSizeshift, 0f);
        }

    }

    public IEnumerator Controller()
    {
        while (true)
        {

            print("Heyoo");
            iCanInhale = true;
            yield return new WaitForSeconds(InhaleTime);
            iCanInhale = false;
            print("Holding Breath");
            yield return new WaitForSeconds(HoldBreath);
            iCanExhale = true;
            print("I will Exhale now");
            yield return new WaitForSeconds(ExhaleTime);
            print("I have Exhaled");
            iCanExhale = false;
            yield return new WaitForSeconds(1f);

        }
    }
}

