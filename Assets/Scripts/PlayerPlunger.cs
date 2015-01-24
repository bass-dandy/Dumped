using UnityEngine;
using System.Collections;

public class PlayerPlunger : MonoBehaviour {

	public GameObject worldPlunger;
	public float throwForce;

	void Update () {
		if(Input.GetKeyDown(KeyCode.Mouse0))
			animation.Play();
			
		if(Input.GetKeyDown (KeyCode.Mouse1)) {
			GameObject p = Instantiate (worldPlunger, transform.position, transform.rotation) as GameObject;
			p.rigidbody.velocity = transform.parent.gameObject.transform.forward * throwForce;
			gameObject.SetActive(false);
		}
	}
}
