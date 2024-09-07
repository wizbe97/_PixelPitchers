using Photon.Pun;
using UnityEngine;
using System.Collections;

public class PlayerAttributes : MonoBehaviour, IPunObservable
{
    public PlayerStats playerStats;  // Assign the appropriate ScriptableObject in the Inspector
    public float radius = 10f;       // Radius for random movement in 2D space
    private Vector3 initialPosition; // Store the player's initial position
    private PhotonView photonView;   // Reference to the PhotonView component
    
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        initialPosition = transform.position;

        // Increase SendRate and SerializationRate for smoother updates
        PhotonNetwork.SendRate = 30;
        PhotonNetwork.SerializationRate = 15;

        // Only the MasterClient should control movement
        if (PhotonNetwork.IsMasterClient && photonView.IsMine)
        {
            StartCoroutine(MoveRandomlyWithinRadius());
        }
    }

    // Coroutine to move the player to random points within a circular radius in 2D space
    IEnumerator MoveRandomlyWithinRadius()
    {
        while (true)
        {
            // Generate a random point within a circle of the given radius in the X-Y plane (2D movement)
            Vector2 randomPoint = Random.insideUnitCircle * radius;
            Vector3 targetPosition = initialPosition + new Vector3(randomPoint.x, randomPoint.y, 0); // Use X and Y for 2D movement

            // Move towards the target position based on the player's speed stat
            while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, playerStats.speed * Time.deltaTime);
                yield return null;
            }

            // Wait for a brief period before selecting the next random point
            yield return new WaitForSeconds(1f);
        }
    }

    // Implement IPunObservable to synchronize custom data (not position, let PhotonTransformViewClassic handle that)
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // This client owns the object, send custom data (like speed) to others
            stream.SendNext(playerStats.speed); // Sync speed or other attributes as needed
        }
        else
        {
            // This client is receiving data, so receive and apply the custom data
            playerStats.speed = (int)stream.ReceiveNext(); // Sync speed or other attributes as needed
        }
    }

    void Update()
    {
        // The actual position synchronization is handled by PhotonTransformViewClassic.
    }
}
