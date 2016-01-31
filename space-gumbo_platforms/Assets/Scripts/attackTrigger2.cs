using UnityEngine;
using System.Collections;

public class attackTrigger2 : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Player1"))
		{
			other.SendMessageUpwards("Player 2 attacks Player 1");
			Debug.Log( "collide (name) : " + other.gameObject.name );
			Debug.Log( "collide (tag) : " + other.gameObject.tag );
		}
	}
}