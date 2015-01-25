using UnityEngine;
using System.Collections;

public class ToiletBowl : MonoBehaviour {

	public int plungeCount;
	public GameObject toilet;
	
	void Plunge() {
		plungeCount--;
		if(plungeCount == 0) {
			toilet.SendMessage("Clean");
			plungeCount = 10;	
		}
	}
}
