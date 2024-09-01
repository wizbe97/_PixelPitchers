using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerStats", menuName = "ScriptableObjects/PlayerStats", order = 1)]
public class PlayerStats : ScriptableObject
{
    public enum PlayerPosition
    {
        Defender,
        Attacker,
        GoalKeeper
    }

    [Header("Player Information")]
    public PlayerPosition playerPosition;

    [Header("Attributes")]
    [Range(0, 9)] public int stamina;
    [Range(0, 9)] public int speed;
    [Range(0, 9)] public int strength;
    [Range(0, 9)] public int accuracy;
    [Range(0, 9)] public int shotPower;

    [Header("Points")]
    public int pointsRemaining = 100; // Each player starts with 100 points
}
