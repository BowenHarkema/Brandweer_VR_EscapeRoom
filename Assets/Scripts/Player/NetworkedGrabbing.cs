using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkedGrabbing : MonoBehaviourPunCallbacks, IPunOwnershipCallbacks
{
    private PhotonView PhotonView;
    private Rigidbody Rigidbody;
    public bool isheld = false;
    // Start is called before the first frame update
    private void Awake()
    {
        PhotonView = GetComponent<PhotonView>();
    }
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.tag != "Lever") { 
        if (isheld)
        {
            Rigidbody.isKinematic = true;
            gameObject.layer = 12;
        }
        else
        {
            Rigidbody.isKinematic = false;
            gameObject.layer = 8;
        }
        }
    }
    private void TransferOwnership()
    {
     PhotonView.RequestOwnership();
    }
    public void OnSelectEnter()
    {
        TransferOwnership();
        photonView.RPC("StartNetworkedGrabbing",RpcTarget.AllBuffered);
        if(photonView.Owner == PhotonNetwork.LocalPlayer)
        {
            Debug.Log("object is already mine");
        }
        else
        {
            TransferOwnership();
        }
    }
    public void OnSelectExit()
    {
        TransferOwnership();
        photonView.RPC("StopNetworkedGrabbing", RpcTarget.AllBuffered);
    }

    public void OnOwnershipRequest(PhotonView targetView, Player requestingPlayer)
    {
       Debug.Log("ONownership request for" + targetView.name + "from" + requestingPlayer.NickName);
        photonView.TransferOwnership(requestingPlayer);
    }

    public void OnOwnershipTransfered(PhotonView targetView, Player previousOwner)
    {
      Debug.Log("ONownershiptransfer request for" + targetView.name + "from" + previousOwner.NickName);

    }
    [PunRPC]
    public void StartNetworkedGrabbing()
    {
        isheld = true;
    }

    [PunRPC]
    public void StopNetworkedGrabbing()
    {
        isheld = false;
    }
}
