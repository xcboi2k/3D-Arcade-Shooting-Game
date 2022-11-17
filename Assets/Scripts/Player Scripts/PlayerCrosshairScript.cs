using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCrosshairScript : MonoBehaviour
{
    public GameObject crossHair;
    public float speed;
    public Transform gun;

    //public GameObject shootingPoint;
    //public float transformX, transformY;

    void Update()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float yDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xDirection, yDirection, 0.00f);
        crossHair.transform.position += moveDirection * speed;
    }
}
