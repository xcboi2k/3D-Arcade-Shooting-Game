using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player;
    public Transform cam;

    public float xSensitivity;
    public float ySensitivity;
    public float maxAngle;

    private Quaternion camCenter;

    // Start is called before the first frame update
    void Start()
    {
        camCenter = cam.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        SetY();
        SetX();
    }

    void SetY(){
        float t_input = Input.GetAxis("JoystickY") * ySensitivity * Time.deltaTime;
        Quaternion t_adj = Quaternion.AngleAxis(t_input, -Vector3.right);
        Quaternion t_delta = cam.localRotation * t_adj;

        if(Quaternion.Angle(camCenter, t_delta) < maxAngle){
            cam.localRotation = t_delta;
        }

        Debug.Log("Y is moving");
    }

    void SetX(){
        float t_input = Input.GetAxis("JoystickX") * xSensitivity * Time.deltaTime;
        Quaternion t_adj = Quaternion.AngleAxis(t_input, Vector3.up);
        Quaternion t_delta = player.localRotation * t_adj;
        player.localRotation = t_delta;

        Debug.Log("X is moving");
    }
}
