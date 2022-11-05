using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportToggle : MonoBehaviour
{
    // Based on Unity XR tutorial
    public XRRayInteractor rayInteractor;
    private XRDirectInteractor directInteractor;
    public InputActionReference action;

    void Awake()
    {
        directInteractor = GetComponent<XRDirectInteractor>();
        action.action.started += Pressed;
        action.action.canceled += Released;
        SetState(false);
    }

    void OnDestroy()
    {
        action.action.started -= Pressed;
        action.action.canceled -= Released;
    }

    private void OnEnable()
    {
        action.action.Enable();
    }

    private void OnDisable()
    {
        action.action.Disable();
    }

    void Pressed(InputAction.CallbackContext context)
    {
        SetState(true);
    }

    void Released(InputAction.CallbackContext context)
    {
        SetState(false);
    }

    void SetState(bool state)
    {
        directInteractor.enabled = !state;
        rayInteractor.enabled = state;
    }
}
