using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	private float speed = 1f;
	private float mxDelay = 4f;
	private bool isRight = true;
	private float timeMove = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		timeMove += Time.deltaTime;

		if (timeMove <= mxDelay) {

			if (isRight) {
				transform.Translate (-Vector2.right * speed * Time.deltaTime);
			} else {
				transform.Translate (Vector2.right * speed * Time.deltaTime);	
			}
		} else {
			isRight = !isRight;
			timeMove = 0;
		}
		
	}
}
