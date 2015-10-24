using UnityEngine;
using System.Collections;

public class Monkey : MonoBehaviour {
    //left click variable instead of put 0
    public int leftClick = 0;
    //save mouse positions
    public Vector2 oldMousePosition;
    public Vector2 newMousePosition;
    //moving options
    public float moveSpeed;
    public float jumpHeight;

    // Use this for initialization
    void Start()
    {
        oldMousePosition = Vector2.zero;
        newMousePosition = Vector2.zero;
        moveSpeed = 8;
        jumpHeight = 18;
    }

    // Update is called once per frame
    void Update()
    {
        //if delta is valid
        if (GetDeltaMouse())
        {
            //move
            Debug.Log("will move");
            MonkeyMove();
            //reset the delta after move
            ResetMousePosition();
        }
    }

    //get delta vector to check it is valid swipe or not
    private bool GetDeltaMouse()
    {
        //when mouse down, save the position
        if (Input.GetMouseButtonDown(leftClick))
        {
            oldMousePosition = Input.mousePosition;
        }
        //when mouse up, save the position
        if (Input.GetMouseButtonUp(leftClick))
        {
            newMousePosition = Input.mousePosition;
            //get delta
            return (Vector2.Distance(oldMousePosition,newMousePosition) > 60);
        }
        //when only mouse down
        return false;        
    }

    //reset old and new positions
    private void ResetMousePosition()
    {
        if ((oldMousePosition.magnitude + newMousePosition.magnitude) > 0)
        {
            oldMousePosition = Vector2.zero;
            newMousePosition = Vector2.zero;
        }
    }

    //move the monkey by delta vector
    private void MonkeyMove()
    {
        //get angle of swipe from stright right to swipe vector
        float angle = Vector2.Angle(Vector2.right, newMousePosition - oldMousePosition);
        //if angle from 0 to 60, right jump
        //if angle from 60 to 120, up jump
        //if angle from 120 to 180, left jump
        //if angle from 180 to 240, left drop
        //if angle from 240 to 300, drop
        //if angle from 300 to 360, right drop
        if (angle >= 0 && angle < 60)
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, jumpHeight);
        else if(angle >= 60 && angle < 120)
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
        else if (angle >= 120 && angle < 180)
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, jumpHeight);
        //else if (angle >= 180 && angle < 240)
            //GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        //else if (angle >= 240 && angle < 300)
            //GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y);
        //else if (angle >= 300 && angle < 360)
            //GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
    }
}
