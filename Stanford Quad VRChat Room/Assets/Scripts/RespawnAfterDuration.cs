
using System;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class RespawnAfterDuration : UdonSharpBehaviour
{
    public float Duration = 10.0f;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private bool canRespawn = false;
    private float timeOfLastDrop = 0.0f;
    private Rigidbody rb;

    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    public override void OnPickup()
    {
        canRespawn = false;
        rb.isKinematic = false;
    }

    public override void OnDrop()
    {
        timeOfLastDrop = Time.time;
        canRespawn = true;
        rb.isKinematic = false;
    }

    private void Update()
    {
        if (canRespawn && Time.time - timeOfLastDrop > Duration)
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        canRespawn = false;
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = initialPosition;
        transform.rotation = initialRotation;
    }
}
