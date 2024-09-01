using UnityEngine;
using TMPro;

public class PlayerStatManager : MonoBehaviour
{
    public TMP_Dropdown playerDropdown; // Assign your TMP dropdown UI component here
    public TMP_Text speedText, staminaText, strengthText, accuracyText, shotPowerText; // Assign your TMP Text components here
    public TMP_Text remainingPointsText; // Assign the TMP_Text for remaining points here
    public PlayerStats[] players; // Array of player stats (set this up in the Inspector)

    private PlayerStats currentPlayer;
    private int maxStatValue = 9; // The maximum value a stat can have

    void Start()
    {
        // Populate the dropdown with player names
        playerDropdown.ClearOptions(); // Clears any existing options in the dropdown
        foreach (PlayerStats player in players)
        {
            playerDropdown.options.Add(new TMP_Dropdown.OptionData(player.name));
        }

        // Force the dropdown to refresh its display by setting its value programmatically
        playerDropdown.value = 0;  // Set to the first player (this line might be optional)
        playerDropdown.RefreshShownValue();  // This ensures the dropdown refreshes correctly

        playerDropdown.onValueChanged.AddListener(delegate { OnPlayerSelected(playerDropdown.value); });

        // Initialize with the first player selected
        OnPlayerSelected(0); // Set the first player as the selected player by default
    }

    void OnPlayerSelected(int index)
    {
        currentPlayer = players[index];
        UpdateStatDisplay();
    }

    public void IncreaseStat(string statName)
    {
        int cost = 0;
        switch (statName)
        {
            case "Speed":
                cost = currentPlayer.speed + 1; // Next level cost
                if (currentPlayer.pointsRemaining >= cost && currentPlayer.speed < maxStatValue)
                {
                    currentPlayer.speed++;
                    currentPlayer.pointsRemaining -= cost;
                }
                break;
            case "Stamina":
                cost = currentPlayer.stamina + 1;
                if (currentPlayer.pointsRemaining >= cost && currentPlayer.stamina < maxStatValue)
                {
                    currentPlayer.stamina++;
                    currentPlayer.pointsRemaining -= cost;
                }
                break;
            case "Strength":
                cost = currentPlayer.strength + 1;
                if (currentPlayer.pointsRemaining >= cost && currentPlayer.strength < maxStatValue)
                {
                    currentPlayer.strength++;
                    currentPlayer.pointsRemaining -= cost;
                }
                break;
            case "Accuracy":
                cost = currentPlayer.accuracy + 1;
                if (currentPlayer.pointsRemaining >= cost && currentPlayer.accuracy < maxStatValue)
                {
                    currentPlayer.accuracy++;
                    currentPlayer.pointsRemaining -= cost;
                }
                break;
            case "ShotPower":
                cost = currentPlayer.shotPower + 1;
                if (currentPlayer.pointsRemaining >= cost && currentPlayer.shotPower < maxStatValue)
                {
                    currentPlayer.shotPower++;
                    currentPlayer.pointsRemaining -= cost;
                }
                break;
        }
        UpdateStatDisplay();
    }

    public void DecreaseStat(string statName)
    {
        int refund = 0;
        switch (statName)
        {
            case "Speed":
                if (currentPlayer.speed > 0)
                {
                    refund = currentPlayer.speed;
                    currentPlayer.speed--;
                    currentPlayer.pointsRemaining += refund;
                }
                break;
            case "Stamina":
                if (currentPlayer.stamina > 0)
                {
                    refund = currentPlayer.stamina;
                    currentPlayer.stamina--;
                    currentPlayer.pointsRemaining += refund;
                }
                break;
            case "Strength":
                if (currentPlayer.strength > 0)
                {
                    refund = currentPlayer.strength;
                    currentPlayer.strength--;
                    currentPlayer.pointsRemaining += refund;
                }
                break;
            case "Accuracy":
                if (currentPlayer.accuracy > 0)
                {
                    refund = currentPlayer.accuracy;
                    currentPlayer.accuracy--;
                    currentPlayer.pointsRemaining += refund;
                }
                break;
            case "ShotPower":
                if (currentPlayer.shotPower > 0)
                {
                    refund = currentPlayer.shotPower;
                    currentPlayer.shotPower--;
                    currentPlayer.pointsRemaining += refund;
                }
                break;
        }
        UpdateStatDisplay();
    }

    void UpdateStatDisplay()
    {
        // Update the stat text fields
        speedText.text = currentPlayer.speed.ToString();
        staminaText.text = currentPlayer.stamina.ToString();
        strengthText.text = currentPlayer.strength.ToString();
        accuracyText.text = currentPlayer.accuracy.ToString();
        shotPowerText.text = currentPlayer.shotPower.ToString();

        // Update the remaining points display
        remainingPointsText.text = "Points: " + currentPlayer.pointsRemaining.ToString();
    }
}
