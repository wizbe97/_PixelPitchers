using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickInstantiate : MonoBehaviour
{
    [SerializeField] private GameObject _prefabToInstantiate;

    private void Awake()
    {
        MasterManager.NetworkInstantiate(_prefabToInstantiate, transform.position, Quaternion.identity);
    }
}
