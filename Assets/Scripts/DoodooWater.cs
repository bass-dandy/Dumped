using UnityEngine;
using System.Collections;

public class DoodooWater : MonoBehaviour {

	public GameObject waterLine;

	void Bail() {
		waterLine.SendMessage("Lower");
	}
}
