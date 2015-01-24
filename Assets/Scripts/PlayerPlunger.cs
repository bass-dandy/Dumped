using UnityEngine;
using System.Collections;

public class PlayerPlunger : MonoBehaviour {

	void Update () {
		if(Input.GetKeyDown(KeyCode.Mouse0))
			animation.Play();
	}
}
