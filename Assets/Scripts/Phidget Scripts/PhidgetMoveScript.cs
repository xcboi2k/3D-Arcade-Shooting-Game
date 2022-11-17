using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Phidget22;
using Phidget22.Events;

public class PhidgetMoveScript : MonoBehaviour
{
    VoltageRatioInput joystickX = new VoltageRatioInput();
    VoltageRatioInput joystickY = new VoltageRatioInput();
    
    private float moveHorizontal;
    private float moveVertical;

    public int Xchannel = 7;
    public int Ychannel = 6;
    // Start is called before the first frame update
    void Start()
    {
        joystickX.DeviceSerialNumber = 1113;
        joystickY. DeviceSerialNumber = 1113;

        //joystickX.HubPort = -1; 
        joystickX.Channel = Xchannel;
        joystickX.VoltageRatioChange += joystickChange;
        joystickX.Open();
        
        //joystickY.HubPort = Ychannel;
        joystickY.Channel = Ychannel;
        joystickY.VoltageRatioChange += joystickChange;
        joystickY.Open();

        //vertical = new VoltageRatioInput();
        //horizontal = new VoltageRatioInput();

        //vertical.Channel = 6;
        //horizontal.Channel = 7;

        //vertical.Open(1000);
        //horizontal.Open(1000);

        //vertical.DataInterval = vertical.MinDataInterval;
        //horizontal.DataInterval = horizontal.MinDataInterval;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //float xDirection = (float)horizontal.VoltageRatio;
        //float yDirection = (float)vertical.VoltageRatio;    

        Vector3 moveDirection = new Vector3(moveHorizontal, moveVertical, 0.00f);
        transform.position += moveDirection;
    }

    void joystickChange(object sender, VoltageRatioInputVoltageRatioChangeEventArgs e)
    {
        VoltageRatioInput axis = (VoltageRatioInput)sender;
        if(axis.Channel == 0) //X
        {
            moveHorizontal = (float)axis.VoltageRatio;
        }
        else //Y
        {
            moveVertical = -((float)axis.VoltageRatio); //inverting this axis due to orientation of my thumbstick
        }
    }

    private void OnApplicationQuit()
    {
        joystickX.VoltageRatioChange -= joystickChange;
        joystickX.Close();
        joystickX = null;
        
        joystickY.VoltageRatioChange -= joystickChange;
        joystickY.Close();
        joystickY = null;

	    if (Application.isEditor){
            Phidget.ResetLibrary();
        }
        else {
	        Phidget.FinalizeLibrary(0);
        }
    }
}
