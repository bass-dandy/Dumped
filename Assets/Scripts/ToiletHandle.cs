using UnityEngine;
using System.Collections;

public class ToiletHandle : MonoBehaviour {

	public Material idle;
	public Material highlight;

	private bool hover;

	void ShowPrompt() {
		hover = true;
	}

	void Activate() {
		transform.parent.parent.animation.Play();
	}
	
	void LateUpdate() {
		if(hover) {
			renderer.material = highlight;
			hover = false;
		}
		else
			renderer.material = idle;
	}
}
