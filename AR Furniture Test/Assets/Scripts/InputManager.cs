using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Camera arCam;
    [SerializeField] private ARRaycastManager _raycastManager;
    [SerializeField] private GameObject arObj;

    private List<ARRaycastHit> _hits = new List<ARRaycastHit>();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = arCam.ScreenPointToRay(Input.mousePosition);
            if (_raycastManager.Raycast(ray, _hits))
            {
                Pose pose = _hits[0].pose;
                Instantiate(arObj, pose.position, pose.rotation);
            }
        }
    }
}