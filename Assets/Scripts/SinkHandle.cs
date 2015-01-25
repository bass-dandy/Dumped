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
	
	// Hands
	public GameObject leftHand;
	public GameObject rightHand;
	public GameObject rSleeveA;
	public GameObject rSleeveB;
	public GameObject rSleeveC;
	public GameObject lSleeveA;
	public GameObject lSleeveB;
	public GameObject lSleeveC;
	public Material skin;
	public Material sleeve;
	
	public GameObject leftWater;
	public GameObject rightWater;
	
	void Start() {
		gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalInput>();
	}
	
	void ShowPrompt() {
		hover = true;
	}
	
	void Update() {
		if(gameManager.time < 60)
			Spew ();
	}
	
	void Activate() {
		if(!animation.isPlaying) {
			animation.Play();
			handleTurn.Play();
		
			if(!particleLeft.particleSystem.isPlaying && !particleRight.particleSystem.isPlaying && !gameManager.leftSinkClean && !gameManager.rightSinkClean && gameManager.time < 121)
				Invoke ("Spew", 2);
			if(gameManager.leftSinkClean && gameManager.rightSinkClean) {
				leftHand.renderer.material = skin;
				rightHand.renderer.material = skin;
				rSleeveA.renderer.material = sleeve;
				rSleeveB.renderer.material = sleeve;
				rSleeveC.renderer.material = sleeve;
				lSleeveA.renderer.material = sleeve;
				lSleeveB.renderer.material = sleeve;
				lSleeveC.renderer.material = sleeve;
				
				leftWater.particleSystem.Play();
				rightWater.particleSystem.Play();
				gameManager.handsClean = true;
			}
		}
	}
	
	void Spew() {
		if(!particleLeft.particleSystem.isPlaying && !particleRight.particleSystem.isPlaying && !gameManager.leftSinkClean && !gameManager.rightSinkClean && gameManager.time < 121) {
			particleLeft.particleSystem.Play();
			particleRight.particleSystem.Play();
			gush.Play();
			plungeTriggerLeft.SetActive(true);
			plungeTriggerRight.SetActive(true);
			gameManager.sinkFlooding = true;
			flood.SendMessage("Raise");
		}
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
