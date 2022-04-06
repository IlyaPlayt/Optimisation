using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBehaviour : MonoBehaviour, IUpdatable
{
    private Transform _player;
    private Vector3 _movementVector = new Vector3(0, 0, 0.05f);
    
    public void SetPlayer(Transform player)
    {
        _player = player;
    }

    public void Tick()
    {
        transform.LookAt(_player.position);
        transform.Translate(_movementVector);
    }
    
}