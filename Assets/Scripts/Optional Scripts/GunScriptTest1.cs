using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunScriptTest1 : MonoBehaviour
{
    private float launchForce = 700f;

    [SerializeField] private Transform laserHolder;
    [SerializeField] private Rigidbody bullet;

    //public GameObject shield;
    //private float shieldOnTime = 10f;
    //private float shieldRestingTime = 5f;
    //public Text shieldTimeText;
    //public Text shieldLabelText;
    //private bool onShield;
    //private bool startCharge;

    void Start()
    {
        //shieldLabelText.text = "Shield offline";
        //onShield = false;
        //startCharge = true;
    }

    // Update is called once per frame
    void Update()
    {
        //if(startCharge == true){
        //    shieldRestingTime -= Time.deltaTime;
        //    if(shieldRestingTime < 0){
        //        shieldLabelText.text = "Shield is ready";
        //        onShield = true;
        //    }
        //}
        //else{
        //    shieldOnTime -= Time.deltaTime;
        //    shieldTimeText.text = shieldOnTime.ToString("#.00");
        //    if(shieldOnTime < 0){
        //        shieldTimeText.text = "0";
        //        shieldRestingTime = 5f;
        //        shieldLabelText.text = "Shield cooldown";
        //        startCharge = true;
        //        shield.SetActive(false);
        //    }
        //}
        

        if (Input.GetButton("Fire1"))
        {
            Shoot();
            Debug.Log("Button1 is pressed.");
        }

        //if (Input.GetButton("Fire2"))
        //{
        //    if(onShield == true){
        //        shield.SetActive(true);
        //        Debug.Log("Button2 is pressed.");
        //        startCharge = false;
        //    }
        //}
    }

    void Shoot()
    {
        var projectileInstance = Instantiate(bullet, laserHolder.position, laserHolder.rotation);
        var rigidbody = projectileInstance.GetComponent<Rigidbody>();
        projectileInstance.AddForce(laserHolder.forward * launchForce);
    }
}
