using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class LeaveRoomMenu : MonoBehaviour
{
    private RoomsCanvases _roomsCanvases;
    public void FirstInitialise(RoomsCanvases canvases)
    {
        _roomsCanvases = canvases;
    }
    public void OnClick_LeaveRoom()
    {
        PhotonNetwork.LeaveRoom(true);
        _roomsCanvases.CurrentRoomCanvas.Hide();
    }
}
