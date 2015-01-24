using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	public float speed;
	public Transform head;
	
	public GameObject playerPlunger;
	
	void Update () {
		// Forward/backward component
		if(Input.GetKey(KeyCode.W)) {
			rigidbody.position += transform.forward * speed * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.S)) {
			rigidbody.position -= transform.forward * speed * Time.deltaTime;
		}
		
		// Left/right component
		if(Input.GetKey(KeyCode.A)) {
			rigidbody.position -= transform.right * speed * Time.deltaTime;
		}
		else if(Input.GetKey(KeyCode.D)) {
			rigidbody.position += transform.right * speed * Time.deltaTime;
		}
	}
	
	public void PickupPlunger() {
		playerPlunger.SetActive(true);
	}
}
