using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovementScript : MonoBehaviour
{
    //public Vector3 hitPoint;
    //public GameObject dirt;
    //public GameObject blood;
    //public AudioSource myShot;
    // Start is called before the first frame update
    void Start()
    {
        //this.GetComponent<Rigidbody>().AddForce((hitPoint - this.transform.position) * speed);
    }
 
    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 1f);
    }
 
    void OnTriggerEnter(Collider col) {
        if (col.tag == "Enemy")
        {
            col.gameObject.GetComponent<EnemyScriptCow>().currentHealth -= 10;
            //GameObject newBlood = Instantiate(blood, this.transform.position, this.transform.rotation);
            //newBlood.transform.parent = col.transform;
            Debug.Log("Hit an enemy");
            Destroy(this.gameObject);
        }
        //else
        //{
        //    Instantiate(dirt, this.transform.position, this.transform.rotation);
        //    Destroy(this.gameObject);
        //}

        if(col.tag == "Bounds" || col.tag == "Environment" || col.tag == "Shield"){
            Destroy(this.gameObject);
        }
    }
}
