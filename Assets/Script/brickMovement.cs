using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brickMovement : MonoBehaviour
{
    private float gravity = -1;
    private float acceleration; //adding speed to the gravity

    private float lastTime;

    private static int borderX = 12, borderY = 20;

    private Vector3 rotationPoint;

    private static Transform[,] grid = new Transform[borderX, borderY]; //store the x and y value of the bricks into the array 

    // Start is called before the first frame update
    void Start()
    {
        if (!isHitBorder())
        {
            Debug.Log("Game Over");
            UIManager.Instacnce.GameOver();
            Destroy(gameObject);
        }
        acceleration = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) //if pressing the up arrow or w, the game object will rotate
        {
            /*
            //transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);
            transform.Rotate(0, 0, 90, Space.World); //it needs to rotate in space world, otherwise it will be messy
            if (!isHitBorder())
            {
                transform.Rotate(0, 0, -90, Space.World); //if it hit the border, then rotate back to ensure it won't hit the border
                //transform.RotateAround(transform.TransformPoint(rotationPoint),new Vector3(0,0,1), -90);
            }*/
            //rotate
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);
            if (!isHitBorder())
                transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -90);
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
            //transform.Translate(0, gravity, 0,Space.World);
            transform.position += new Vector3(0, -1, 0);
            
            if (!isHitBorder())
            {
                float f = Mathf.Abs(gravity);
                //transform.Translate(0, f, 0,Space.World);
                transform.position -= new Vector3(0, -1, 0);

                AddToGrid(); //add the brick position to the grid array
                CheckLine();
                this.enabled = false; //disable the script so the user cannot move it anymore
                FindObjectOfType<brickManager>().GenerateNewBrick(); //call the function to generate a new one
            }
            lastTime = Time.time;
        }
    }

    bool isHitBorder()
    {
        foreach(Transform children in transform)
        {
            int x = Mathf.RoundToInt(children.transform.position.x); //get the x of the gameObject
            int y = Mathf.RoundToInt(children.transform.position.y); //get the y of the gameObject
            if (x< 0 || x >= borderX || y< 0|| y >= borderY)
            {
                return false;
            }

            if (grid[x, y] != null) //if the bricks collide with other bricks
            {
                return false;
            }
        }
        return true;
    }
    void AddToGrid()
    {
        foreach (Transform children in transform)
        {
            //loop all the children and add them to the grid array
            int x = Mathf.RoundToInt(children.transform.position.x); //get the x of the gameObject
            int y = Mathf.RoundToInt(children.transform.position.y); //get the y of the gameObject

            grid[x, y] = children;
            Debug.Log(x+","+ y);
        }
    }

    void CheckLine()
    {
        
        Debug.Log("CheckLine()");//落定一个方块检查一次
        for (int i = borderY - 1; i >= 0; i--)
        {
            //Debug.Log("borderY= "+i);//落定一个方块检查一次
            if (completeLine(i)) //if the line is full, then clear the line
            {
                Debug.Log("clear line");
                ClearLine(i); //clear the line
                Drop(i); //the bricks above this line will drop
            }
        }
    }

    bool completeLine(int i)
    {
        Debug.Log("completeLine(int i)");
        for (int a = 0; a < borderX; a++)
        {
            if (grid[a, i] == null)
            {
                return false;
            }
        }
        return true;
    }

    void ClearLine(int i)
    {
        Debug.Log("ClearLine(int i)");
        for (int a = 0; a < borderX; a++)
        {
            //if (grid[a, i] == null)
            //{
                Destroy(grid[a, i].gameObject); //destory the gameobject on this line
                grid[a, i] = null; //reset the array
            //}
        }
    }

    void Drop(int i)
    {
        for (int a = i; a < borderY; a++) //loop all the elements
        {
            for (int b = 0; b < borderX; b++)
            {
                if (grid[b, a] != null)
                {
                    //Debug.Log("b=" + b + "a =" + a);
                    grid[b, a - 1] = grid[b, a];
                    grid[b, a] = null;
                    grid[b, a - 1].transform.position -= new Vector3(0, 1, 0);
                }
            }
        }
    }
}
