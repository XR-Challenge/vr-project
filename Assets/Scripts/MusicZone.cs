using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicZone : MonoBehaviour
{
    public MusicController controller;
    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            controller.SetInZone(true);
        }
    }
    void OnTriggerExit(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            controller.SetInZone(false);
        }
    }

}
