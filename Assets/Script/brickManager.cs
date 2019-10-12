using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brickManager : MonoBehaviour
{
    public GameObject[] bricks; //store all types of bricks in the array

    // Start is called before the first frame update
    void Start()
    {
        GenerateNewBrick();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateNewBrick()
    {
        //generate a new brick from the array (7 types of bricks) by using a random number to pick a random type of brick and initate at the empty object "newBrick" position 
        Instantiate(bricks[Random.Range(0, bricks.Length)], transform.position, Quaternion.identity);
    }
}
