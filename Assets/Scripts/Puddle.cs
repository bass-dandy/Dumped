using UnityEngine;
using System.Collections;

public class Puddle : MonoBehaviour {

	public float shrinkFactor;

	private GlobalInput gameManager;
	private bool shrinking;
	private float naturalSize;

	void Start() {
		gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalInput>();
		gameManager.numPuddles++;
		naturalSize = transform.localScale.x;
		transform.localScale = new Vector3(0.0f, transform.localScale.y, 0.0f);
		StartCoroutine(Grow());
	}

	void Wipe() {
		if(!shrinking)
			StartCoroutine(Shrink());
	}
	
	IEnumerator Grow() {
		while(transform.localScale.x < naturalSize - 0.01f) {
			float newDimensions = Mathf.Lerp(transform.localScale.x, naturalSize, Time.deltaTime * 10.0f);
			transform.localScale = new Vector3(newDimensions, transform.localScale.y, newDimensions);
			yield return null;
		}
	}
	
	IEnumerator Shrink() {
		shrinking = true;
		float endSize = Mathf.Clamp(transform.localScale.x - shrinkFactor, 0.0f, Mathf.Infinity);
		while(transform.localScale.x > endSize + 0.01f) {
			float newDimensions = Mathf.Lerp(transform.localScale.x, endSize, Time.deltaTime * 10.0f);
			transform.localScale = new Vector3(newDimensions, transform.localScale.y, newDimensions);
			yield return null;
		}
		if(transform.localScale.x < 0.01f) {
			gameManager.numPuddles--;
			Destroy(gameObject);
		}
		shrinking = false;
	}
}
