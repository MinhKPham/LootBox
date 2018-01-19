using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickTest : MonoBehaviour {

    // Use this for initialization
    void Awake() {
        string[] names = Input.GetJoystickNames();
        Debug.Log("Connected Joysticks:");
        for(int i = 0; i < names.Length; i++) {
            Debug.Log("Joystick" + (i + 1) + " = " + names[i]);
        }
    }

    // Update is called once per frame, (if any joystick was connected during gameplay
    void Update() {
        Debug.Log(Input.GetJoystickNames().Length);
    }
}
