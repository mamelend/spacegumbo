using UnityEngine;
using System.Collections;

public class playerAttack : MonoBehaviour {

	private bool attacking = false;

	private float attackTimer = 0;
	private float attackCoolDown = 0.3f;

	public Collider2D attackTrigger;

	private Animator anim;
	public Player1 player1;

	void Awake()
	{
		anim = gameObject.GetComponent<Animator> ();
		attackTrigger.enabled = false;

	}

	void Update()
	{
		if (Input.GetKeyDown ("/") && !attacking && player1.isHolding == false) {
			attacking = true;
			attackTimer = attackCoolDown;

			attackTrigger.enabled = true;
		}

		if (attacking) {
			if (attackTimer > 0) {
				attackTimer -= Time.deltaTime;
			} else {
				attacking = false;
				attackTrigger.enabled = false;
			}
		}
	
		anim.SetBool("Attacking", attacking);

	}

}
