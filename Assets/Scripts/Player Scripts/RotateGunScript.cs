using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGunScript : MonoBehaviour
{
    public float speed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float yDirection = Input.GetAxis("Vertical");

        float angleX = xDirection * Time.deltaTime * speed;
        float angleY = yDirection * Time.deltaTime * speed;

        this.transform.Rotate(angleY, 0, 0, Space.Self);
        Debug.Log("Rotate vertically: " + yDirection);
        this.transform.Rotate(0, angleX, 0, Space.Self);
        Debug.Log("Rotate horizontally: " + xDirection);

    }

}
