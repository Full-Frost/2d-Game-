using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basics : MonoBehaviour {

	//Declare variables//  
	float speed = 2.5f;
	int fast = 8;
	string name = "player";
	bool isDead = false; 

	// Use this for initialization
	void Start () {
		/* Debug.Log ("1 + 2 =" + (1+2)); // Will report 2+1 equals 3 to the console 
		 Debug.Log (50 * 10);  //Will multiply 10 *50 and report to console 

		//Debug.Log (speed * fast); 

		int random = Random.Range (10, 70);

		Debug.Log (random); 

		int slow = 2;

		float velocity = 3.62f;

		Debug.Log (slow / velocity);

		Debug.Log (slow * velocity);

		Debug.Log (random * slow); */

		Debug.Log(AddUp (255, 300));
		Debug.Log(Multiply (300, 333));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//function definitions//
	int AddUp(int a, int b)  {


		return a + b;
	
	}

	int Multiply(int c, int d) {

		return c * d;

	}

}
