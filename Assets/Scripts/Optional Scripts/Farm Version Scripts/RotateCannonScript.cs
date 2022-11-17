using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCannonScript : MonoBehaviour
{
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float angleX = xDirection * Time.deltaTime * speed;
        this.transform.Rotate(0, 0, angleX, Space.Self);
        Debug.Log("Rotate horizontally: " + xDirection);
    }
}
