using UnityEngine;
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

	private bool isHolding = false;
	private int maPoints = 0;

	Animator anim;


	Controller2D controller;

	void Start () {
		controller = GetComponent<Controller2D> ();

		gravity = -(2 * jumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		jumpVelocity = Mathf.Abs (gravity * timeToJumpApex);

		anim = GetComponent<Animator> ();
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

		anim.SetFloat ("SpeedP2", Mathf.Abs(directionX)); //animate

		if (!controller.collisions.below) {
			anim.SetBool ("AirborneP2", true);
		} else {
			anim.SetBool ("AirborneP2", false);
		}


		controller.Move (velocity * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Animal") && isHolding==false) {
			other.gameObject.SetActive (false);
			isHolding = true;
			//          Debug.Log ("P1 holding");
		} else if (other.gameObject.CompareTag ("Goal1") && isHolding==true) {
			maPoints++;
			isHolding = false;
			if (maPoints == 1) {
				Debug.Log ("choked the chicken");
			} else {
				Debug.Log ("Choked " + maPoints + " chickens!!");
			}
		}

		if (isHolding) {
			Debug.Log ("holding");
		} else {
			Debug.Log ("got notihng");
		}
	}
}
