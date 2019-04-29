using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class TimeManager : MonoBehaviour {

	public static float score;
	private GameObject gameobject;
	public GameObject overtext;
	public UImanager uimanager;
	Text text;
	void Awake () {
		text = GetComponent <Text> ();
		//need to pause when time is finished
		//gameObject = GameObject.FindGameObjectWithTag("UIManager");
		//uimanager = gameobject.GetComponent < UImanager > () :
		score = 20f;
	}

	// Update is called once per frame
	void Update () {
		score -=  Time.deltaTime;
		text.text = score.ToString("F2");
		if (score <= 0) {
			//
			uimanager.pauseControl();
			score = 20;
			overtext.SetActive (true);
		}
	}
}
