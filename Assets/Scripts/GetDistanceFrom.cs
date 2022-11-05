using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDistanceFrom : MonoBehaviour
{
    /*  This script gets the distance between two 
     *  objects using the cartesian distance formula
     *  
     *  to -> current object this script is applied to
     *  from -> serializedField GameObject
     *  
     *  Methods:
     *  - void calDist() : calculates and updates distance between objects
     *  - void updateVectors() : updates teh current position of the vectors
     *  - float getDistance() : accessor for distance between two objects
     *  ~ use these two methods to save on runtime if you know an object is static
     *  - updateToVector() : updates to vector only
     *  - updateFromVector() : updates from vector only
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

    /*** Update Vectors ***/

    public void updateVectors()
    {
        to = ObjectDistanceTo.transform.position;
        from =  gameObject.transform.position;
    }

    public void updateToVector()
    {
        to = ObjectDistanceTo.transform.position;
    }

    public void updateFromVector() {
        from = gameObject.transform.position;
    }

    /*** data access/calculations ***/
    public void calcDist()
    {
        distance = Vector3.Distance(to, from);
    }

    public float getDistance() { return distance; }

    /*** Tests/debug ***/

    public void debugDist() {
        Debug.Log(getDistance());
    }
}
