using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Interactions;

public class ChargingPortScript : MonoBehaviour
{
    void OnCollisionEnter(Collision collision){

        GameObject go=collision.gameObject;

        // if it is an empty powercell and we are not already charging another one, put it in the right position and charge it.
        if(go.tag.Equals("powercell") && !isCharging()){
            if(go.GetComponent<powercell_script>().cellState==CellState.EMPTY){
                chargeCell(go);
            }
        }
    }

    // reference to the cell we are charging...
    GameObject cell;

    void chargeCell(GameObject go){
        cell=go;

        // make ungrabbable
        var networked = go.GetComponent<NetworkedGrabbing>().P_isheld = false;

        var grabi= go.GetComponent<UnityEngine.XR.Interaction.Toolkit.XRGrabInteractable>();
        grabi.interactionLayerMask=0; // make ungrabbable
        if(grabi.selectingInteractor!=null) grabi.selectingInteractor.EndManualInteraction(); // drop if grabbed
        go.transform.parent=null;
        grabi.enabled=false;

        // make unmovable
        var rigi = go.GetComponent<Rigidbody>();
        rigi.isKinematic=true;
        rigi.useGravity=false;
        rigi.constraints = RigidbodyConstraints.FreezeAll;

        // Snap to position
        go.transform.SetPositionAndRotation(this.transform.position,this.transform.rotation);
        go.GetComponent<powercell_script>().switchState(CellState.CHARGING);
    }

    // returns true if this charging point is charging a cell.
    // otherwise returns false;
    public bool isCharging(){
        if(cell==null ) return false;

        // return true if we have a cell that is charging...
        powercell_script script=cell.GetComponent<powercell_script>();
        if(script!=null && script.cellState==CellState.CHARGING) return true;
        else cell = null; // or if we are done, set cell to null;

        return false;
    }

}
