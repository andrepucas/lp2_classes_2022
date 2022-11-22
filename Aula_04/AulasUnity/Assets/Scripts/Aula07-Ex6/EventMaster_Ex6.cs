﻿using System;
using UnityEngine;
using UnityEngine.Events;

public class EventMaster_Ex6 : MonoBehaviour
{
    // The background image
    [SerializeField] private Texture background = null;

    [SerializeField] private UnityEvent<char> keyPressed;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) OnKeyPress('W');
        if (Input.GetKeyDown(KeyCode.S)) OnKeyPress('S');
        if (Input.GetKeyDown(KeyCode.A)) OnKeyPress('A');
        if (Input.GetKeyDown(KeyCode.D)) OnKeyPress('D');
    }

    // Use Unity's immediate mode GUI (IMGUI) to display information
    private void OnGUI()
    {
        // Set this GUI rendering to background
        GUI.depth = 1;

        // Draw background
        if (background != null)
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height),
            background, ScaleMode.StretchToFill);

        // Set default GUI color
        GUI.color = Color.white;

        // Show label for pressing keys
        GUI.Label(new Rect(10, 10, 200, 50), "Press W, S, A, D keys");
    }

    private void OnKeyPress(char key)
    {
        keyPressed.Invoke(key);
    }
}
