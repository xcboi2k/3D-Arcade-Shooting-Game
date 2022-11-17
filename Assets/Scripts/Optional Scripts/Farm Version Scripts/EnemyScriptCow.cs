using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScriptCow : MonoBehaviour
{
    public float currentHealth = 500;
    public ParticleSystem deathParticles;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth < 0){
            GameObject.Find("Gameplay Controller").GetComponent<ScoreScript>().score += 10;
            GameObject.Find("Spawn Controller").GetComponent<EnemyObserverScript>().enemyNumber -= 1;
            Instantiate(deathParticles, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
