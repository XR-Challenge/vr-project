using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TreeGenerator : MonoBehaviour
{
    public GameObject leaf;
    public XRInteractionManager interactionManager;
    public int branchesPerLayer = 3;
    public int layers = 25;
    public float startHeight = 0.5f;
    public float angleIncrement = 30.0f;
    public float startScale = 1f;
    public float endScale = 0.1f;
    public float startXAngle = -30;
    public float endXAngle = 30;
    // Start is called before the first frame update
    void Start()
    {
        float height = 25f * transform.localScale.y;
        for (int i = 0; i < layers; i++)
        {
            float y = startHeight + i * (height - startHeight) / layers;
            float alpha = (float)i / (layers - 1f);
            float scale = startScale * (1f - alpha) + endScale * alpha;
            float angle = angleIncrement * i;
            float xAngle = startXAngle * (1f - alpha) + endXAngle * alpha;
            for (int j = 0; j < branchesPerLayer; j++) {
                float angleOffset = j * 360f / branchesPerLayer;
                GameObject l = Instantiate(leaf, new Vector3(0, y, 0f) + transform.position, Quaternion.Euler(xAngle, angle + angleOffset, 0f));
                l.GetComponent<XRGrabInteractable>().interactionManager = interactionManager;
                l.transform.localScale = new Vector3(scale, scale, scale);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
