using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class RandomCustomPropertyGenerator : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    private ExitGames.Client.Photon.Hashtable _myCustomProperties = new ExitGames.Client.Photon.Hashtable();

    private void SetCustomNumber()
    {  
        System.Random rnd = new System.Random();
        int result = rnd.Next(0, 99);

        _text.text = result.ToString();

        _myCustomProperties["RandomNumber"] = result;
        PhotonNetwork.SetPlayerCustomProperties(_myCustomProperties);
        // PhotonNetwork.LocalPlayer.CustomProperties = _myCustomProperties;

    }
    public void OnClick_Button()
    {
        SetCustomNumber();
    }
}
