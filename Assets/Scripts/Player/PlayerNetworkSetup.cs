using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;
using System;
public class PlayerNetworkSetup : MonoBehaviourPunCallbacks
{
    public GameObject localXRig;

    public GameObject avatarHead;
    public GameObject avatarBody;
    public GameObject avatarHair;
    // Start is called before the first frame update

    private Color[] _Colors = { Color.blue, Color.black, Color.yellow, Color.red, Color.green };
    private int[] _OwnerActorNrs = new int[4];
    private static int _ArrayCounter;
    void Start()
    {
        if (photonView.IsMine)
        {
            localXRig.SetActive(true);
            gameObject.GetComponent<AvatarInputConverter>().enabled = true;

            _OwnerActorNrs[_ArrayCounter] = photonView.OwnerActorNr;
            _ArrayCounter++;

            avatarHair.GetComponent<MeshRenderer>().material.color = _Colors[Array.FindIndex(_OwnerActorNrs, x => x == photonView.OwnerActorNr)];

            SetLayerRecursively(avatarHead,10);
            SetLayerRecursively(avatarBody,11);

            TeleportationArea[] teleportationAreas = GameObject.FindObjectsOfType<TeleportationArea>();
            if(teleportationAreas.Length > 0)
            {
                Debug.Log("found" + teleportationAreas.Length + "teleportation area");
                foreach(var item in teleportationAreas)
                {
                    item.teleportationProvider = localXRig.GetComponent<TeleportationProvider>();
                }
            }
        }
        else
        {
            localXRig.SetActive(false);
            gameObject.GetComponent<AvatarInputConverter>().enabled = false;

            //sets the colour of the player head/hair
            _OwnerActorNrs[_ArrayCounter] = photonView.OwnerActorNr;
            _ArrayCounter++;

            avatarHair.GetComponent<MeshRenderer>().material.color = _Colors[Array.FindIndex(_OwnerActorNrs, x => x == photonView.OwnerActorNr)];

            SetLayerRecursively(avatarHead, 0);
            SetLayerRecursively(avatarBody, 0);
        }
    }
    void SetLayerRecursively(GameObject go, int layerNumber)
    {
        if (go == null) return;
        foreach (Transform trans in go.GetComponentsInChildren<Transform>(true))
        {
            trans.gameObject.layer = layerNumber;
        }
    }
}
