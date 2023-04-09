using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Lock_Script : MonoBehaviour
{

    public GameObject door;
    //public GameObject original;

    private int bCounter;

    private bool isOpen;

    public static string _isLocked;


    // Start is called before the first frame update
    void Start()
    {
        _isLocked = "true";
    }

    // Update is called once per frame
    void Update()
    {
        if (PickUp_Lock_2023.hasKey == "Yes")
        {
            _isLocked = "false";
            Debug.Log("Unclocked");
        }

        if ((isOpen == true) && (_isLocked == "false"))
        {
            Opening();
            if (Input.GetKeyDown(KeyCode.Q))
            {
                bCounter += 1;
                print("Pressed:" + bCounter);
            }
        }

        //if ((Input.GetKey(KeyCode.Q)) && (bCounter == 2))
        //{
        //    Invoke("Closing", 1f);
        //    Debug.Log("is Invoked");
        //}
    }

    private void OnTriggerStay(Collider other)
    {
        if (PickUp_Lock_2023.hasKey == "Yes")
        {
            isOpen = true;
            Debug.Log("Can be Opened");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //isOpen = false;
        PickUp_Lock_2023.hasKey = "No";
        Debug.Log("No key");

        if (PickUp_Lock_2023.hasKey == "No")
        {
            //original.SetActive(false);
            //gameObject.SetActive(false);
        }
    }

    void Opening()
    {
        if ((Input.GetKey(KeyCode.Q)) && (bCounter >= 0))
        {
            door.GetComponent<Animator>().SetBool("isOpening", true);

            if (bCounter >= 2)
            {
                isOpen = false;
                bCounter = 0;
            }
        }
    }

    void Closing()
    {
        door.GetComponent<Animator>().SetBool("isOpening", false);
        bCounter = 0;
    }
}
