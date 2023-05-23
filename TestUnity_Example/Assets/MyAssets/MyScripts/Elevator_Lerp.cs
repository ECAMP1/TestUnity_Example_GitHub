using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Elevator_Lerp : MonoBehaviour
{
    public GameObject elevator_OBJ;
    public Vector3 position_Origin;
    public Vector3 position_Goal;
    public AnimationCurve curve;
    public KeyCode keyCommand;
    public float speed;
   
    private GameObject _thePlayer;
    private bool _isSTILL;
    private bool _isGoing;
    private bool _isIn;

    // Start is called before the first frame update
    void Start()
    {
        _thePlayer = GameObject.FindWithTag("Player");
        _isGoing = false;
        _isIn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isIn)
            elevatorControl();

        if (_isGoing)
            elevator_OBJ.transform.position = Vector3.Lerp(elevator_OBJ.transform.position, position_Goal, curve.Evaluate(speed * Time.deltaTime));
        else
            elevator_OBJ.transform.position = Vector3.Lerp(elevator_OBJ.transform.position, position_Origin, curve.Evaluate (speed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            _thePlayer.transform.parent = elevator_OBJ.transform;
    }

    private void OnTriggerStay(Collider other)
    {
        _isIn = true;
    }
    private void OnTriggerExit(Collider other)
    {
        _isIn = false;
        if (other.tag == "Player")
            _thePlayer.transform.parent = null;
    }

    void elevatorControl()
    {
        if (Input.GetKeyDown(keyCommand))
        {
            _isSTILL = !_isSTILL;
            if (_isSTILL)
            {
                _isGoing = true;
                Debug.Log("1st check");
            }
            else
            {
                _isGoing = false;
                Debug.Log("2nd check");
            }

        }
    }
}
