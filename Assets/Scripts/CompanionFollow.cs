using UnityEngine;
using System.Collections;

public class CompanionFollow : MonoBehaviour {

    private Vector2 charecterLocation;
    private float moveSpeed = 0f;
    private float playerX;
    private float playerY;
    bool attached2Player = false;
    bool greetingPlayer = false;
    public float offSetX;
    public float offSetY;

	// Use this for initialization
	void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (attached2Player == true)
        {
            moveSpeed = 0.12f;
        }
        else if (greetingPlayer == true)
        {
            moveSpeed = 0.001f;
        }
        else
        {
            moveSpeed = 0f;
        }

        playerX = GameObject.Find("Charecter").transform.position.x;
        playerY = GameObject.Find("Charecter").transform.position.y;

        charecterLocation = new Vector3(playerX+offSetX, playerY+offSetY, 0.0f);

        transform.position = Vector2.Lerp(transform.position, charecterLocation, moveSpeed);
    }


    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "Charecter")
        {
            attached2Player = true;
        }
        else if (hitInfo.name == "GreetingZone")
        {
            greetingPlayer = true;
        }
    }
}
