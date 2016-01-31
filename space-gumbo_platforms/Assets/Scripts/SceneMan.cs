using UnityEngine;
using System.Collections;

public class SceneMan : MonoBehaviour {

//	static SceneManager Instance;

	// Use this for initialization
	void Start () {
//		if (Instance != null) {
//			GameObject.Destroy (gameObject);
//		} else {
//			GameObject.DontDestroyOnLoad (gameObject);
//			Instance = this;
//		}
	}

	public void LoadScene(int level)
	{
		//loadingImage.SetActive(true);
		//Application.LoadLevel(level);
	}
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {
			Application.LoadLevel ("platformingmechanics");
		}
	}
}
