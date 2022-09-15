using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public delegate void Move(float speed);

    public delegate void Fire();
    public static event Move Moving;
    public static event Move Rotate;
    public static event Move Jump;
    public static event Move EnableMoving;
    public static event Fire FireBullet;

    [SerializeField] private float speedMove;
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
        if (Input.GetKey(KeyCode.A)) Rotate?.Invoke(speedMove);
        
        if (Input.GetKey(KeyCode.D)) Rotate?.Invoke(-speedMove);
        
        if (Input.GetKey(KeyCode.Space)) Jump?.Invoke(forcejump);
        
        if(Input.GetKey(KeyCode.Return)) EnableMoving?.Invoke(0);
        
        if(Input.GetKey(KeyCode.Mouse0)) EnableMoving?.Invoke(1);
        
        if(Input.GetKey(KeyCode.Q)) FireBullet?.Invoke();
    }
}
