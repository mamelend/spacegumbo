using UnityEngine;
using System.Collections;


[RequireComponent (typeof (Controller2D))]
public class Player : MonoBehaviour {



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

		if (controller.collisions.above || controller.collisions.below) {
			velocity.y = 0;
		}

		Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical")); //gets inputs

		if (Input.GetKeyDown (KeyCode.UpArrow) && controller.collisions.below) {
			velocity.y = jumpVelocity;
		}

		float targetVelocityX = input.x * moveSpeed;  //target speed
		velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below)?accelTimeGround:accelTimeAir); //ramps up to target speed
		velocity.y += gravity * Time.deltaTime;
		controller.Move (velocity * Time.deltaTime);
	}
}
