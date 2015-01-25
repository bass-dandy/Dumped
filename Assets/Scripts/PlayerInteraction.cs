using UnityEngine;
using System.Collections;

public class PlayerInteraction : MonoBehaviour {
	
	public float radius;
	
	void Update () {
		RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.forward, radius);
		
		for(int i = 0; i < hits.Length; i++) {
			if(hits[i].transform.tag == "Interactable") {
				hits[i].transform.SendMessage("ShowPrompt");
				if(Input.GetKeyDown(KeyCode.E)) {
					hits[i].transform.SendMessage("Activate");
				}
			}
		}
	}
}
