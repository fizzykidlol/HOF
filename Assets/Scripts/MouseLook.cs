﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseLookLowerLimit = -50f;
    public float mouseLookUpperLimit = 50f;
    public Vector2 mouseLook;
    Vector2 smoothV;
    public float baseSensitivity = 5.0f;
    public float smoothing = 2.0f;
    public Player player;
    private bool deadDelay = false;

    GameObject character;

    // Use this for initialization
    void Start()
    {
        character = this.transform.parent.gameObject;
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!player.dead && !player.paused)
        {
            
            var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
            md = Vector2.Scale(md, new Vector2(baseSensitivity * smoothing 
                * SettingsManager.sensitivity, baseSensitivity * smoothing * SettingsManager.sensitivity));
            smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
            smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
            mouseLook += smoothV;

            mouseLook.y = Mathf.Clamp(mouseLook.y, mouseLookLowerLimit, mouseLookUpperLimit);
            transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
            character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
        }
    }

}