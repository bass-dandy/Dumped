using UnityEngine;
using System.Collections;

public class PlayerInteraction : MonoBehaviour {
	
	public float radius;
	
	void Update () {
		RaycastHit hit;
		if(Physics.Raycast(transform.position, transform.forward, out hit, radius)) {
			if(hit.transform.tag == "Interactable") {
				hit.transform.SendMessage("ShowPrompt");
				if(Input.GetKeyDown(KeyCode.E)) {
					hit.transform.SendMessage("Activate");
				}
			}
		}
	}
}
