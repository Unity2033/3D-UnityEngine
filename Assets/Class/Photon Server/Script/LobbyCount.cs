using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class LobbyCount : MonoBehaviour
{
    public int count;

    public void Selected()
    {
        switch (Data.count)
        {
            case 0 : Data.count = 0;
                break;
            case 1 : Data.count = 1;
                break;
            case 2 : Data.count = 2;
                break;
        }
    }
}
