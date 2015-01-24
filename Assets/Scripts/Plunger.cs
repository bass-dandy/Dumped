using UnityEngine;
using System.Collections;

public class Plunger : MonoBehaviour {

	public GameObject playerPlunger;

	void ShowPrompt() {
	
	}
	
	void Activate() {
		playerPlunger.SetActive(true);
		Destroy(gameObject);
	}
}
