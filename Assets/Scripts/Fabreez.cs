using UnityEngine;
using System.Collections;

public class Fabreez : MonoBehaviour {

	public GameObject head;
	public GameObject body;
	
	public Material headIdle;
	public Material bodyIdle;
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
			head.renderer.material = highlight;
			body.renderer.material = highlight;
			hover = false;
		}
		else {
			head.renderer.material = headIdle;
			body.renderer.material = bodyIdle;
		}
	}
	
	void Activate() {
		player.SendMessage("PickupFabreez");
		Destroy(gameObject);
	}
}
