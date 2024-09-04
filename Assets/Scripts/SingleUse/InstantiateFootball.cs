using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateFootball : MonoBehaviour
{
    [SerializeField] private GameObject _footballPrefab;

    private void Awake() {
        MasterManager.NetworkInstantiate(_footballPrefab, transform.position, Quaternion.identity);
    }
}
