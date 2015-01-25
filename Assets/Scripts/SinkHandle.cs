using UnityEngine;
using System.Collections;

public class SinkHandle : MonoBehaviour {

	public Material idle;
	public Material highlight;
	
	public GameObject particleLeft;
	public GameObject particleRight;
	public GameObject plungeTriggerLeft;
	public GameObject plungeTriggerRight;
	
	public GameObject flood;
	
	public AudioSource handleTurn;
	public AudioSource gush;
	
	private bool hover;
	
	private GlobalInput gameManager;
	
	void Start() {
		gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalInput>();
	}
	
	void ShowPrompt() {
		hover = true;
	}
	
	void Activate() {
		if(!animation.isPlaying) {
			animation.Play();
			handleTurn.Play();
		
			if(!particleLeft.particleSystem.isPlaying && !particleRight.particleSystem.isPlaying && !gameManager.leftSinkClean && !gameManager.rightSinkClean)
				Invoke ("Spew", 2);
		}
	}
	
	void Spew() {
		particleLeft.particleSystem.Play();
		particleRight.particleSystem.Play();
		gush.Play();
		plungeTriggerLeft.SetActive(true);
		plungeTriggerRight.SetActive(true);
		gameManager.sinkFlooding = true;
		flood.SendMessage("Raise");
	}
	
	void CleanLeft() {
		gameManager.leftSinkClean = true;
		particleLeft.particleSystem.Stop();
		if(gameManager.rightSinkClean) {
			gush.Stop();
			gameManager.sinkFlooding = false;	
		}
	}
	
	void CleanRight() {
		gameManager.rightSinkClean = true;
		particleRight.particleSystem.Stop();
		if(gameManager.leftSinkClean) {
			gush.Stop();
			gameManager.sinkFlooding = false;	
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
