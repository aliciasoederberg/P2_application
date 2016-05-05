using UnityEngine;
using System.Collections;

public class CompanionFollow : MonoBehaviour {

    public string companionName;
    public string companionDesti;
    private Vector3 charecterLocation;
    private float moveSpeed = 0f;
    private float playerX;
    private float playerY;
    GameObject parent;
    GameObject child;
    bool attached2Player = false;
    bool greetingPlayer = false;
    bool readyToParent = true;
    bool parented = false;
    public float offSetX;
    public float offSetY;
    private Vector3 mousePosition;
    private Vector3 touchPosition;
    public float moveSpeedfollowMode = 0.01F;
    private Vector3 lastPosition;
    Rigidbody2D rb2d;

    // Use this for initialization
    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        child = GameObject.Find(companionName);
        parent = GameObject.Find(companionDesti);
    }

    // Update is called once per frame
    void Update()
    {

        lastPosition = transform.position;

        if (transform.position == charecterLocation)
        {
            //print("Kebab jeg er der nu");
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
            moveSpeed = 0.01f;
        }
        else
        {
            moveSpeed = 0f;
        }

        if (readyToParent == true)
        {
            playerX = GameObject.Find(companionDesti).transform.position.x;
            playerY = GameObject.Find(companionDesti).transform.position.y;
            charecterLocation = new Vector3(playerX + offSetX, playerY + offSetY, 0.0f);
            transform.position = Vector2.Lerp(transform.position, charecterLocation, moveSpeed);
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 mousePos = Input.mousePosition;

                Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
                mousePos.x = mousePos.x - objectPos.x;
                mousePos.y = mousePos.y - objectPos.y;
                
                float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
                
            }
            
        }
    }


    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "Character")
        {
            attached2Player = true;
        }
        else if (hitInfo.name == "GreetingZone")
        {
            greetingPlayer = true;
        }
    }
}
