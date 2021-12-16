using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GeneratorScript : MonoBehaviourPunCallbacks
{
    public int cellsNeeded=1;
    public float moveInTime=4f;
    [SerializeField]
    private NetworkedGrabbing _NetworkGrabbing;

    public UnityEvent generatorStarted = new UnityEvent();

    GameObject hatch;

    [SerializeField] private bool _genUp = false;
    [SerializeField] private int _Gennumber;
    [SerializeField] private ExitGames.Client.Photon.Hashtable _GenProp = new ExitGames.Client.Photon.Hashtable();

    // Start is called before the first frame update
    void Start(){
        hatch=transform.Find("Hinge/Hatch").gameObject;
        hatch.GetComponent<HatchScript>().openHatch();

        _GenProp["genstatus" + _Gennumber] = _genUp;

    }

    public override void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable property)
    {
        if (property.ContainsKey("genstatus" + _Gennumber))
        {
            _genUp = (bool)PhotonNetwork.CurrentRoom.CustomProperties["genstatus" + _Gennumber];
            powerup();
        }
    }


    void OnCollisionEnter(Collision collision){
        if(cellsNeeded<=0) return;

        GameObject go=collision.gameObject;

        // check for full powercell
        if(go.tag.Equals("powercell")){
            if(go.GetComponent<powercell_script>().cellState==CellState.FULL){
                //go.GetComponent<NetworkedGrabbing>().P_isheld = false;
                takeCell(go);
            }
        }
    }

    GameObject currentCell;
    bool iscellTaken=false;

    void takeCell(GameObject powercell){
        if (powercell==currentCell) return;

        if(currentCell!=null){
            // destroy the cell
            Destroy(currentCell);
            currentCell=null;
        }
        
        currentCell=powercell;

        // remove from hands
        currentCell.transform.parent=null;

        // make ungrabbable
        var grabi = currentCell.GetComponent<UnityEngine.XR.Interaction.Toolkit.XRGrabInteractable>();
        grabi.interactionLayerMask=0; // make ungrabbable
        grabi.enabled=false;
        Destroy(grabi,0f);

        // make unmovable
        var networkgrab = currentCell.GetComponent<NetworkedGrabbing>();
        networkgrab.P_isheld = false;
        networkgrab.enabled = false;

        var rigi = currentCell.GetComponent<Rigidbody>();
        rigi.isKinematic=true;
        rigi.useGravity=false;
        rigi.freezeRotation=true;
        Destroy(rigi, 0f);

        // set relative to the generator
        currentCell.transform.parent=gameObject.transform;

        // Snap to position and rotation
        currentCell.transform.localPosition=new Vector3(0f,0.645f,-0.7f);
        currentCell.transform.localEulerAngles=new Vector3(-90f,0f,0f);

        iscellTaken=false;
        cellTaken();
    }

    // called when the powercell is fully inside the generator.
    void cellTaken(){
        
        iscellTaken =true;

        // if all the cells are inserted, start the generator.
        cellsNeeded--;

        // send generator activated signal.
        generatorStarted.Invoke();

        if (cellsNeeded<=0) powerup();  
    }


    void powerup(){
        // close opening hatch
        if(currentCell != null)
        {
            currentCell.SetActive(false);
        }

        hatch.GetComponent<HatchScript>().closeHatch();

        GetComponent<AudioSource>().Play();
    }

}