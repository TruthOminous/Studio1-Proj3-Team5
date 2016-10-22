using UnityEngine;
using System.Collections;

public class CameraRotate : MonoBehaviour {

    public float verticalMouseSensitivity = 1.0f;
    public float clampAngleX = 80.0f;
    public float clampAngleY = 80.0f;
    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis

    // Use this for initialization
    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
    }

    // Update is called once per frame
    void Update()
    {
        CameraRotation();
    }

    void CameraRotation()
    {        
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        rotY += mouseX * verticalMouseSensitivity;
        rotX += mouseY * verticalMouseSensitivity;

        rotX = Mathf.Clamp(rotX, -clampAngleX, clampAngleX);
        rotY = Mathf.Clamp(rotY, -clampAngleY, clampAngleY);

        Quaternion localRotation = Quaternion.Euler(rotX, 0.0f, 0.0f);
        transform.localRotation = localRotation;       
    }
}