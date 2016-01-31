using UnityEngine;
using System.Collections;

public class attackTrigger : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.isTrigger != true && col.gameObject.name == "Player2")
		{
			col.SendMessageUpwards("Player 1 attacks Player 2");
			Debug.Log("Collider hit something!");
		}
	}

}