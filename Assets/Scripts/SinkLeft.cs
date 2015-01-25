using UnityEngine;
using System.Collections;

public class SinkLeft : MonoBehaviour {

	public int plungeCount;
	public GameObject sink;
	
	void Plunge() {
		plungeCount--;
		audio.Play();
		if(plungeCount == 0) {
			sink.SendMessage("CleanLeft");	
			Destroy(gameObject);
		}
	}
}
