using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class LoadGame : MonoBehaviour
{
    public void OnClick_LoadGame()
    {
        PhotonNetwork.LoadLevel(2);
    }
}
