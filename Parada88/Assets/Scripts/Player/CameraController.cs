// ---------------------------------------------
// ---------------------------------------------
// Creation Date: 2023-11-19
// Author: Testes Parada88 
// Project Name: junio 
// Description: 
// 
// ---------------------------------------------
// ---------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] 
    Transform followTarget;

    [SerializeField] 
    float rotationSpeed = 2f;

    [SerializeField] 
    float distance = 5f;

    [SerializeField] 
    float minVerticalAngle = 0f;

    [SerializeField]
    float maxVerticalAngle = 65f;

    [SerializeField]
    Vector2 framingOffset = new Vector2(0, 3);

    [SerializeField] 
    bool invertX;

    [SerializeField] 
    bool invertY;

    float rotationX;
    float rotationY;

    float invertXVal;
    float invertYVal;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
 
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        invertXVal = (invertX) ? -1 : 1;
        invertYVal = (invertY) ? -1 : 1;

        rotationX += invertXVal * Input.GetAxis("Mouse Y") * invertYVal * rotationSpeed;
        rotationX = Mathf.Clamp(rotationX, minVerticalAngle, maxVerticalAngle);
        
        rotationY += Input.GetAxis("Mouse X") * invertXVal * rotationSpeed;

        var targetRotation = Quaternion.Euler(rotationX, rotationY, 0);

        var focusPosition = followTarget.position + new Vector3(framingOffset.x, framingOffset.y);

        transform.position = focusPosition - ( targetRotation * new Vector3(0, 0 , distance) );
        transform.rotation = targetRotation;
    }

    public Quaternion PlanarRotation => Quaternion.Euler(0, rotationY, 0);

}

