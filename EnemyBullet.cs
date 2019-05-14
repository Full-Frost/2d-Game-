using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour {
	private Rigidbody2D myRigidbody;
	//private Animator myAnimator;
	[SerializeField] 
	//private float bulletSpeed;
	public float speed = 30f;

	//This searches for a collision between our bullet and our player. if the palyer collides with the bullet both the bullet and the player disappear

	void Start () {

		myRigidbody = GetComponent<Rigidbody2D>(); 
	
		//myAnimator = GetComponent<Animator> ();
	}
	void FixedUpdate () {
		Move ();
		//myRigidbody.transform.localScale.x  );
	}
		


	void Move(){
		
		myRigidbody.AddForce(new Vector2 (-1, 0)*speed ); 
		//myRigidbody2D.AddForce(transform.rotation * Vector3.right * Speed);
	}
	
		void OnCollisionEnter2D(Collision2D target) {
	
		if (target.gameObject.tag == "Player") {

			Destroy (gameObject);
		}
		//this checks to see if the bullet touches the ground, then unloads the bullet if it touches ground.
		if (target.gameObject.tag == "Ground") { 
			
			Destroy (gameObject);
		}
		if (target.gameObject.tag == "deadly") {

			Destroy (gameObject);
		}
		if (target.gameObject.tag == "damage") {

			Destroy (gameObject);
		}
	}
}