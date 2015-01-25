using UnityEngine;
using System.Collections;

public class ToiletBowl : MonoBehaviour {

	public int plungeCount;
	public GameObject toilet;
	
	void Plunge() {
		plungeCount--;
		audio.Play();
		if(plungeCount == 0) {
			toilet.SendMessage("Clean");
			plungeCount = 10;	
		}
	}
}
