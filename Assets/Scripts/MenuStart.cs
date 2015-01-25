using UnityEngine;
using System.Collections;

public class MenuStart : MonoBehaviour {

	public GameObject fader;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
			fader.SetActive(true);
	}
}
