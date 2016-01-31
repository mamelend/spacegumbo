using UnityEngine;
using System.Collections;

public class attackTrigger2 : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.isTrigger != true && col.gameObject.name == "Player1")
		{
			col.SendMessageUpwards("Player 2 attacks Player 1");
			Debug.Log("Collider hit something!");
		}
	}
}