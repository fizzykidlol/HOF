using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthquakeShaker : MonoBehaviour
{

	public float power = 0.7f;
	public float duration = 1.0f;
	public new Transform camera;
	public float slowDownAmount = 1.0f;
	public bool shouldShake = false;

	Vector3 startPosition;
	float initialDuration;


	// Use this for initialization
	void Start()
	{
		camera = Camera.main.transform;
		startPosition = camera.localPosition;
		initialDuration = duration;

	}

	// Update is called once per frame
	void Update()
	{
		if (shouldShake)
		{
			if (duration > 0)
			{
				camera.localPosition = startPosition + UnityEngine.Random.insideUnitSphere * power;
				duration -= Time.deltaTime * slowDownAmount;
			}
			else
			{
				shouldShake = false;
				duration = initialDuration;
				camera.localPosition = startPosition;
			}
		}


	}

	public static implicit operator EarthquakeShaker(bool v)
	{
		throw new NotImplementedException();
	}
}