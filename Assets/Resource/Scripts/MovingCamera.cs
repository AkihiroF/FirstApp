using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCamera : MonoBehaviour
{
    [SerializeField] private GameObject playerGameObject;
    [SerializeField] private float smooth;
    [SerializeField] private float distance;
    [SerializeField] private float updistance;

    private Transform _player;

    private void Start()
    {
        _player = playerGameObject.transform;
    }

    void Update()
    {
        var playerPos = _player.position;
        var pos = new Vector3(playerPos.x, playerPos.y+updistance, playerPos.z - distance);
        transform.position = Vector3.Lerp(transform.position, pos, smooth);
        transform.LookAt(_player);
    }
}
