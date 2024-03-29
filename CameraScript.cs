﻿using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	private Transform player;

	public float minX, maxX;

	public float minY, maxY;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").transform;
	}

	// Update is called once per frame
	void Update () {
		if (GameObject.Find("Player").GetComponent<PlayerScript>().isAlive) {
			Vector3 temp = transform.position;
			temp.x = player.position.x;
			transform.position = temp;
		}
		if (GameObject.Find ("Player").GetComponent<PlayerScript> ().isAlive) {
			Vector3 temp = transform.position;
			temp.y = player.position.y;
			transform.position = temp; 
		}
	
	}
}
//CameraFollow