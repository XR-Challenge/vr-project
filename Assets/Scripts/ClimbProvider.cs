using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClimbProvider : MonoBehaviour
{

    public static event Action ClimbActive;
    public static event Action ClimbInactive;

    public CharacterController characterController;
    public InputActionProperty velocityRight;
    public InputActionProperty velocityLeft;

    private bool _rightActive = false;
    private bool _leftActive = false;

    private void Start()
    {
        XRDirectClimb.ClimbHandActivated += HandActivated;
        XRDirectClimb.ClimbHandDeactivated += HandDeactivated;
    }

    private void OnDestroy()
    {
        XRDirectClimb.ClimbHandActivated -= HandActivated;
        XRDirectClimb.ClimbHandActivated -= HandDeactivated;
    }

    private void HandActivated(string _controllerName)
    {
        if(_controllerName == "LeftHand Controller")
        {
            _leftActive = true;
            _rightActive = false;
        }
        else
        {
            _leftActive = false;
            _rightActive = true;
        }

        ClimbActive?.Invoke();
    }

    private void HandDeactivated(string _controllerName)
    {
        if(_rightActive && _controllerName == "RightHand Controller")
        {
            _rightActive = false;
            ClimbInactive?.Invoke();
        }
        else if(_leftActive && _controllerName == "LeftHand Controller")
        {
            _leftActive = false;
            ClimbInactive?.Invoke();
        }
    }

    private void FixedUpdate()
    {
        if(_rightActive || _leftActive)
        {
            Climb();
        }
    }

    private void Climb()
    {
        Vector3 velocity = _leftActive ? velocityLeft.action.ReadValue<Vector3>() : velocityRight.action.ReadValue<Vector3>();

        characterController.Move(characterController.transform.rotation * -velocity * Time.fixedDeltaTime);
    }
}
