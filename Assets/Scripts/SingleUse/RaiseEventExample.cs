using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class RaiseEventExample : MonoBehaviourPun
{
    private SpriteRenderer _spriteRenderer;
    private const byte CHANGE_COLOR_EVENT = 1;
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && base.photonView.IsMine)
        {
            ChangeColor();
        }
    }

    private void OnEnable()
    {
        PhotonNetwork.NetworkingClient.EventReceived += NetworkingClient_EventReceived;
    }

    private void OnDisable()
    {
        PhotonNetwork.NetworkingClient.EventReceived -= NetworkingClient_EventReceived;
    }

    private void NetworkingClient_EventReceived(EventData obj) {
        if (obj.Code == CHANGE_COLOR_EVENT)
        {
            object[] datas = (object[])obj.CustomData;
            float r = (float)datas[0];
            float g = (float)datas[1];
            float b = (float)datas[2];
            _spriteRenderer.color = new Color(r, g, b, 1f);
        }
    }

    private void ChangeColor()
    {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);

        _spriteRenderer.color = new Color(r, g, b, 1f);

        object[] datas = new object[] { r, g, b };
        PhotonNetwork.RaiseEvent(CHANGE_COLOR_EVENT, datas, RaiseEventOptions.Default, SendOptions.SendUnreliable);
    }


}
