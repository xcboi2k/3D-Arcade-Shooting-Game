using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunScript : MonoBehaviour
{
    private float launchForce = 700f;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Transform laserHolder;
    [SerializeField] private Rigidbody bullet;

    private bool onShield;
    public GameObject shield;
    private float shieldOnTime;
    private float shieldRestingTime = 5f;
    public Text shieldTimeText;
    public Text shieldLabelText;

    public float xMultiplier, yMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        onShield = false;
    }
 
    // Update is called once per frame
    void Update()
    {
        shieldRestingTime -= Time.deltaTime;
        if(shieldRestingTime < 0){
            shieldLabelText.text = "Shield is ready";
            onShield = true;
        }

        if (Input.GetButton("Fire1"))
        {
            Shoot();
            Debug.Log("Button1 is pressed.");
        }

        else if (Input.GetButton("Fire2"))
        {
            if(onShield == true){
                shield.SetActive(true);
                shieldOnTime = 10f;
                shieldLabelText.text = "Shield is activated";
                Debug.Log("Button2 is pressed.");

                shieldOnTime -= Time.deltaTime;
                if(shieldOnTime < 0){
                    onShield = false;
                    shieldRestingTime = 5f;
                    shieldLabelText.text = "Shield cooldown";
                }
            }
        }
    }
 
    void Shoot()
    {
        var projectileInstance = Instantiate(bullet, laserHolder.position, laserHolder.rotation);
        var rigidbody = projectileInstance.GetComponent<Rigidbody>();
        rigidbody.velocity = transform.TransformDirection(-shootPoint.position.x * xMultiplier, shootPoint.position.y * yMultiplier, shootPoint.position.z);
        //bullet.position = Vector3.MoveTowards(laserHolder.position, shootPoint.position, Time.deltaTime);
        //projectileInstance.AddForce(laserHolder.forward * launchForce);
    }
}
