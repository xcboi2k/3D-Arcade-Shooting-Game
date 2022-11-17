using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float currentHealth = 100;
    private float launchForce = 700f;
    [SerializeField] private Rigidbody bullet;
    [SerializeField] private Transform enemyLauncher;

    private float fireTime = 2f;

    public bool startShooting;


    void Start()
    {
        startShooting = true;
    }

    void Update()
    {
        if(startShooting == true){
            fireTime -= Time.deltaTime;
            if(fireTime < 0){
                Shoot();
                Debug.Log("Enemy firing.");
                fireTime = 2f;
            }

            if (currentHealth < 0){
                GameObject.Find("Gameplay Controller").GetComponent<ScoreScript>().score += 10;
                GameObject.Find("Spawn Controller").GetComponent<EnemyObserverScript>().enemyNumber -= 1;
                Destroy(this.gameObject);
            }
        }
    }

    void Shoot()
    {
        var projectileInstance = Instantiate(bullet, enemyLauncher.position, enemyLauncher.rotation);
        var rigidbody = projectileInstance.GetComponent<Rigidbody>();
        projectileInstance.AddForce(-enemyLauncher.forward * launchForce);
    }

}
