using UnityEngine;
using System.Collections;

public class PlayerFabreez : MonoBehaviour {

	public GameObject worldFabreez;
	public float throwForce;
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.Mouse0)) {
			animation.Play();
			GetComponentInChildren<ParticleSystem>().Play();
		}
		
		if(Input.GetKeyDown (KeyCode.Mouse1)) {
			GameObject p = Instantiate (worldFabreez, transform.position, transform.rotation) as GameObject;
			p.rigidbody.velocity = transform.parent.gameObject.transform.forward * throwForce;
			gameObject.SetActive(false);
		}
	}
}
