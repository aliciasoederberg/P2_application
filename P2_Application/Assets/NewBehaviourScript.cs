using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

    public Transform[] points;
    public float speed;
    private int startlocation;

	// Use this for initialization
	void Start () {

        transform.position = points[0].position;
        startlocation = 0;
	
	}
	
	// Update is called once per frame
	void Update () {

        if (transform.position == points[startlocation].position)
        {
            startlocation++;
        }
        if (startlocation == points.Length)
        {
            startlocation = 0;
        }

        transform.position = Vector3.MoveTowards(transform.position, points[startlocation].position, speed * Time.deltaTime);
	
	}
}
