using System;
using UnityEngine;


public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int _energy;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _dashForce;
    [SerializeField] private Vector2 _checkpoint;
    [SerializeField] private float _lightPower;

    public int Energy
    {
        get { return _energy; }
        set 
        {
            if (value < 0)
                throw new ArgumentException();
            _energy = value; 
        }
    }

    public float JumpForce
    {
        get { return _jumpForce; }
    }

    public float Speed
    {
        get { return _speed; }
    }

    public float DashForce
    {
        get { return _dashForce; }
    }

    public Vector2 Checkpoint
    {
        get { return _checkpoint; }
        set { _checkpoint = value; }
    }

    public float LightPower
    {
        get { return _lightPower; }
        set { _lightPower = value; }
    }
}
