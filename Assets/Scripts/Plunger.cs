using UnityEngine;
using System.Collections;

public class Plunger : MonoBehaviour {

	public GameObject playerPlunger;

	public GameObject handle;
	public GameObject cup;
	public GameObject rim;

	public Material handleIdle;
	public Material rubberIdle;
	public Material highlight;

	private bool hover;

	void ShowPrompt() {
		hover = true;
	}
	
	void LateUpdate() {
		if(hover) {
			cup.renderer.material = highlight;
			rim.renderer.material = highlight;
			handle.renderer.material = highlight;
			hover = false;
		}
		else {
			cup.renderer.material = rubberIdle;
			rim.renderer.material = rubberIdle;
			handle.renderer.material = handleIdle;
		}
	}
	
	void Activate() {
		playerPlunger.SetActive(true);
		Destroy(gameObject);
	}
}
