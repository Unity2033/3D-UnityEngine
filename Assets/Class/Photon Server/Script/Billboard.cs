using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Billboard : MonoBehaviourPun
{
    public Text nickName;

    private void Start()
    {
        nickName.text = photonView.Owner.NickName;
    }

    void Update()
    {
        transform.forward = Camera.main.transform.forward;
    }
}
