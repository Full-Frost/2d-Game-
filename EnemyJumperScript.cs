using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumperScript : MonoBehaviour {

	public float forceY = 300f;
	private Rigidbody2D myRigidbody;
	private Animator myAnimator;

	void Awake(){
		myRigidbody = GetComponent<Rigidbody2D> ();
		myAnimator = GetComponent<Animator> ();
	}
		
	// Use this for initialization
	void Start () {
		StartCoroutine (Attack ());
	}

	IEnumerator Attack(){

		yield return new WaitForSeconds (Random.Range (2, 4)); //controls the pause between jumps
	
		forceY = Random.Range (250, 550); //changes magnitude of jump

		myRigidbody.AddForce (new Vector2(0, forceY)); //what sends the jumper into the air 

		myAnimator.SetBool ("attack", true);

		yield return new WaitForSeconds (1.5f);

		myAnimator.SetBool ("attack", false); 

		StartCoroutine (Attack ());
	}

	void OnTriggerEnter2D(Collider2D target){

		if (target.tag == "bullet") {
			Destroy (gameObject);
			Destroy (target.gameObject);
		}
	}
}
