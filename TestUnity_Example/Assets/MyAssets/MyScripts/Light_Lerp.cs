using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Lerp : MonoBehaviour
{
    public Light lightOBj;
    public float lightLevel01;
    public float llightLevel02;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lightOBj.intensity >= 0)
            lightOBj.intensity = Mathf.Lerp (lightOBj.intensity, lightLevel01, speed*Time.deltaTime);
    }
}
