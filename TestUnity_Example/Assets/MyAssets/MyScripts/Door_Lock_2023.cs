using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Lock_2023 : MonoBehaviour
{
    public GameObject door;
    public GameObject key;

    private bool _isOpen;
    public static string _isLocked;
    // Start is called before the first frame update
    void Start()
    {
        _isLocked = "true";
        _isOpen = false;
    }
 
    // Update is called once per frame
    void Update()
    {
        if (PickUp_Lock_2023.hasKey == "Yes")
        {
            _isLocked = "false";
            Debug.Log("Unclocked");
        }

        if ((_isOpen == true) && (_isLocked == "false"))
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Opening();
                PickUp_Lock_2023.hasKey = "No";
                Debug.Log("No key");
                key.SetActive(false);
                gameObject.SetActive(false);

            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (PickUp_Lock_2023.hasKey == "Yes")
        {
            _isOpen = true;
            Debug.Log("Can be Opened");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PickUp_Lock_2023.hasKey = "No";
        Debug.Log("No key");
    }

    void Opening()
    {
        door.GetComponent<Animator>().SetBool("isOpening", true);
    }
}
