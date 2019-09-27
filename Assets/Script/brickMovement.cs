using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brickMovement : MonoBehaviour
{
    private float gravity = -1;
    private float acceleration; //adding speed to the gravity

    private float lastTime;

    private static int borderX = 15, borderY = 20;

    private Vector3 rotationPoint;

    // Start is called before the first frame update
    void Start()
    {
        acceleration = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) //if pressing the up arrow or w, the game object will rotate
        {
            //transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);
            transform.Rotate(0, 0, 90, Space.World); //it needs to rotate in space world, otherwise it will be messy
            if (!isHitBorder())
            {
                transform.Rotate(0, 0, -90, Space.World); //if it hit the border, then rotate back to ensure it won't hit the border
                //transform.RotateAround(transform.TransformPoint(rotationPoint),new Vector3(0,0,1), -90);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) //if pressing the left arrow or a, the game object will move left (x-axis)
        {
            transform.Translate(-1, 0, 0, Space.World);
            if (!isHitBorder())
                transform.Translate(1, 0, 0, Space.World);
        }
        if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) //if pressing the right arrow or d, the game object will move right (x-axis)
        {
            transform.Translate(1, 0, 0, Space.World);
            if (!isHitBorder())
                transform.Translate(-1, 0, 0,Space.World);
        }

        if(Time.time - lastTime > (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S) ? 0.5f / 5: 0.5f)) //if pressing the down arrow or s, the game object will drop down quickly
        {
            transform.Translate(0, gravity, 0,Space.World);
            lastTime = Time.time;
            if (!isHitBorder())
            {
                float f = Mathf.Abs(gravity);
                transform.Translate(0, f, 0,Space.World);
            }
        }
    }

    bool isHitBorder()
    {
        foreach(Transform children in transform)
        {
            int x = Mathf.RoundToInt(children.transform.position.x); //get the x of the gameObject
            int y = Mathf.RoundToInt(children.transform.position.y); //get the y of the gameObject
            if (x<=0 || x >= borderX || y<=0|| y >= borderY)
            {
                return false;
            }
        }
        return true;
    }
}
