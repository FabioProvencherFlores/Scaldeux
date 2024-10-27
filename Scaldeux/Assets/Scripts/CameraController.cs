using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    GameObject targetObject;

    Transform _cameraTransform;

    private void Awake()
    {
        _cameraTransform = gameObject.transform;
    }

    void Update()
    {
        Vector3 newPos = new Vector3(targetObject.transform.position.x, targetObject.transform.position.y, _cameraTransform.position.z);
        _cameraTransform.position = newPos;
    }
}
