using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDistanceFrom : MonoBehaviour
{
    /*  This script gets the distance between two 
     *  objects using the cartesian distance formula
     *  
     *  Public methods:
     *  - void calDist() : calculates and updates distance between objects
     *  - void updateVectors() : updates teh current position of the vectors
     *  - float getDistance() : accessor for distance between two objects
     */
    [SerializeField] public GameObject ObjectDistanceTo;//object to get distance from current object to
    private Vector3 to;
    private Vector3 from;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

     public void calcDist()
    {
        distance = Mathf.Sqrt(Mathf.Pow(2, (to.x - from.x)) + Mathf.Pow(2, (to.y - from.y)) + Mathf.Pow(2, to.z - from.z));
    }

    public void updateVectors()
    {
        to = gameObject.transform.position;
        from = ObjectDistanceTo.transform.position;
    }

    public float getDistance() { return distance; }
}
