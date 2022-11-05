using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ClimbingInteractable : XRBaseInteractable
{
    protected override void OnSelectEntering(XRBaseInteractor interactor)
    {
        base.OnSelectEntering(interactor);
        Debug.Log("SELECT ENTER");
    }

    protected override void OnSelectExiting(XRBaseInteractor interactor)
    {
        base.OnSelectExiting(interactor);
        Debug.Log("SELECT EXIT");
    }
}
