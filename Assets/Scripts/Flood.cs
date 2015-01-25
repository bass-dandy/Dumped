using UnityEngine;
using System.Collections;

public class Flood : MonoBehaviour {

	public GameObject puddles;
	
	private GlobalInput gameManager;
	
	void Start() {
		gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalInput>();
	}

	void Raise() {
		StartCoroutine(RaiseLerp(transform.position.y + 0.25f));
		gameManager.flooded = true;
	}
	
	void Lower() {
		StartCoroutine(LowerLerp(transform.position.y - 0.05f));
	}
	
	IEnumerator RaiseLerp(float endDepth) {
		while(transform.position.y < endDepth - 0.01f) {
			transform.position = new Vector3(0.0f, Mathf.Lerp(transform.position.y, endDepth, Time.deltaTime), 0.0f);
			yield return null;
		}
	}
	
	IEnumerator LowerLerp(float endDepth) {
		while(transform.position.y > endDepth + 0.01f) {
			transform.position = new Vector3(0.0f, Mathf.Lerp(transform.position.y, endDepth, Time.deltaTime * 10.0f), 0.0f);
			yield return null;
		}
		if(transform.localPosition.y < 0.47f) {
			transform.position = Vector3.zero;
			gameManager.flooded = false;
			puddles.SetActive(true);
		}
	}
}
