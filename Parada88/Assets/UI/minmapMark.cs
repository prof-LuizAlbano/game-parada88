using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followMain : MonoBehaviour
{
    [SerializeField] Transform player;


    void LateUpdate()
    {
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
    }
}
