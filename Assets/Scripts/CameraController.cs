using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Vector3 offset;

    private float currentZoom;
    [SerializeField]
    private float minZoom = 0.5f;
    [SerializeField]
    private float maxZoom = 1f;
    [Range(0f, 1f)]
    public float speed = 0.2f;
    [SerializeField]
    private float angleSpeed = 40f;

    private float lookAngle;

    private void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * speed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
        lookAngle += Input.GetAxis("Horizontal") * Time.deltaTime * angleSpeed;
    }

    private void LateUpdate()
    {
        transform.position = target.position - offset * currentZoom;

        transform.LookAt(target);

        transform.RotateAround(target.position, Vector3.up, lookAngle);
    }
}
