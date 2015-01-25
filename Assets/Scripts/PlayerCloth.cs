using UnityEngine;
using System.Collections;

public class PlayerCloth : MonoBehaviour {

	public GameObject worldCloth;
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
					if(hit.transform.tag == "Wipeable")
						hit.transform.gameObject.SendMessage("Wipe");
				}
			}
		}
		
		if(Input.GetKeyDown (KeyCode.Mouse1)) {
			GameObject p = Instantiate (worldCloth, transform.position, transform.rotation) as GameObject;
			p.rigidbody.velocity = transform.parent.gameObject.transform.forward * throwForce;
			GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalInput>().playerHolding = false;
			gameObject.SetActive(false);
		}
	}
}
