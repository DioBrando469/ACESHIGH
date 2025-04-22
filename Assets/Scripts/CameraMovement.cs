using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    InputSys inputSys;
    float sens;
    [SerializeField] Transform cam;
    [SerializeField] Transform orientation;
    bool paused = false;
    float mouseX;
    float mouseY;
    float multiplier = 0.5f;
    float xRotation;
    float yRotation;

    public void SetSens(){
        inputSys = gameObject.transform.parent.gameObject.GetComponent<InputSys>();
        sens = inputSys.sens;
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SetSens();
    }
    void Update()
    {
        if (paused == false)
        {
            mouseX = Input.GetAxisRaw("Mouse X");
            mouseY = Input.GetAxisRaw("Mouse Y");

            yRotation += mouseX * sens * multiplier;
            xRotation -= mouseY * sens * multiplier;

            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            cam.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.transform.rotation = Quaternion.Euler(0, yRotation, 0);
        }
        
    }
    public void PauseMouseInput(bool pause){
        paused = pause;
    }
}
