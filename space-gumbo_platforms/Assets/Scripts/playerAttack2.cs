using UnityEngine;
using System.Collections;

public class playerAttack2 : MonoBehaviour {

	private bool attacking = false;

	private float attackTimer = 0;
	private float attackCoolDown = 0.3f;

	public Collider2D attackTrigger2;

	private Animator anim;

	void Awake()
	{
		anim = gameObject.GetComponent<Animator> ();
		attackTrigger2.enabled = false;

	}

	void Update()
	{
		if (Input.GetKeyDown ("f") && !attacking) {
			attacking = true;
			attackTimer = attackCoolDown;

			attackTrigger2.enabled = true;
		}

		if (attacking) {
			if (attackTimer > 0) {
				attackTimer -= Time.deltaTime;
			} else {
				attacking = false;
				attackTrigger2.enabled = false;
			}
		}

		anim.SetBool("Attacking", attacking);

	}
}
