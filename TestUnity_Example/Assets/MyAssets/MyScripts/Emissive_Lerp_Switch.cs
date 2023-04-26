using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emissive_Lerp_Switch : MonoBehaviour
{
    public GameObject assetOBJ;
    public Material emissiveMTL;
    public Color BaseColor;

    public float minEmissiveValue;
    public float maxEmissiveValue;
    public float speed;

    public bool isBrighten;
    public bool isDimming;
    private bool _isIn;
    private bool _isOut;
    // Start is called before the first frame update
    void Start()
    {
        if (isBrighten)
            emissiveMTL.SetColor("_EmissionColor", BaseColor * 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (_isIn)
            EmissiveLERPUP();
        if (_isOut)
            EmissiveLERPDown();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isBrighten)
            _isIn = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (isDimming)
            _isOut = true;
    }

    void EmissiveLERPUP()
    {
        minEmissiveValue = Mathf.MoveTowards(minEmissiveValue, maxEmissiveValue, speed * Time.deltaTime);
        emissiveMTL.SetColor("_EmissionColor", BaseColor * minEmissiveValue);
    }

    void EmissiveLERPDown ()
    {
        maxEmissiveValue = Mathf.MoveTowards(maxEmissiveValue, minEmissiveValue, speed * Time.deltaTime);
        emissiveMTL.SetColor("_EmissionColor", BaseColor * maxEmissiveValue);
    }
}
