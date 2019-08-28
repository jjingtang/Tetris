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
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            //transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);
            transform.Rotate(0, 0, 90);
            if (!isHitBorder())
            {
                transform.Rotate(0, 0, -90);
                //transform.RotateAround(transform.TransformPoint(rotationPoint),new Vector3(0,0,1), -90);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(-1, 0, 0);
            if (!isHitBorder())
                transform.Translate(1, 0, 0);
        }
        if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(1, 0, 0);
            if (!isHitBorder())
                transform.Translate(-1, 0, 0);
        }

        if(Time.time - lastTime > (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S) ? 0.5f / 5: 0.5f))
        {
            transform.Translate(0, gravity, 0);
            lastTime = Time.time;
            if (!isHitBorder())
            {
                float f = Mathf.Abs(gravity);
                transform.Translate(0, f, 0);
            }
        }
    }

    bool isHitBorder()
    {
        foreach(Transform children in transform)
        {
            int x = Mathf.RoundToInt(children.transform.position.x);
            int y = Mathf.RoundToInt(children.transform.position.y);
            if (x<=0 || x >= borderX || y<=0|| y >= borderY)
            {
                return false;
            }
        }
        return true;
    }
}
