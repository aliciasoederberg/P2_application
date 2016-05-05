using UnityEngine;
using System.Collections;

public class SpawnObjects : MonoBehaviour {

    public Transform[] spawnObjects;
    public float spawnTime = 4.0f;
    public GameObject interactiveObjects;
    //public GameObject[] Rings;

    // Use this for initialization
    void Start()
    {
        //InvokeRepeating("spawnItems", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawnItems()
    {
        int spawnIndex = Random.Range(0, spawnObjects.Length);//sets index of array randomly
        Instantiate(interactiveObjects, spawnObjects[spawnIndex].position, spawnObjects[spawnIndex].rotation);
    }
}
