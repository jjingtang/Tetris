using UnityEngine;

public class brickAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator brickAnimatorController;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            brickAnimatorController.SetTrigger("switch");
        }
    }
}
