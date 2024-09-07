using Photon.Pun;
using UnityEngine;

public class TeamInstantiate : MonoBehaviour
{
    [SerializeField] private GameObject _teamPrefab;
    [SerializeField] private GameObject _footballPrefab;

    private void Awake()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            MasterManager.NetworkInstantiate(_footballPrefab, transform.position, Quaternion.identity);
            // Master client instantiates with default rotation
            MasterManager.NetworkInstantiate(_teamPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            // Non-master client instantiates with 180 degrees rotation on X and Z axes
            Quaternion spawnRotation = Quaternion.Euler(180, 0, 180);
            MasterManager.NetworkInstantiate(_teamPrefab, transform.position, spawnRotation);
        }
    }
}
