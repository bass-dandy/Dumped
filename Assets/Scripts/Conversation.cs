using UnityEngine;
using System.Collections;

public class Conversation : MonoBehaviour {
	
	public GameObject next;
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)) {
			next.SetActive(true);
			Destroy(gameObject);
		}
	}
}
