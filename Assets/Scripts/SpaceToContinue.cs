﻿using UnityEngine;
using System.Collections;

public class SpaceToContinue : MonoBehaviour {

	public string nextLevel;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
			Application.LoadLevel(nextLevel);
	}
}
