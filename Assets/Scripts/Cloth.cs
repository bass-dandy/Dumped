using UnityEngine;
using System.Collections;

public class Cloth : MonoBehaviour {
	
	public Material idle;
	public Material highlight;
	
	private GameObject player;
	private bool hover;
	
	void ShowPrompt() {
		hover = true;
	}
	
	void Start() {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void LateUpdate() {
		if(hover) {
			renderer.material = highlight;
			hover = false;
		}
		else {
			renderer.material = idle;
		}
	}
	
	void Activate() {
		player.SendMessage("PickupCloth");
		Destroy(gameObject);
	}
}
