using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TouchInput : MonoBehaviour {

    private Vector3 mousePosition;
    private Vector3 touchPosition;
    public float moveSpeed = 0.01F;
    private bool parenting = false;
    private bool gateController = true;
    

    void Update()
    {

        if (parenting == false)
        {
            StopCoroutine(companionInteraction());
            //move by touch
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).deltaPosition);
                transform.position = Vector2.Lerp(transform.position, touchPosition, moveSpeed);
            }

            //move if mouseclicked
            if (Input.GetMouseButton(0))
            {
                Vector3 mousePos = Input.mousePosition;

                Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
                mousePos.x = mousePos.x - objectPos.x;
                mousePos.y = mousePos.y - objectPos.y;

                float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

                mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);

                /*if (lastPosition.x < transform.position.x)
                {
                    print("going rigth!");
                }
                if (lastPosition.x > transform.position.x)
                {
                    print("going left!");
                }
                if (lastPosition.y < transform.position.y)
                {
                    print("going up!");
                }
                if (lastPosition.y > transform.position.y)
                {
                    print("going down!");
                }*/

            }
        }
        else if (parenting == true && gateController == true)
        {
            StartCoroutine(companionInteraction());
            gateController = false;
        }

    }

    public IEnumerator companionInteraction()
    {
        while(true)
        {
        yield return new WaitForSeconds(3);
            parenting = false;
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.tag == "Companion")
        {
            parenting = true;
        }
    }


}
