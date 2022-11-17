using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//public enum State
//{
//    On,
//    Off
//}

public class CommandReader : MonoBehaviour
{
    //[SerializeField]
    //Text text;

    //State currentState = State.On;

    [SerializeField] private Rigidbody bullet;
    private float launchForce = 500f;

    // Reads input string and executes a command if it is valid.
    public void ReadInput(string input)
    {
        GameObject originalGameObject = GameObject.FindWithTag("Cannon");
        float angleX;
        switch (input)
        {
            case "left":
                //if (currentState == State.On)
                //{
                //    return;
                //}
                //text.text = "On";
                //text.color = Color.green;
                //currentState = State.On;
                angleX = -5 * Time.deltaTime * 50f;
                originalGameObject.transform.Rotate(0, 0, angleX, Space.Self);
                break;
            case "right":
                //if (currentState == State.Off)
                //{
                //    return;
                //}
                //text.text = "Off";
                //text.color = Color.red;
                //currentState = State.Off;
                angleX = 5 * Time.deltaTime * 50f;
                originalGameObject.transform.Rotate(0, 0, angleX, Space.Self);
                break;
            case "fire":
                Transform child = originalGameObject.transform.GetChild(0);
                var projectileInstance = Instantiate(bullet, child.position, child.rotation);
                var rigidbody = projectileInstance.GetComponent<Rigidbody>();
                projectileInstance.AddForce(child.forward * launchForce);
                break;
            default:
                return;
        }
    }
}
