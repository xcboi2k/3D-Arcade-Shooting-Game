using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObserverScript : MonoBehaviour
{
    public float enemyNumber;
    public float resetNumber;
    void Start()
    {
        enemyNumber = resetNumber;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyNumber == 0){
            GameObject.Find("Spawn Controller").GetComponent<SpawnControllerScript>().activateSpawn = true;
            enemyNumber = resetNumber;
        }
    }
}
