using UnityEngine;
using System.Collections;

public class PlayerFabreez : MonoBehaviour {

	public GameObject worldFabreez;
	public GameObject gameManager;
	public float throwForce;
	
	public AudioSource swing;
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.Mouse0)) {
			if(!animation.isPlaying) {
				animation.Play();
				swing.Play();
			
				GetComponentInChildren<ParticleSystem>().Play();
				gameManager.SendMessage("Freshen");
			}
		}
		
		if(Input.GetKeyDown (KeyCode.Mouse1)) {
			GameObject p = Instantiate (worldFabreez, transform.position, transform.rotation) as GameObject;
			p.rigidbody.velocity = transform.parent.gameObject.transform.forward * throwForce;
			gameManager.GetComponent<GlobalInput>().playerHolding = false;
			gameObject.SetActive(false);
		}
	}
}
