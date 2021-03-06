﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CameraMotor : MonoBehaviour {

	private Transform lookAt;
	private Vector3 startOffset;
	private Vector3 moveVector;
	private int frame = 0;

	// Use this for initialization
	void Start () {
		lookAt = GameObject.FindGameObjectWithTag ("Player").transform;
		startOffset = transform.position - lookAt.position;

		StartCoroutine (Example ());
	} 

	IEnumerator Example()
	{
		yield return new WaitUntil(() => frame >= 300);
		SceneManager.LoadScene ("MainScene");
	}

	// Update is called once per frame
	void Update () {
		if (lookAt != null) {
			moveVector = lookAt.position + startOffset;

			// X
			moveVector.x = 0;

			//Y
			moveVector.y = Mathf.Clamp (moveVector.y, 3, 5);

			transform.position = moveVector;
		} else {
			frame++;
		}

	}
}
