using UnityEngine;
using Photon.Pun;

public class Striker : MonoBehaviour
{
    private Transform football;  // Assign the football in the Inspector or dynamically find it
    private PlayerAttributes playerAttributes;    // Reference to the PlayerAttributes component
    private PhotonView photonView;


    private void Start()
    {
        // Get the PlayerAttributes component attached to the striker
        playerAttributes = GetComponent<PlayerAttributes>();
        photonView = GetComponent<PhotonView>();

    }

    private void Update()
    {
        // Find the football if it hasn't been found yet
        if (football == null)
        {
            GameObject ballObject = GameObject.FindGameObjectWithTag("Ball");
            if (ballObject != null)
            {
                football = ballObject.transform;
            }
        }

        // If the football and playerAttributes are valid, move towards the football
        if (football != null && playerAttributes != null)
        {
            // Calculate direction towards the football
            Vector3 directionToFootball = (football.position - transform.position).normalized;
            if (photonView.IsMine)
            {
                // Move the striker towards the football based on the player's speed
                float speed = playerAttributes.playerStats.speed;
                transform.position += speed * Time.deltaTime * directionToFootball;
            }
        }
    }
}
