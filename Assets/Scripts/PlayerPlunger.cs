using UnityEngine;
using System.Collections;

public class PlayerPlunger : MonoBehaviour {

	public GameObject worldPlunger;
	public float throwForce;
	public float range;
	
	public AudioSource swing;

	void Update () {
		if(Input.GetKeyDown(KeyCode.Mouse0)) {
			if(!animation.isPlaying) {
				animation.Play();
				swing.Play();
			
				RaycastHit hit;
				if(Physics.Raycast(transform.parent.position, transform.parent.forward, out hit, range)) {
					if(hit.transform.tag == "Plungeable")
						hit.transform.gameObject.SendMessage("Plunge");
				}
			}
		}
			
		if(Input.GetKeyDown (KeyCode.Mouse1)) {
			GameObject p = Instantiate (worldPlunger, transform.position, transform.rotation) as GameObject;
			p.rigidbody.velocity = transform.parent.gameObject.transform.forward * throwForce;
			GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalInput>().playerHolding = false;
			gameObject.SetActive(false);
		}
	}
}
