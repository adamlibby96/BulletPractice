using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

    float sensitivity = 3f;
    float _rotationX;

	// Use this for initialization
	void Start () {
        _rotationX = transform.rotation.y;
	}
	
	// Update is called once per frame
	void Update () {
        
        _rotationX -= Input.GetAxis("Mouse Y") * sensitivity;
        _rotationX = Mathf.Clamp(_rotationX, -180, 180);

        float delta = Input.GetAxis("Mouse X") * sensitivity;
        float rotationY = transform.localEulerAngles.y + delta;

        transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
    }
}
