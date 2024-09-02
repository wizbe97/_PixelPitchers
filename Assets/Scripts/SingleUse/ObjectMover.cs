using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class ObjectMover : MonoBehaviourPun
{
    [SerializeField] private float moveSpeed = 5f;
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (base.photonView.IsMine)
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            transform.position += new Vector3(x, y, 0) * moveSpeed;
        }
    }
}
