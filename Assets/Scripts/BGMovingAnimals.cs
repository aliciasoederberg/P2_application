using UnityEngine;
using System.Collections;

public class BGMovingAnimals : MonoBehaviour {

    public Transform[] patrolpoints;
    public float enemySpeed;

    private int currentPoint;


    // Use this for initialization
    void Start()
    {

        transform.position = patrolpoints[0].position;
        currentPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position == patrolpoints[currentPoint].position)
        {
            currentPoint++;
        }

        if (currentPoint >= patrolpoints.Length)
        {
            currentPoint = 0;
        }

        transform.position = Vector3.MoveTowards(transform.position, patrolpoints[currentPoint].position, enemySpeed * Time.deltaTime);
    }
}
