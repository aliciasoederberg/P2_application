using UnityEngine;
using System.Collections;

public class CharecterMovement : MonoBehaviour {

    public KeyCode moveUp;
    public KeyCode moveDown;
    public KeyCode MoveLeft;
    public KeyCode MoveRight;
    public float XplayerPosition;
    public float YplayerPosition;
    public Vector3 playerPos;
    Rigidbody2D rb2d;


    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        XplayerPosition = this.transform.position.x;
        YplayerPosition = this.transform.position.y;
        playerPos = new Vector3(XplayerPosition, YplayerPosition, 0);


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
