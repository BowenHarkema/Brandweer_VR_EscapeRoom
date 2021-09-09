using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatchScript : MonoBehaviour
{
    public GameObject hinge;
    public float hingeSpeed;

    public HatchState targetState=HatchState.CLOSED;
    bool isMoving=true;

    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update()
    {
        if(isMoving){
            float z=hinge.transform.localEulerAngles.z;

            if(targetState==HatchState.OPEN){
                if(z<140){
                    z+=140.0f/hingeSpeed *Time.deltaTime;
                }else{
                    z=140;
                    isMoving=false;
                }
            }

            if(targetState==HatchState.CLOSED){
                if(z>0 && z< 180){
                    z-=140.0f/hingeSpeed *Time.deltaTime;
                }else{
                    z=0;
                    isMoving=false;
                }
            }

            hinge.transform.localEulerAngles=new Vector3(hinge.transform.localEulerAngles.x,hinge.transform.localEulerAngles.y , z);
        }
    }

    public void openHatch(){
        targetState=HatchState.OPEN;
        isMoving=true;
    }
    public void closeHatch(){
        targetState=HatchState.CLOSED;
        isMoving=true;
    }

    public bool isClosed(){
        return targetState==HatchState.CLOSED && isMoving == false;
    }
    public bool isOpen(){
        return targetState==HatchState.OPEN && isMoving == false;
    }
}
public enum HatchState {
    OPEN, CLOSED
}