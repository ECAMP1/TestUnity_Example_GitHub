using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public GameObject pickUp;
    public GameObject original;

    // Start is called before the first frame update
    void Start()
    {
        original.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.Q))
        {
            KeyOff();
        }
    }

    void KeyOff()
    {
        pickUp.SetActive(false);
        original.SetActive(true);
    }
}
