using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using UnityEditor.XR.LegacyInputHelpers;

public class VRBodySript : MonoBehaviour
{
    [Header("XR Toolkit Pars")]
    public XRRig XRRig;
    public GameObject XRCamera;

    [Header("Body Parts")]
    public GameObject Head;
    public GameObject Chest;
    public GameObject Fender;
    public GameObject MonoBall;
    
    // input values

    private Quaternion headYaw;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraToPlayer();
        XRRigToPlayer();
        getControllerImputValues();
    }

    private void FixedUpdate() 
    {
        rotatePlayer();
    }

    private void getControllerImputValues()
    {
        headYaw = Quaternion.Euler(0, XRRig.cameraGameObject.transform.eulerAngles.y, 0);
    }


    // Transform

    private void CameraToPlayer()
    {
        XRCamera.transform.position = Head.transform.position;
    }

    private void XRRigToPlayer()
    {
        XRRig.transform.position = new Vector3(Fender.transform.position.x, 
        Fender.transform.position.y - (0.5f * Fender.transform.localScale.y + 0.5f * 
        MonoBall.transform.localScale.y), Fender.transform.position.z);
    }

    private void rotatePlayer()
    {
        Chest.transform.rotation = headYaw;
    }
}
