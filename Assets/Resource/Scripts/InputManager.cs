using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public delegate void Move(float speed);
    public static event Move Moving;
    public static event Move Rotate;
    public static event Move Jump;
    
    [SerializeField] private float speedMove;
    [SerializeField] private float speedRorate;
    [SerializeField] private float forcejump;
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Moving?.Invoke(speedMove);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Moving?.Invoke(-speedMove);
        }
        if (Input.GetKey(KeyCode.A)) Rotate?.Invoke(speedRorate);
        if (Input.GetKey(KeyCode.D)) Rotate?.Invoke(-speedRorate);
        if (Input.GetKey(KeyCode.Space)) Jump?.Invoke(forcejump);
    }
}
