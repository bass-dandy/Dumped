using UnityEngine;
using System.Collections;

public class ToiletWaterLower : MonoBehaviour {

	void Lower() {
		StartCoroutine(LowerLerp(0.0104f));
	}
	
	IEnumerator LowerLerp(float endDepth) {
		while(transform.localPosition.y > endDepth + 0.0001f) {
			transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Lerp(transform.localPosition.y, endDepth, Time.deltaTime), transform.localPosition.z);
			yield return null;
		}
	}
}
