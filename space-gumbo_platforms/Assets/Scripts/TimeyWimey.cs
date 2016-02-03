using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeyWimey : MonoBehaviour
{
	float timeLeft = 76.0f;

	public Text TimeyTexty;

//	public Text countText;
//	public Text winText;

//	private Rigidbody rb;
//	private int count;



	void Start() {
//		TimeyTexty.text = "000";
		TimeyTexty = GetComponent<Text> ();
//		rb = GetComponent<Rigidbody>();
//		count = 0;
//		SetCountText ();
//		winText.text = "";
	}

	void Update()
	{
		timeLeft -= Time.deltaTime;
//		TimeyTexty.text = "Time Left: " + Mathf.Round(timeLeft);
//		countText.text = "Count: " + count.ToString ();
		TimeyTexty.text = Mathf.Round(timeLeft) + " seconds left!!!";
		if(timeLeft < 0)
		{
			Application.LoadLevel("Close");
		}
		Debug.Log (timeLeft);
	}
//	void SetCountText ()
//	{
//		countText.text = "Count: " + count.ToString ();
//		if (count >= 12)
//		{
//			winText.text = "You Win!";
//		}
//	}
}


//looking at: http://answers.unity3d.com/questions/980339/count-down-timer-c-1.html


