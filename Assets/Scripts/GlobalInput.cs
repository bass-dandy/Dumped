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
	
	public GameObject fade;
	
	public int numPuddles;
	
	public GameObject player;
	public bool playerCanMove = true;
	public bool playerCanLook = true;
	
	private int stench;

	void Start () {
		Screen.lockCursor = true;
	}
	
	void Update () {
		Screen.lockCursor = true;
		
		if(toiletClean && leftSinkClean && rightSinkClean && numPuddles == 0 && !flooded && stench == 0) {
			Debug.Log ("You win!");
			CancelInvoke("Tick");
		}
	}
	
	void Begin() {
		InvokeRepeating("Tick", 0.0f, 1.0f);
		audio.Play();
	}
	
	void Tick() {
		stench += 2;
		
		int min = time / 60;
		int sec = time % 60;
		timer.text = string.Format("{0:0}:{1:00}", min, sec);
		
		if(stench > 60)
			time -= 2;
		else
			time--;
		if(time < 0) {
			time = 0;
			playerCanMove = false;
			playerCanLook = false;
			player.SendMessage("Lose");
			Invoke("Fadeout", 2.0f);
			CancelInvoke("Tick");	
		}
	}
	
	void Fadeout() {
		fade.SetActive(true);
	}
	
	void Freshen() {
		stench -= 5;
		if(stench < 0)
			stench = 0;
	}
}
