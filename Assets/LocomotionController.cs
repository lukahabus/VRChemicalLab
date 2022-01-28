using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class LocomotionController : MonoBehaviour
{
    ActionBasedController controller;
    //public XRController leftTeleportRay;
    //public XRController rightTeleportRay;
    //public InputHelpers.Button teleportActivationButton;
    //public float activationThreshold = 0.1f;
    InputAction action = new InputAction(type: InputActionType.Button, binding: "<XRController>{LeftHand}/primaryButton");

    void Start()
    {
        controller = GetComponent<ActionBasedController>();
        action.performed += ctx => Debug.Log("Pressed");
        action.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.enabled)
        {
            controller.gameObject.SetActive(true);
        }
        /*if(leftTeleportRay)
        {
            leftTeleportRay.gameObject.SetActive(CheckIfActivated(leftTeleportRay));
        }

        if(rightTeleportRay)
        {
            rightTeleportRay.gameObject.SetActive(CheckIfActivated(rightTeleportRay));
        }*/
    }

    /*public bool CheckIfActivated()
    {
        
        InputHelpers.IsPressed(controller.inputDevice, teleportActivationButton, out bool isActivated, activationThreshold);
        return isActivated;
    }*/
}
