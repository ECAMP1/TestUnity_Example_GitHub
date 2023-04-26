using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSplash : MonoBehaviour
{
    public Transform splashSpawn;
    public ParticleSystem waterSplash;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Instantiate(waterSplash, splashSpawn.position, splashSpawn.rotation);
    }
}
