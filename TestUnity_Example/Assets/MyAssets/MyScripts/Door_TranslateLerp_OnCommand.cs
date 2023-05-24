using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_TranslateLerp_OnCommand : MonoBehaviour
{
    public GameObject door;
    public Vector3 position_Origin;
    public Vector3 position_Goal;
    public float speed;
    public KeyCode keyCommand;

    private bool _isIn;
    private bool _isStill;
    private bool _isGoing;

    // Start is called before the first frame update
    void Start()
    {
        _isIn = false;
        _isGoing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isIn)
            DoorCTRL();
        if (_isGoing)
            door.transform.position = Vector3.Slerp(door.transform.position, position_Goal, speed*Time.deltaTime);
        else
            door.transform.position = Vector3.Slerp(door.transform.position, position_Origin, speed*Time.deltaTime);
    }

    private void OnTriggerStay(Collider other)
    {
        _isIn = true;
    }

    private void OnTriggerExit(Collider other)
    {
        _isIn = false;
    }

    void DoorCTRL()
    {
        if (Input.GetKeyDown(keyCommand))
            _isStill = !_isStill;
        if (_isStill)
            _isGoing = true;
        else
            _isGoing = false;
    }
}
