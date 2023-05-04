using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public float[] Position;
    public int Energy;
    public float JumpForce;
    public float Speed;
    public float DashForce;
    public float[] Checkpoint;
    public float LightPower;

    public GameData(GameObject player)
    {
        var positionVector = player.transform.position;
        Position = new[] { positionVector.x, positionVector.y, positionVector.z };
        var playerStats = player.GetComponent<PlayerStats>();
        Energy = playerStats.Energy;
        JumpForce = playerStats.JumpForce;
        Speed = playerStats.Speed;
        DashForce = playerStats.DashForce;
        var checkpointVector = playerStats.Checkpoint;
        Checkpoint = new[] { checkpointVector.x, checkpointVector.y };
        LightPower = playerStats.LightPower;
    }
}
