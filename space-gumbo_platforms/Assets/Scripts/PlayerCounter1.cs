using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerCounter1 : MonoBehaviour
{
	public Text countText;
	private int count;



	void Start() {
		countText = GetComponent<Text> ();
		count = 0;
	}

	void Update()
	{
		count = Player1.maPoints; 
		countText.text = count.ToString ();
	}
}


//looking at: http://answers.unity3d.com/questions/980339/count-down-timer-c-1.html


