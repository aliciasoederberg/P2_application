using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuText : MonoBehaviour {

    Text rsltext;
    string result;
    int alo;

	// Use this for initialization
	void Start () {
        rsltext = GameObject.Find("Information").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Txt2Field()
    {
        rsltext.text = result;
    }

    public void Instructions()
    {
        result = "This game is about relaxing basicly you have to roam around and breath in a certain way \n 1) When the circle in the middle grows     take in air through you nose \n 2) Wait for about a sec \n 3) blow out the air through you mouth along with the circle growing smaller";
        Txt2Field();
    }

    void Settings()
    {
        result = "Set a timer for how long you want to play this is not necessarry";
        Txt2Field();
    }
}
