using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    private Vector3 shakeRange = new Vector3(1.5f,1.5f,0);
    private float shakeSpeed = 50f;
    private float duration = 0.1f;
	private float shakeTimer;

    private Vector3 initialPosition;
    public static bool isShaking = false;

    // Use this for initialization
    void Start () {
        initialPosition = transform.localPosition;
		shakeTimer = 3.0f;
	}

    // Update is called once per frame
    void Update () {

        //if (Input.GetKeyDown(KeyCode.K)) {
        //    isShaking = true;
        //}
        //if (Input.GetKeyUp(KeyCode.K)) {
        //    isShaking = false;
        //}
        
		if (isShaking && shakeTimer > 0) {
			transform.localPosition = initialPosition + Vector3.Scale (SmoothRandom.GetVector2 (shakeSpeed--), shakeRange);
			shakeTimer -= Time.deltaTime;
		} 
	}

    void Shake(float amplitude, float duration) {
        isShaking = true;
        Invoke("StopShaking", duration);
    }
    void StopShaking(float amplitude, float duration) {
        isShaking = false;
        transform.localPosition = initialPosition;
    }
}
