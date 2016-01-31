using UnityEngine;
using System.Collections;

public class attackTrigger : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Player2"))
		{
			other.SendMessageUpwards("Player 1 attacks Player 2");
			Debug.Log( "collide (name) : " + other.gameObject.name );
			Debug.Log( "collide (tag) : " + other.gameObject.tag );
		}
	}
}