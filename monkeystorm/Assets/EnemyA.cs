using UnityEngine;
using System.Collections;

public class EnemyA : MonoBehaviour {

	public Transform groundCheck;
	public Transform groundCheck2;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	public LayerMask whatIsGround2;
	private bool grounded; // original
	private bool grounded2;
	
	private float jumpHeight = 20F;
	private float moveSpeed = 10.0F;
	private float downHeight = 5.5F;
	private float waitTime = 0.65F;
	
	private bool stopped;
	private bool jump;
	
	private float leftX = -22.0f;
	private float rightX = 20.0f;
	private float heightY = 2.0f;
	
	private int randomJump;	
	private Vector2 myPosition;
	private Vector2 leftLimit;
	private Vector2 rightLimit;
	
	Collider2D gorilla;	
	Collider2D gorilla2;
	
	
	// Use this for initialization
	void Start () {
		gorilla = GetComponent<CircleCollider2D>();	
		gorilla2 = GetComponent<BoxCollider2D>();
		groundCheckRadius = 1.0f;
		stopped = false;
		jump = false;	

		
		StartCoroutine (run (waitTime));		
	}
	void Update () {
		
	}
	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
		grounded2 = Physics2D.OverlapCircle(groundCheck2.position, groundCheckRadius, whatIsGround2);

		if (!grounded && grounded2) {
			gorilla.isTrigger = true;
			if (!jump)			
				gorilla2.isTrigger = false;
			else
				gorilla2.isTrigger = true;
		} else if (grounded && !grounded2) {
			if (!jump) {
				gorilla.isTrigger = false;
			} else {
				gorilla.isTrigger = true;
			}
			gorilla2.isTrigger = true;
		} else if (grounded && grounded2) {
			gorilla.isTrigger = true;
			gorilla2.isTrigger = true;
		} else {
			gorilla.isTrigger = false;
			gorilla2.isTrigger = true;
		}
	}


	bool ckHeight(float heightY) {
		myPosition = transform.position;
		if (myPosition.y > heightY) {
			return true;
		} else {
			return false;
		}
	}
	bool ckPlace() {
		myPosition = transform.position;
		if (myPosition.x < leftX || myPosition.x > rightX) {
			return false;
		} else
			return true;
	}
	bool ckRight() {
		rightLimit = transform.position;
		if (rightLimit.x > rightX) {
			return false;
		} else
			return true;
	}
	bool ckLeft() {
		leftLimit = transform.position;
		if (leftLimit.x < leftX) {		
			return false;
		} else
			return true;
	}	
	
	void JumpR() {// move to the right
		//yield return new WaitForSeconds (waitTime);
		if (grounded || grounded2) {//
			jump = true;
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpHeight);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		}	
	}
	void JumpL() {// move to the left

		if (grounded || grounded2) {//
			jump = true;
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpHeight);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		}	
	}
	bool ckJump()
	{
		if (jump)
			return true;
		else
			return false;
	}
	void JumpUp() {
		if (grounded || grounded2) {// 
			jump = true;
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpHeight);
		} 		
	}
	void JumpDown() {
		if (ckHeight (heightY)) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, -downHeight);
		} 
	}
	IEnumerator run(float waitTime) {		
		bool leftMove;// = false;
		bool rightMove;// = false;
		int number = Random.Range(1, 100); // creates a number between 1 and 100 randomly
		
		while (!stopped) {

			leftMove = ckLeft();
			rightMove = ckRight();			
			
			if(rightMove && leftMove) {
				if(number%2 == 0) {
					JumpR();					
				} else {
					JumpL();					
				}
			} else if (leftMove) {
				JumpL();
				number = 1;
			} else if (rightMove) {
				JumpR();
				number = 2;
			}

			yield return new WaitForSeconds (waitTime);
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		jump = true;		
	}
	
	/*void OnTriggerStay2D(Collider2D other)
	{
		jump = false;
	}*/
	
	//whenever monkey pass the collider, trigger set to false
	void OnTriggerExit2D(Collider2D other)
	{
		jump = false;
	
	}
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Monkey") {//coll.gameObject.tag == "Enemy" || 
			//Destroy (coll.gameObject);
			//coll.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(10,10) * 400.0f);
		}
		
	}
}
