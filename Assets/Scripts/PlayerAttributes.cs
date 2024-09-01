using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    public PlayerStats playerStats; // Assign the appropriate ScriptableObject in the Inspector

    void Start()
    {
        // You can use this to confirm the correct ScriptableObject is assigned
        Debug.Log("Player initialized with position: " + playerStats.playerPosition);
        Debug.Log("Initial stats: ");
        Debug.Log("Stamina: " + playerStats.stamina);
        Debug.Log("Speed: " + playerStats.speed);
        Debug.Log("Strength: " + playerStats.strength);
        Debug.Log("Accuracy: " + playerStats.accuracy);
        Debug.Log("Shot Power: " + playerStats.shotPower);
    }

    // Optionally, you could add methods here to interact with the stats if needed.
}
