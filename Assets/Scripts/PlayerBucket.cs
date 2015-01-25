using UnityEngine;
using System.Collections;

public class PlayerBucket : MonoBehaviour {

	public GameObject worldBucket;
	public float throwForce;
	public float range;
	
	public AudioSource swing;
	public GameObject water;
	public GameObject particles;
	
	private bool full = false;
	private GlobalInput gameManager;
	
	void Start() {
		gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalInput>();
	}
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.Mouse0)) {
			if(!animation.isPlaying) {
				animation.Play();
				swing.Play();
			
				RaycastHit hit;
				if(Physics.Raycast(transform.parent.position, transform.parent.forward, out hit, range)) {
					if(hit.transform.tag == "Bailable" && !full && !gameManager.sinkFlooding && !gameManager.toiletFlooding) {
						hit.transform.gameObject.SendMessage("Bail");
						full = true;	
						water.SetActive(true);
					}
					else if(hit.transform.tag == "Dumpable" && full) {
						full = false;	
						water.SetActive(false);
						particles.particleSystem.Play();
					}
				}
			}
		}
		
		if(Input.GetKeyDown (KeyCode.Mouse1)) {
			GameObject p = Instantiate (worldBucket, transform.position, transform.rotation) as GameObject;
			p.rigidbody.velocity = transform.parent.gameObject.transform.forward * throwForce;
			gameManager.playerHolding = false;
			gameObject.SetActive(false);
		}
	}
}
