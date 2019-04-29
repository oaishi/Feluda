using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Itemslot : MonoBehaviour {

	// Use this for initialization
	public string itemname;
	public Text text;
	void Awake () {
		text = GetComponent <Text> ();
		itemname = text.text;
	}
	
	// Update is called once per frame
	void Update () {
		text.text = itemname;
	}


}
