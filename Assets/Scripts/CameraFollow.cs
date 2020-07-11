using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform mainShip;
    public Vector3 boundsMax;
    public Vector3 boundsMin;
    // Start is called before the first frame update
    void Start()
    {
        mainShip = GameObject.Find("fighter").transform;
        boundsMax = new Vector3(43.15f, 24.87f, -10.0f);
        boundsMin = new Vector3(-41.3f, -24.9f, -10.0f);   
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 camPos = transform.position;
        camPos.x = mainShip.position.x;
        camPos.y = mainShip.position.y;
        transform.position = camPos;
        transform.position = new Vector3 (
            Mathf.Clamp (transform.position.x, boundsMin.x, boundsMax.x), 
            Mathf.Clamp (transform.position.y, boundsMin.y, boundsMax.y), 
            Mathf.Clamp (transform.position.z, boundsMin.z, boundsMax.z)
        );
        //transform.position = camPos;   
    }
}
