using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaserScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider col) {
        if(col.tag == "Bounds" || col.tag == "Shield"){
            Destroy(this.gameObject);
            Debug.Log("Out of bounds");
        }
    }
}
