using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraMovement : MonoBehaviour
{
    public GameObject targetObject;
    public float cameraFollowSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //smooth linear movement of camera using linear interpolation
        Vector3 cameraPos = Vector3.Lerp(this.transform.position, targetObject.transform.position, cameraFollowSpeed * Time.deltaTime);
        this.transform.position = cameraPos;
    }
}
