using UnityEngine;
using System.Collections;

public class CompanionFollow : MonoBehaviour {

    private Vector3 charecterLocation;
    private float moveSpeed = 0f;
    private float playerX;
    private float playerY;
    GameObject parent;
    GameObject child;
    bool attached2Player = false;
    bool greetingPlayer = false;
    bool readyToParent = true;
    public float offSetX;
    public float offSetY;
    public KeyCode moveUp;
    public KeyCode moveDown;
    public KeyCode MoveLeft;
    public KeyCode MoveRight;
    Rigidbody2D rb2d;

    // Use this for initialization
    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        child = GameObject.Find("Companion (2)");
        parent = GameObject.Find("Charecter");
    }
	
	// Update is called once per frame
	void Update ()
    {

        if(transform.position == charecterLocation)
        {
            print("Kebab jeg er der nu");
            //attached2Player = false;
            readyToParent = false;
            child.transform.parent = parent.transform;
        }


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

        if (readyToParent == true)
        {
            playerX = GameObject.Find("Charecter").transform.position.x;
            playerY = GameObject.Find("Charecter").transform.position.y;
            charecterLocation = new Vector3(playerX + offSetX, playerY + offSetY, 0.0f);
            transform.position = Vector2.Lerp(transform.position, charecterLocation, moveSpeed);
        }
        else
        {
            if (Input.GetKey(moveUp))
            {
                rb2d.velocity = new Vector2(0, 1);
            }
            else if (Input.GetKey(moveDown))
            {
                rb2d.velocity = new Vector2(0, -1);
            }
            else if (Input.GetKey(MoveLeft))
            {
                rb2d.velocity = new Vector2(-1, 0);
            }
            else if (Input.GetKey(MoveRight))
            {
                rb2d.velocity = new Vector2(1, 0);
            }
            else
            {
                rb2d.velocity = new Vector2(0, 0);
            }
        }

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
