using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEffectScript : MonoBehaviour
{
    public float time;
    void Start()
    {
        Destroy(gameObject, time);
    }

}
