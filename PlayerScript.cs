using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

	// Declare Variables//
	private Rigidbody2D myRigidbody; //gives my player the ability with other game elements// 

	private Animator myAnimator; //gives my player the ability with other game elements// 

	public float movementSpeed; // public so I can see it in the inspector. Gives me the ability to change the movement speed. //

	private bool facingRight; // Helps control the direction the player is facing 

	[SerializeField] // allows the variable to appear in inspector 
	private Transform[] groundPoints; // An array that will allow us to moniter collisions between player and ground

	[SerializeField] // allows the variable to appear in inspector 
	private float groundRadius; //sets the size of the contact points between the player and the ground 

	[SerializeField] // allows the variable to appear in inspector 
	private LayerMask whatIsGround; //allows us to specify off of which objects the player can jump 

	private bool isGrounded; // are we on the ground or not?

	private bool jump; //true or false based on user input

	[SerializeField] // allows the variable to appear in inspector 
	private float jumpForce; //allows us to set the magnitude of the jump 

	private bool crouch;

	private BoxCollider2D box;

	public bool isAlive;

	public GameObject reset;//this is my reset button

	private Slider healthBar; // a variable name for our health slider 

	public float health = 12f; //this is the value of the players health 

	private float healthBurn = 6f; // this is the amount the player will be docked in health for each hit 

	private float healthAdd = 4f; 
	// Use this for initialization

	
		void Start () {
		myRigidbody = GetComponent<Rigidbody2D>(); 
		myAnimator = GetComponent<Animator> ();
		//associates the MyRigidbody variable with the player component so we can use it later
		facingRight = true; 
		isAlive = true;
		reset.SetActive (false);
		healthBar = GameObject.Find("healthslider").GetComponent<Slider>();
		healthBar.minValue = 0f; //set minimum value of health 
		healthBar.maxValue = health; //sets maximum value of the healthbar
		healthBar.value = healthBar.maxValue ;
		box = GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		float horizontal = Input.GetAxis ("Horizontal");
		Debug.Log (horizontal);
		if(isAlive){
		HandleMovement (horizontal);
		Flip (horizontal);
		isGrounded = IsGrounded (); 
		HandleInput ();
		Crouch();
		}

	}

	//function definitions//
	private void HandleMovement(float horizontal){

		if(isGrounded && jump){
			isGrounded = false;
			jump = false;
			myRigidbody.AddForce (new Vector2(0,jumpForce));
		}

		myRigidbody.velocity = new Vector2 (horizontal * movementSpeed, myRigidbody.velocity.y);
		myAnimator.SetFloat ("speed", Mathf.Abs (horizontal));
	}
	//function to conrol player direction 
	private void Flip (float horizontal) {
		if( horizontal > 0 && !facingRight || horizontal < 0 && facingRight){
			// do this if true 
			facingRight = !facingRight; //sets the value of facingRight to its opposite 
			Vector3 theScale = transform.localScale;       // new variable to store local scale 
			theScale.x *=-1;						// resetting the value of the x axis on the local scale 
			transform.localScale = theScale;	// reporting the new value at the cale component 
						
		}
	}
	//function to turn on and off the ability to jump
	private void HandleInput() {

		if(Input.GetKeyDown(KeyCode.Space)){
			jump = true; // if space bar is pressed set jump bool to true .
			myAnimator.SetBool ("jumping", true);
			Debug.Log("Jumping Activated");
		}

	}
	private void Crouch() {

		if (Input.GetKey (KeyCode.DownArrow)) {
			crouch = true; // if space bar is pressed set jump bool to true .
			myAnimator.SetBool ("crouching", true);
			Debug.Log ("crouching Activated");
			box.isTrigger = true;
		}
		else {
			if (Input.GetKey (KeyCode.DownArrow))
				crouch = false;
			myAnimator.SetBool ("crouching", false);
			Debug.Log ("Crocuh stop");
			box.isTrigger = false; 
		}

	
	}
		
	//this function will return true or false depending on whether our player is in contact with the ground
	private bool IsGrounded (){
		if(myRigidbody.velocity.y<=0){
			foreach (Transform point in groundPoints) {
				Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position,groundRadius,whatIsGround);
				for(int i = 0; i<colliders.Length;i++){
					if(colliders[i].gameObject != gameObject) {
						return true; 
					}
				}
			}
		}
		return false;
	}

	void ImDead(){
		myAnimator.SetBool ("dead", true);
		isAlive = false;
		reset.SetActive (true);
	}

		public void UpdateHealth(){
		if (health >= 1){
			health -= healthBurn;
			healthBar.value = health;
		}
			else{
				ImDead();
			}
	}
	void AddHealth(){
		if (health <= 12) {
			health += healthAdd;
			healthBar.value = health;
		}
		}
	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.gameObject.tag == "heal") {
			AddHealth ();
		}
	}
	void OnCollisionEnter2D(Collision2D target){
		if (target.gameObject.tag == "Ground") {
			myAnimator.SetBool ("jumping", false);
		}
		if (target.gameObject.tag == "deadly") {
			ImDead ();
		}
		if (target.gameObject.tag == "damage"){
			UpdateHealth();
		}
		if (target.gameObject.tag == "heal") {
			UpdateHealth ();
		}
		if (target.gameObject.gameObject.tag == "heal") {
			AddHealth ();
		}
	
	}

}
