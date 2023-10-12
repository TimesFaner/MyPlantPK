using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cameraPoint;
    public Transform cameraTransform;
    void Start()
    {
        cameraTransform = cameraPoint.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=new Vector3( cameraTransform.position.x,cameraTransform.position.y,transform.position.z);
    }
}
