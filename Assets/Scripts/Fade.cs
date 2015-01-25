using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fade : MonoBehaviour {

	public bool fadeIn;
	public string nextLevel;

	// Use this for initialization
	void Start () {
		if(fadeIn) {
			StartCoroutine(FadeFromBlack());
		}
		else {
			StartCoroutine(FadeToBlack());
		}
	}
	
	IEnumerator FadeFromBlack() {
		while(gameObject.GetComponent<Image>().color.a > 0.01f) {
			gameObject.GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, Mathf.Lerp(gameObject.GetComponent<Image>().color.a, 0.0f, Time.deltaTime * 2.0f));
			yield return null;
		}
		gameObject.GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
	}
	
	IEnumerator FadeToBlack() {
		while(gameObject.GetComponent<Image>().color.a < 0.99f) {
			gameObject.GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, Mathf.Lerp(gameObject.GetComponent<Image>().color.a, 1.0f, Time.deltaTime * 2.0f));
			yield return null;
		}
		gameObject.GetComponent<Image>().color = Color.black;
		Application.LoadLevel(nextLevel);
	}
}
