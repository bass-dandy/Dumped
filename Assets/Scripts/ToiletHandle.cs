using UnityEngine;
using System.Collections;

public class ToiletHandle : MonoBehaviour {

	public Material idle;
	public Material highlight;

	void ShowPrompt() {
		renderer.material = highlight;
	}

	void Activate() {
		transform.parent.parent.animation.Play();
	}
	
	void Update() {
		renderer.material = idle;
	}
}
