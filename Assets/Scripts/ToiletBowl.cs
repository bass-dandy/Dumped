using UnityEngine;
using System.Collections;

public class ToiletBowl : MonoBehaviour {

	public int plungeCount;
	
	void Plunge() {
		plungeCount--;
		Debug.Log(plungeCount);
	}
}
