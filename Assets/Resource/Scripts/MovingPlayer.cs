using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlayer : MonoBehaviour
{
    private Rigidbody _rb;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        InputManager.Moving += MoveBody;
        InputManager.Rotate += RotateBody;
    }

    private void MoveBody(float speed) =>  _rb.velocity = Vector3.forward * speed;

    private void RotateBody(float speed)
    {
        _rb.transform.Rotate(new Vector3(0, _rb.rotation.y + speed, 0));
    }
}
