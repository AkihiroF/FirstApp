using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCamera : MonoBehaviour
{
    [SerializeField] private GameObject playerGameObject;
    [SerializeField] private float smooth;
    [SerializeField] private float distance;
    [SerializeField] private float sens;

    private float _rotX;
    private float _rotY;
    private Transform _player;


    private void Start()
    {
        _player = playerGameObject.transform;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        _rotX -= Input.GetAxis("Mouse Y") * sens;
        _rotY += Input.GetAxis("Mouse X") * sens;

        _rotX = Math.Clamp(_rotX, -9, 45);
        var endrot = new  Vector3(_rotX, _rotY, 0);
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, endrot, Time.time * smooth);
        transform. position = Vector3.Lerp(transform.position, _player.position - transform.forward * distance, Time.time * smooth);

        if (!Input.GetKey(KeyCode.X))
        {
            var endrotPlayer = new Vector3(0, transform.eulerAngles.y, 0);
            _player.eulerAngles = Vector3.Lerp(_player.eulerAngles, endrotPlayer, Time.time * smooth);
        }
    }
}
