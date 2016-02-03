using UnityEngine;
using System.Collections;

public class JudgeJury : MonoBehaviour {

	float timeCloseLeft = 8.0f;

//	public Text TimeyTexty;
	public GameObject P1Wins;
	public GameObject P2Wins;

	private int p1points;
	private int p2points;

	// Use this for initialization
	void Start () {
		p1points = Player1.maPoints;
		p2points = Player2.maPoints;
		if (p1points > p2points) {
			Debug.Log ("blue win");
//			GameObject.Find("P1Wins").active = true;
			P1Wins.SetActive (true);
		} else {
			Debug.Log ("green Win");
			P2Wins.SetActive (true);
		}
		
	}
	
	// Update is called once per frame
	void Update()
	{
		timeCloseLeft -= Time.deltaTime;
		//		TimeyTexty.text = "Time Left: " + Mathf.Round(timeLeft);
		//		countText.text = "Count: " + count.ToString ();
//		TimeyTexty.text = "Hurry only " + Mathf.Round(timeLeft) + " seconds left!!!";
		if(timeCloseLeft < 0)
		{
			Application.LoadLevel("Opening");
		}
//		Debug.Log (timeCloseLeft);
	}
}
