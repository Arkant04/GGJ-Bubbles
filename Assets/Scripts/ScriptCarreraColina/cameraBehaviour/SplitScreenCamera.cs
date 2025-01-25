using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitScreenCamera : MonoBehaviour
{
    [Header("Players Transform")]
    [SerializeField] Transform Player1Tr;
    [SerializeField] Transform Player2Tr;

    [Header("Camera Settings")]
    [SerializeField] float followPlayerSmooth;
    [SerializeField] float lookAheadDistance;
    [SerializeField] float upDistance;
    [SerializeField] Vector3 offset = new Vector3(0f, 0f, -10f);

    private Camera cam1;
    private Camera cam2;
    private Vector3 currentVelocity1;
    private Vector3 currentVelocity2;

    void Start()
    {
        
        GameObject cam1Obj = new GameObject("Player1Camera");
        cam1 = cam1Obj.AddComponent<Camera>();
        cam1.rect = new Rect(0, 0, 0.5f, 1);

        GameObject cam2Obj = new GameObject("Player2Camera");
        cam2 = cam2Obj.AddComponent<Camera>();
        cam2.rect = new Rect(0.5f, 0, 0.5f, 1); 
    }

    void Update()
    {
        cam1.transform.position = Vector3.SmoothDamp(
            cam1.transform.position,
            Player1Tr.position + offset + Vector3.up * upDistance,
            ref currentVelocity1,
            followPlayerSmooth
        );
        cam1.transform.LookAt(Player1Tr.position + Player1Tr.forward * lookAheadDistance);

        cam2.transform.position = Vector3.SmoothDamp(
            cam2.transform.position,
            Player2Tr.position + offset + Vector3.up * upDistance,
            ref currentVelocity2,
            followPlayerSmooth
        );
        cam2.transform.LookAt(Player2Tr.position + Player2Tr.forward * lookAheadDistance);
    }
}
