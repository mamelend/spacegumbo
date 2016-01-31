using UnityEngine;
using System.Collections;


[RequireComponent (typeof (Controller2D))]
public class Player1 : MonoBehaviour {



	float moveSpeed = 6; 
	public float jumpHeight = 4;
	public float timeToJumpApex = .4f;
	public float accelTimeAir = .2f; 
	public float accelTimeGround = .1f;

	float gravity;
	float jumpVelocity;
	Vector3 velocity;
	float velocityXSmoothing;

	public bool isHolding = false;
	private int maPoints = 0;
	private bool isAirborne = false;

	public AudioClip jumpSound;
	public AudioClip landSound;
	private AudioSource source;

	Animator anim;

	Controller2D controller;


	void Start () {
		controller = GetComponent<Controller2D> ();

		gravity = -(2 * jumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		jumpVelocity = Mathf.Abs (gravity * timeToJumpApex);

		source = GetComponent<AudioSource> ();

		anim = GetComponent<Animator> ();
	}

	void Update() {

		float directionX = 0;

		if (controller.collisions.above || controller.collisions.below) {
			velocity.y = 0;
		}

		/* SET CONTROLS HERE */
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.localRotation = Quaternion.Euler(0, 180, 0);
			directionX = 1;
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			directionX = 1;
			transform.localRotation = Quaternion.Euler(0, 0, 0);
		}

		if (Input.GetKeyDown (KeyCode.UpArrow) && controller.collisions.below) {
			velocity.y = jumpVelocity;
			source.PlayOneShot (jumpSound);
		}

		float targetVelocityX = directionX * moveSpeed;  //target speed
		velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below)?accelTimeGround:accelTimeAir); //ramps up to target speed
		velocity.y += gravity * Time.deltaTime;

		anim.SetFloat ("Speed", Mathf.Abs(directionX)); //animate

		if (!controller.collisions.below) {
			anim.SetBool ("Airborne", true);
			isAirborne = true;
		} else {
			if (isAirborne == true) {
				source.PlayOneShot (landSound);
			}
			anim.SetBool ("Airborne", false);
			isAirborne = false;
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

