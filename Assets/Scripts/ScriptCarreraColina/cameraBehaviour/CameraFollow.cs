using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform PlayerTr;
    [SerializeField] float followPlayerSmooth;
    [SerializeField] float lookAheadDistance;
    [SerializeField] float lookAheadSmooth;
    [SerializeField] float rotationSmooth;
    [SerializeField] float minDistanceToPlayer;
    [SerializeField] float upDistance;
    [SerializeField] Vector3 offset = new Vector3(0f, 0f, -10f);
    [SerializeField] Vector3 currenteVelocity;
    void Start()
    {

    }

    void Update()
    {
        transform.position = Vector3.SmoothDamp(
            transform.localPosition,
            PlayerTr.position + PlayerTr.forward * offset.z + PlayerTr.up * upDistance,
            ref currenteVelocity,
            followPlayerSmooth
        );
        transform.LookAt(PlayerTr.position + PlayerTr.forward * lookAheadDistance);
        //transform.rotation = Quaternion.AngleAxis(Input.GetAxis("Horizontal") * rotationSmooth, Vector3.up) * offset;
    }
}


