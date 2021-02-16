using System;
using UnityEngine;

internal class PlayerCamera : MonoBehaviour
{
    [SerializeField] private float _sensVert = 9;
    [SerializeField] private float _maxAngle = 45;
    [SerializeField] private float _minAngle = -45;
    private float _rotationX;
    
    private void Update()
    {
        _rotationX -= Input.GetAxis("Mouse Y") * _sensVert;
        _rotationX = Mathf.Clamp(_rotationX, _minAngle, _maxAngle);
        transform.localEulerAngles = new Vector3(_rotationX, 0, 0);
    }
}
