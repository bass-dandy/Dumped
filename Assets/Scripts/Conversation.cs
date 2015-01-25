using UnityEngine;
using System.Collections;

public class Conversation : MonoBehaviour {
	
	public GameObject next;
	public GameObject food;
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)) {
			if(next)
				next.SetActive(true);
			if(food)
				food.tag = "Interactable";
			Destroy(gameObject);
		}
	}
}
