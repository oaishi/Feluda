using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {

	public GameObject popup;
	public float OrthoZoomSpeed = 0.5f; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.touchCount == 2) {
			popup.SetActive (false);
			Touch touchZero = Input.GetTouch (0);
			Touch touchOne = Input.GetTouch (1);
			Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
			Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;
			float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
			float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;
			float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
			if((GetComponent<Camera> ().orthographicSize + deltaMagnitudeDiff * OrthoZoomSpeed) >0.29f && (GetComponent<Camera> ().orthographicSize + deltaMagnitudeDiff * OrthoZoomSpeed )<9f )
			GetComponent<Camera> ().orthographicSize += deltaMagnitudeDiff * OrthoZoomSpeed;
		}
		else if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
		{
			popup.SetActive (false);
			Vector2 touchDeltaPosition = Input.GetTouch (0).deltaPosition;
			transform.Translate (-touchDeltaPosition.x*Time.deltaTime , -touchDeltaPosition.y*Time.deltaTime ,0f);
		}
	}

}
