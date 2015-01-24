using UnityEngine;
using System.Collections;

public class GlobalInput : MonoBehaviour {

	void Start () {
		Screen.lockCursor = true;
	}
	
	void Update () {
		if(Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.Q)) {
			Debug.Break();
		}
		Screen.lockCursor = true;
	}
}
