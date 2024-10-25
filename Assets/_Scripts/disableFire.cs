using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableFire : MonoBehaviour
{
    private Joystick joystick;
    public GameObject aimGameObject;
    // Start is called before the first frame update
    void Start()
    {
        joystick = this.gameObject.GetComponent<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            // Disable the Aim GameObject
            aimGameObject.SetActive(false);
        }
        else
        {
            // Enable the Aim GameObject when the joystick is not moved
            aimGameObject.SetActive(true);
        }
    }
}
