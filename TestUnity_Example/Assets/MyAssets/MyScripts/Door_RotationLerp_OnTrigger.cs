using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_RotationLerp_OnTrigger : MonoBehaviour
{
    public GameObject door;
    public Quaternion rotation_Origin;
    public Quaternion rotation_Goal;
    public float speed;

    private bool _isTriggered;
    // Start is called before the first frame update
    void Start()
    {
        _isTriggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isTriggered)
            door.transform.rotation = Quaternion.RotateTowards(door.transform.rotation, rotation_Goal, speed);
        else
            door.transform.rotation = Quaternion.RotateTowards(door.transform.rotation, rotation_Origin, speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        _isTriggered = true;
    }

    private void OnTriggerExit(Collider other)
    {
        _isTriggered = false;
    }
}
