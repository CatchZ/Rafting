using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.PackageManager.UI;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;
public class FollowPlayer : MonoBehaviour
{

public GameObject player;
    public float distanceBehind = 20.0f;
    public float heightAbove = 10.0f;
    public float smoothTime = 0.3f;


    private Vector3 cameraVelocity = Vector3.zero;

    void Start()
    {

    }

    void LateUpdate()
    {
        // Calculate the desired position for the camera
        Vector3 targetPosition = player.transform.position - player.transform.forward * distanceBehind + Vector3.up * heightAbove;
        Vector3 newPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref cameraVelocity, smoothTime);

        // Set the camera's position to the desired position
        transform.position = newPosition;

        // Make the camera always face towards the player
        transform.LookAt(player.transform);
        
    }
}
