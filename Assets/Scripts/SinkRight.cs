using UnityEngine;
using System.Collections;

public class SinkRight : MonoBehaviour {

	public int plungeCount;
	public GameObject sink;
	
	void Plunge() {
		plungeCount--;
		audio.Play();
		if(plungeCount == 0) {
			sink.SendMessage("CleanRight");	
			Destroy(gameObject);
		}
	}
}
