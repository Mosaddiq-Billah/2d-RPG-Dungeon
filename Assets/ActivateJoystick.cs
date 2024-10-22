using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateJoystick : MonoBehaviour
{

    public GameObject joystick;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!joystick.activeInHierarchy)
        {
            joystick.SetActive(true);
        }
    }
}
