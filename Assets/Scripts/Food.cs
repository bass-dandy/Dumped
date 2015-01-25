using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {

	public Material idleGold;
	public Material idleRed;
	public Material idleBrown;
	public Material highlight;
	
	public GameObject gold;
	public GameObject red;
	public GameObject brown;
	
	public GameObject next;
	public GameObject tip;
	
	private bool hover;
	
	void ShowPrompt() {
		hover = true;
	}
	
	void LateUpdate() {
		if(hover) {
			gold.renderer.material = highlight;
			red.renderer.material = highlight;
			brown.renderer.material = highlight;
			tip.SetActive(true);
			hover = false;
		}
		else {
			gold.renderer.material = idleGold;
			red.renderer.material = idleRed;
			brown.renderer.material = idleBrown;
			tip.SetActive(false);
		}
	}
	
	void Activate() {
		next.SetActive(true);
		tip.SetActive(false);
		Destroy(gameObject);
	}
}
