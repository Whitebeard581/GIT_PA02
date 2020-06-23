using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] SpawnObject;
    float PositionX;
    public int randomNumb;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObjects", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObjects()
    {
        randomNumb = Random.Range(0, 4);
        PositionX = Random.Range(4, -4f);
        this.transform.position = new Vector3(PositionX, 0, transform.position.z);
        Instantiate(SpawnObject[randomNumb], transform.position, transform.rotation);
    }
}
