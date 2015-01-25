using UnityEngine;
using System.Collections;

public class ToiletHandle : MonoBehaviour {

	public Material idle;
	public Material highlight;

	public GameObject water;
	public Material cleanWater;
	public GameObject puddle;
	public GameObject flood;
	public GameObject particleMild;
	public GameObject particleHeavy;
	
	public AudioSource clog;
	public AudioSource flush;
	public AudioSource boom;
	public AudioSource gush;

	public GameObject plungeTrigger;

	private GameObject gameManager;
	private bool hover;
	private bool almostClean = false;
	private int usedCount;

	void Awake() {
		gameManager = GameObject.FindGameObjectWithTag("GameController");
	}

	void ShowPrompt() {
		hover = true;
	}

	void Activate() {
		if(usedCount == 0) {
			gameManager.SendMessage("Begin");
		}
		if(!transform.parent.parent.animation.isPlaying) {
			usedCount++;
			transform.parent.parent.animation.Play();
		
			switch(usedCount) {
				case 1:
					water.animation.Play();
					clog.Play();
					break;
				case 2:
					particleMild.particleSystem.Play();
					puddle.animation.Play();
					clog.Play();
					plungeTrigger.SetActive(true);
					break;
				case 3:
					particleMild.particleSystem.Stop();
					particleHeavy.particleSystem.Play();
					flood.SendMessage("Raise");
					boom.Play();
					gush.Play();
					gameManager.GetComponent<GlobalInput>().toiletFlooding = true;
					break;
				default:
					if(almostClean) {
						flush.Play ();
						water.SendMessage("Lower");
						water.renderer.material = cleanWater;
						gameManager.GetComponent<GlobalInput>().toiletClean = true;
					}
					break;
			}
		}
	}
	
	void Clean() {
		if(particleMild.particleSystem.isPlaying) {
			particleMild.particleSystem.Stop();
		}
		if(particleHeavy.particleSystem.isPlaying) {
			particleHeavy.particleSystem.Stop();
			gameManager.GetComponent<GlobalInput>().toiletFlooding = false;
			almostClean = true;
		}
	}
	
	void Update() {
		if(usedCount < 3 && gameManager.GetComponent<GlobalInput>().time < 91) {
			usedCount = 3;
			particleMild.particleSystem.Stop();
			particleHeavy.particleSystem.Play();
			flood.SendMessage("Raise");
			boom.Play();
			gush.Play();
			gameManager.GetComponent<GlobalInput>().toiletFlooding = true;
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
