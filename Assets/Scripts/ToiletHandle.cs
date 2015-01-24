using UnityEngine;
using System.Collections;

public class ToiletHandle : MonoBehaviour {

	public Material idle;
	public Material highlight;

	public GameObject water;
	public GameObject particleMild;
	public GameObject particleHeavy;

	private bool hover;
	private int usedCount;

	void ShowPrompt() {
		hover = true;
	}

	void Activate() {
		usedCount++;
		transform.parent.parent.animation.Play();
		
		switch(usedCount) {
			case 1:
				water.animation.Play();
				break;
			case 2:
				particleMild.particleSystem.Play();
				break;
			case 3:
				particleMild.particleSystem.Stop();
				particleHeavy.particleSystem.Play();
				break;
		}
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
