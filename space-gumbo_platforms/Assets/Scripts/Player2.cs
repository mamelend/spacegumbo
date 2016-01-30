﻿using UnityEngine;
using System.Collections;


[RequireComponent (typeof (Controller2D))]
public class Player2 : MonoBehaviour {



	float moveSpeed = 6; 
	public float jumpHeight = 4;
	public float timeToJumpApex = .4f;
	public float accelTimeAir = .2f; 
	public float accelTimeGround = .1f;

	float gravity;
	float jumpVelocity;
	Vector3 velocity;
	float velocityXSmoothing;


	Controller2D controller;

	void Start () {
		controller = GetComponent<Controller2D> ();

		gravity = -(2 * jumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		jumpVelocity = Mathf.Abs (gravity * timeToJumpApex);
	}

	void Update() {

		float directionX = 0;

		if (controller.collisions.above || controller.collisions.below) {
			velocity.y = 0;
		}


		/* SET CONTROLS HERE */
		if (Input.GetKey (KeyCode.A)) {
			directionX = -1;
		}
		if (Input.GetKey (KeyCode.D)) {
			directionX = 1;
		}
			
		if (Input.GetKeyDown (KeyCode.W) && controller.collisions.below) {
			velocity.y = jumpVelocity;
		}

		float targetVelocityX = directionX * moveSpeed;  //target speed
		velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below)?accelTimeGround:accelTimeAir); //ramps up to target speed
		velocity.y += gravity * Time.deltaTime;
		controller.Move (velocity * Time.deltaTime);
	}
}
