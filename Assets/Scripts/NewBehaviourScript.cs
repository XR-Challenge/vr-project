using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class NewBehaviourScript : XRBaseInteractable
{
    // Start is called before the first frame update
    void Start()
    {
    }



    void OnSelectEnter(XRBaseInteractor interactor)
    {
        Debug.Log("ENTER");
    }

    void OnSelectExit(XRBaseInteractor interactor)
    {
        Debug.Log("EXIT");
    }
}
