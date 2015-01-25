using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	public float speed;
	public Transform head;
	
	public GameObject playerPlunger;
	public GameObject playerFabreez;
	public GameObject playerCloth;
	public GameObject playerBucket;
	
	public AudioSource pickup;
	
	public Camera eyes;
	public Transform door;
	
	private GlobalInput gameManager;
	
	void Start() {
		gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalInput>();
	}
	
	void Update () {
		if(gameManager.playerCanMove) {
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
	}
	
	public void PickupPlunger() {
		playerPlunger.SetActive(true);
		pickup.Play();
		gameManager.playerHolding = true;
	}
	
	public void PickupFabreez() {
		playerFabreez.SetActive(true);
		pickup.Play();
		gameManager.playerHolding = true;
	}
	
	public void PickupCloth() {
		playerCloth.SetActive(true);
		pickup.Play();
		gameManager.playerHolding = true;
	}
	
	public void PickupBucket() {
		playerBucket.SetActive(true);
		pickup.Play();
		gameManager.playerHolding = true;
	}
	
	void Lose() {
		door.transform.parent.animation.Play();
		door.transform.parent.audio.Play();
		StartCoroutine(LookAtDoor());
	}
	
	IEnumerator LookAtDoor() {
		Vector3 relativePos = -transform.position + door.transform.position;
		relativePos.y = 0;
		Quaternion dest = Quaternion.LookRotation (relativePos);
		while(true) {
			eyes.transform.rotation = Quaternion.RotateTowards(eyes.transform.rotation, dest, 5.0f);
			yield return null;	
		}
	}
}
