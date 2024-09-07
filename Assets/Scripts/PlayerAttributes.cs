using Photon.Pun;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour, IPunObservable
{
    public PlayerStats playerStats;  // Local ScriptableObject for each player
    private PhotonTransformViewClassic photonTransformViewClassic;

    private void Awake()
    {
        photonTransformViewClassic = GetComponent<PhotonTransformViewClassic>();

    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
    }
}
