using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int _energy;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _dashForce;
    [SerializeField] private Vector2 _checkpoint;
    [SerializeField] private float _lightPower;
    [SerializeField] private Light2D _light;
    [SerializeField] private bool _inDialogue;
    [SerializeField] private bool _hasDash;
    [SerializeField] private int _skyeyFireflyProgress;
    [SerializeField] private int _sunCrystalProgress;
    [SerializeField] private bool _nearCrystal;

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

    public bool InDialogue
    {
        get => _inDialogue;
        set => _inDialogue = value;
    }

    public bool HasDash
    {
        get => _hasDash;
        set => _hasDash = value;
    }

    public int SkyeyFireflyProgress
    {
        get => _skyeyFireflyProgress;
        set => _skyeyFireflyProgress = value;
    }

    public int SunCrystalProgress
    {
        get => _sunCrystalProgress;
        set
        {
            _sunCrystalProgress = value;
            if (value == 1)
            {
                _light.color = new Color(0.981f, 0.926f, 0.504f);
                return;
            }
            _light.color = Color.white;
        }
    }

    public void LoadPlayer(GameData save)
    {
        transform.position = new Vector3(save.PlayerPosition[0], save.PlayerPosition[1], save.PlayerPosition[2]);
        _energy = save.Energy;
        _jumpForce = save.JumpForce;
        _speed = save.Speed;
        _dashForce = save.DashForce;
        _checkpoint = new Vector2(save.Checkpoint[0], save.Checkpoint[1]);
        _lightPower = save.LightPower;
        _hasDash = save.HasDash;
        _skyeyFireflyProgress = save.SkyeyFireflyProgress;
        SunCrystalProgress = save.SunCrystalProgress;
    }

    public bool NearCrystal
    {
        get => _nearCrystal;
        set => _nearCrystal = value;
    }
}
