using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator_Lerp : MonoBehaviour
{
    public GameObject elevator_OBJ;
    public Vector3 position_01;
    public Vector3 position_02;
    public float speed;
    public KeyCode keyCommand;

    private Transform origin;
    private bool _isSTILL;
    private bool _isGoing;
    // Start is called before the first frame update
    void Start()
    {
        _isGoing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isGoing)
            elevatorControl();
    }

    private void OnTriggerStay(Collider other)
    {
        _isGoing = true;
    }

    private void OnTriggerExit(Collider other)
    {
        _isGoing = false;
    }

    void elevatorControl()
    {
        if (Input.GetKeyDown(keyCommand))
        {
            _isSTILL = !_isSTILL;
            if (_isSTILL)
                elevator_OBJ.transform.position = Vector3.Lerp(elevator_OBJ.transform.localPosition, position_02, speed * Time.deltaTime);
            else
                elevator_OBJ.transform.position = Vector3.Lerp(position_02 ,position_01, speed * Time.deltaTime);

        }
    }
}
