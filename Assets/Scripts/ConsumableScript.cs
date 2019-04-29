using UnityEngine;
using System.Collections;

public class ConsumableScript : MonoBehaviour {

	Vector3 touchPosWorld;
	int i;
	public GameObject popup;
	public GameObject popup1;
	UImanager uimanager;
	//Change me to change the touch phase used.
	TouchPhase touchPhase = TouchPhase.Ended;
	public GameObject[] itemObjects = new GameObject[8];
	int collectibles;
	void Start () {
		uimanager = GetComponent<UImanager> ();
		collectibles = 0;
		i = 0;
		}

	void Update() {
		//We check if we have more than one touch happening.
		//We also check if the first touches phase is Ended (that the finger was lifted)
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == touchPhase) {
			//We transform the touch position into word space from screen space and store it.
			touchPosWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

			Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);

			//We now raycast with this information. If we have hit something we can process it.
			RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);

			if (hitInformation.collider != null) {
				//We should have hit something with a 2D Physics collider!
				GameObject touchedObject = hitInformation.transform.gameObject;
				//touchedObject should be the object someone touched.
				Debug.Log ("Touched " + touchedObject.transform.name);
				//ScoreManager.score += 10;
				string itemname = hitInformation.transform.gameObject.name;
				for (int i = 0; i < itemObjects.Length; i++) {
					if(itemObjects[i].GetComponent<Itemslot>().itemname.Equals(itemname))
						{
						itemObjects [i].GetComponent<Itemslot>().text.color  =  new Color(255f , 0f , 0f);
						ScoreManager.score += 10;
						collectibles++;
						if (collectibles == 6) {
							i++;
							ScoreManager.score += 100;
							popup1.SetActive (true);
							uimanager.gameend();
							break;
						}
						if(itemObjects[i].GetComponent<Itemslot>().itemname.Equals("Blue Beril Stone"))
						popup.SetActive (true);
						break;
						}
				}
				Destroy (touchedObject);
			}
		}
	}
}
