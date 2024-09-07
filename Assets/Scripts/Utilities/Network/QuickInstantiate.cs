using Photon.Pun;
using UnityEngine;

public class QuickInstantiate : MonoBehaviour
{
    [SerializeField] private GameObject _prefabToInstantiate;

    private void Awake()
    {
        // Only instantiate on the MasterClient
        if (PhotonNetwork.IsMasterClient)
        {
            // Master client instantiates the object
            MasterManager.NetworkInstantiate(_prefabToInstantiate, transform.position, Quaternion.identity);
        }
    }
}
