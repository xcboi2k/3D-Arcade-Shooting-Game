using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnControllerScript : MonoBehaviour
{
    public bool activateSpawn;
    
    public GameObject enemyPrefab;
    public GameObject[] spawnPoint;
    public float totalSpawnPoints;

    private float wave = 1;
    public Text waveNumberText;

    void Start()
    {
        activateSpawn = false;
    }

    // Update is called once per frame
    void Update()
    {
        waveNumberText.text = wave.ToString();
        if(activateSpawn == true){
            for(int i = 0; i < totalSpawnPoints; i++){
                Spawn(i);
            }
            activateSpawn = false;
            wave++;
        }
    }

    private void Spawn(int index){
        Instantiate(enemyPrefab, spawnPoint[index].transform.position, spawnPoint[index].transform.rotation);
        activateSpawn = false;
    }
}
