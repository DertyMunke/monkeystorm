using UnityEngine;
using System.Collections;

public class Monkey : MonoBehaviour {
    //left click variable instead of put 0
    public int leftClick = 0;
    //check appropiate swipe length
    public int swipeLengh = 40;
    //save mouse positions
    public Vector2 oldMousePosition;
    public Vector2 newMousePosition;
    //moving options
    public float moveSpeed;
    public float jumpHeight;
    public float jumpS;
    public float moveS;
    //limit angle
    public float limitAngle;
    //ground check
    public Transform branchCheck;
    public float branchCheckRadius;
    public LayerMask whatIsBranch;
    private bool grounded;
    //give up grap and hold back grap
    Collider2D coll;
    private bool pass;

    // Use this for initialization
    void Start()
    {
        oldMousePosition = Vector2.zero;
        newMousePosition = Vector2.zero;
        moveSpeed = 10;
        jumpHeight = 15;
        jumpS = 1.5f;
        moveS = 0.8f;
        limitAngle = 70;
        branchCheckRadius = 0.1f;
        coll = GetComponent<Collider2D>();
        pass = true;
    }

    //check per sec; use this for physics
    void FixedUpdate()
    {
        //set grounded if it is attached to branches
        grounded = Physics2D.OverlapCircle(branchCheck.position, branchCheckRadius, whatIsBranch);
    }

    // Update is called once per frame
    void Update()
    {
        //if delta is valid
        if (GetDeltaMouse())
        {
            //move
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
            return (Vector2.Distance(oldMousePosition,newMousePosition) > swipeLengh);
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
        //presets for directions
        int rightD = 0;
        int leftD = 1;
        int straightD = 2;
        int upD = 3;
        int downD = 4;

        //get the directions for up or down
        int yD = GetYD(upD, downD);
        //get the directions for right, left, straight
        int xD = GetXD(rightD, leftD, straightD);

        //if xD is right and if yD is up, right jump
        //if xD is straight and if yD is up, straight up jump
        //if xD is left and if yD is up, left jump
        //if xD is left and if yD is down, left little move
        //if xD is straight and if yD is down, drop
        //if xD is right and if yD is down, right little move

        
        move(rightD, leftD, straightD, upD, downD, xD, yD);
    }

    //get the directions for right, left, straight 
    private int GetXD(int r, int l, int s)
    {
        //get an angle of swipe from x-axis to swipe vector
        float angle = Vector2.Angle(Vector2.right, newMousePosition - oldMousePosition);

        //angle limits
        float rightLimit = limitAngle;
        float leftLimit = 180 - limitAngle;

        //angle will be from 0 to 180, need direction or checking axis
        if (angle < 0 || angle > 180)
            Debug.Log("angle error");
        //if angle from 0 to rightLimit, right
        if (angle < rightLimit)
            return r;
        //if angle from 180 to leftLimit, left
        else if (angle > leftLimit)
            return l;
        //if angle between limits, straight
        else 
            return s;

    }

    //get the directions for up or down
    private int GetYD(int u, int d)
    {
        //the vector we will compute
        Vector2 v = oldMousePosition - newMousePosition;

        //if y <0, up; if y >0 down
        if (v.y < 0)
            return u;
        else
            return d;
    }
    
    //move by directions
    private void move(int rightD, int leftD, int straightD, int upD, int downD, int xD, int yD)
    {
        //jump if chacco is on branches
        //up directions
        if (yD == upD && grounded)
        {
            //if xD is right and if yD is up, right jump
            if (xD == rightD)
                GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, jumpHeight);
            //if xD is straight and if yD is up, straight up jump
            else if (xD == straightD)
                StraightJump();
            //if xD is left and if yD is up, left jump
            else
                GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, jumpHeight);

           
        }
        //down directions
        else
        {
            //if xD is right and if yD is down, right little move
            if (xD == rightD)
                GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed * moveS, GetComponent<Rigidbody2D>().velocity.y);
            //if xD is straight and if yD is down, drop
            else if (xD == straightD)
                Drop();
            //if xD is left and if yD is down, left little move
            else
                GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed * moveS, GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    //drop move
    private bool Drop()
    {
        //if it attached to branches, make monkey isTrigger
        if(grounded)
            coll.isTrigger = true;

        //return true, if it is trigger; otherwise false
        return coll.isTrigger;
    }

    //straight jump, if jump it will pass one branch and hold back the grap
    private void StraightJump()
    {
        coll.isTrigger = true;
        pass = false;
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight * jumpS);
    }

    //whenever monkey enter the colliders, it means it will pass them
    void OnTriggerEnter2D(Collider2D other)
    {
        pass = true;
    }
    
    //whenever monkey pass the collider, trigger set to false
    void OnTriggerExit2D(Collider2D other)
    {
        if(pass)
        coll.isTrigger = false;
    }
}
