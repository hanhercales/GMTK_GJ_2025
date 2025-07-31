using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotaion : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float currenYaw = 0f;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxis("Mouse X");
            currenYaw += mouseX * rotationSpeed;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, currenYaw, transform.rotation.eulerAngles.z);
        }
    }
}
