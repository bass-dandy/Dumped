using UnityEngine;
using System.Collections;

public class Bucket : MonoBehaviour {

	public Material idle;
	public Material highlight;
	
	public GameObject rim;
	public GameObject bottom;
	
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
			rim.renderer.material = highlight;
			bottom.renderer.material = highlight;
			hover = false;
		}
		else {
			rim.renderer.material = idle;
			bottom.renderer.material = idle;
		}
	}
	
	void Activate() {
		if(!GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalInput>().playerHolding) {
			player.SendMessage("PickupBucket");
			Destroy(gameObject);
		}
	}
}
