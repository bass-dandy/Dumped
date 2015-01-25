using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GlobalInput : MonoBehaviour {

	public int time;
	public Text timer;
	
	public bool toiletFlooding = false;
	public bool sinkFlooding = false;
	public bool flooded = false;
	
	public bool toiletClean = false;
	public bool leftSinkClean = false;
	public bool rightSinkClean = false;
	public bool handsClean = true;
	
	public GameObject fadeLose;
	public GameObject fadeWin;
	
	public int numPuddles;
	
	public GameObject player;
	public bool playerCanMove = true;
	public bool playerCanLook = true;
	public bool playerHolding = false;
	
	public GameObject leftHand;
	public GameObject rightHand;
	public GameObject rSleeveA;
	public GameObject rSleeveB;
	public GameObject rSleeveC;
	public GameObject lSleeveA;
	public GameObject lSleeveB;
	public GameObject lSleeveC;
	public Material pooHand;
	
	private int stench;

	void Start () {
		Screen.lockCursor = true;
	}
	
	void Update () {
		Screen.lockCursor = true;
		
		if(toiletClean && leftSinkClean && rightSinkClean && numPuddles == 0 && !flooded && stench == 0 && handsClean) {
			fadeWin.SetActive(true);
			CancelInvoke("Tick");
		}
		
		if(toiletFlooding || sinkFlooding) {
			leftHand.renderer.material = pooHand;
			rightHand.renderer.material = pooHand;
			rSleeveA.renderer.material = pooHand;
			rSleeveB.renderer.material = pooHand;
			rSleeveC.renderer.material = pooHand;
			lSleeveA.renderer.material = pooHand;
			lSleeveB.renderer.material = pooHand;
			lSleeveC.renderer.material = pooHand;
			handsClean = false;
		}
	}
	
	void Begin() {
		InvokeRepeating("Tick", 0.0f, 1.0f);
		audio.Play();
	}
	
	void Tick() {
		stench += 2;
		
		if(time <= 10)
			timer.color = Color.red;
		if(time <= 0) {
			timer.text = "0:00";
			playerCanMove = false;
			playerCanLook = false;
			player.SendMessage("Lose");
			Invoke("Fadeout", 2.0f);
			CancelInvoke("Tick");	
		}
		
		int min = time / 60;
		int sec = time % 60;
		timer.text = string.Format("{0:0}:{1:00}", min, sec);
		
		if(stench >= 90) {
			stench = 90;
			time -= 5;
		}
		else if(stench > 70)
			time -= 4;
		else if(stench > 50)
			time -= 3;
		else if(stench > 30)
			time -= 2;
		else
			time--;
	}
	
	void Fadeout() {
		fadeLose.SetActive(true);
	}
	
	void Freshen() {
		stench -= 10;
		if(stench < 0)
			stench = 0;
	}
}
