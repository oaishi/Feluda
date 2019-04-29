using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImanager : MonoBehaviour {
	public GameObject[] itemObjects = new GameObject[2];
	Vector3 Cameraposition;
	public GameObject[] obj = new GameObject[4];
	public GameObject[] menus = new GameObject[2];
	public GameObject pausebutton;
	public GameObject CAM;
	public GameObject ovetext;
	public GameObject popupobject;
	void Start () {
		Time.timeScale = 1;
		}

	void Update () {
		if(Input.GetKeyDown(KeyCode.P))
		{
			if(Time.timeScale == 1)
			{
				Time.timeScale = 0;
				showPaused();
			} else if (Time.timeScale == 0){
				Time.timeScale = 1;
				hidePaused();
			}
		}
	}
		
	public void Reload(){
		Application.LoadLevel(Application.loadedLevel);
	}

	public void pauseControl(){
		if(Time.timeScale == 1)
		{
			Time.timeScale = 0;
			showPaused();
			CAM.transform.position = Cameraposition;
		} else if (Time.timeScale == 0){
			ovetext.SetActive (false);
			Time.timeScale = 1;
			hidePaused();
		}
	}

	public void showPaused(){
		pausebutton.SetActive (false);
	for(int i = 0; i < obj.Length; i++)
		{
			obj [i].SetActive (true);
		}
		for (int i = 0; i < itemObjects.Length; i++) {
			itemObjects [i].SetActive (false);
		}
	}

	public void hidePaused(){
		pausebutton.SetActive (true);
		for(int i = 0; i < obj.Length; i++)
		{
			obj [i].SetActive (false);
		}
		for (int i = 0; i < itemObjects.Length; i++) {
			itemObjects [i].SetActive (true);
		}
	}

	public void LoadLevel(){
		ovetext.SetActive (false);
		Cameraposition = CAM.transform.position;
		CAM.transform.position = new Vector3(-40f,0f,-15f);
		pausebutton.SetActive (false);
		for (int i = 0; i < menus.Length; i++) {
			menus[i].SetActive (true);
		}
		for (int i = 0; i < itemObjects.Length; i++) {
			itemObjects [i].SetActive (false);
		}
		for(int i = 0; i < obj.Length; i++)
		{
			obj [i].SetActive (false);
		}
	}


	public void gameend()
	{
		for (int i = 0; i < menus.Length; i++) {
			menus[i].SetActive (false);
		}
		for (int i = 0; i < itemObjects.Length; i++) {
			itemObjects [i].SetActive (false);
		}
		for(int i = 0; i < obj.Length; i++)
		{
			obj [i].SetActive (false);
		}
	}

	public void LevelChange(float position)
	{
		ovetext.SetActive (false);
		Cameraposition = new Vector3 (position*40 , 0f , -10f);
		CAM.transform.position = Cameraposition;
		hidePaused ();
		for (int i = 0; i < menus.Length; i++) {
			menus[i].SetActive (false);
		}
		pausebutton.SetActive (true);
	}


}
