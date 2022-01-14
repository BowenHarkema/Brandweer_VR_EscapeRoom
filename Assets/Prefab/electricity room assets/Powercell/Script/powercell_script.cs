using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powercell_script : MonoBehaviour
{
    // charge indicator object and chargespeed variable
    public GameObject chargeObject;
    public float chargeSpeed = 0.1f;

    public CellState cellState = CellState.FULL;


    // the current charge value.
    private float charge = 0f;
    private float chargeh = 0f;
    
    private const float EMPTYCHARGE=16.2147f;
    private const float FULLCHARGE=87.2531f;

    

    // Start is called before the first frame update
    void Start()
    {
        // set charge to correct base value.
        switchState(cellState);
    }

    public void switchState(CellState state){
        cellState=state;

        switch(cellState){
            case(CellState.EMPTY):
                chargeh=EMPTYCHARGE;
                setScaleY(chargeh);

            break;

            case(CellState.CHARGING):
                chargeh+= Time.deltaTime * chargeSpeed;
                setScaleY(chargeh);

            break;

            default:
            case(CellState.FULL):
                chargeh=FULLCHARGE;
                setScaleY(chargeh);

                // re-enable grabbability
                var grabi= GetComponent<UnityEngine.XR.Interaction.Toolkit.XRGrabInteractable>();
                grabi.enabled=true;
                grabi.interactionLayerMask = LayerMask.GetMask("Interactable");

                // when cell is full, re-enable movement that was disabled by charger for the charging process.
                var rigi = GetComponent<Rigidbody>();
                rigi.isKinematic=false;
                rigi.useGravity=true;

                rigi.constraints = RigidbodyConstraints.None;

            break;
        }
    }

    // Update is called once per frame
    void Update(){
        // update the TEXTURE, not the charging itself.
        charge+= Time.deltaTime * chargeSpeed;
        chargeObject.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0, charge));

        // switch to state FULL if charging is complete.
        if(cellState==CellState.CHARGING){

            chargeh+= Time.deltaTime * chargeSpeed * (FULLCHARGE-EMPTYCHARGE);
            setScaleY(chargeh);

            if(chargeh>=FULLCHARGE)
                switchState(CellState.FULL);
        }
    }

    private void setScaleY(float newY){
        Vector3 old =chargeObject.transform.localScale;
        chargeObject.transform.localScale= new Vector3(old.x, newY, old.z);
    }

}

public enum CellState {
    EMPTY, CHARGING, FULL
};