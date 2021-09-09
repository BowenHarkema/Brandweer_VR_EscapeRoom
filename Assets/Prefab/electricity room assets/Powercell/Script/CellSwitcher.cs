using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellSwitcher : MonoBehaviour
{
    public GameObject nextCellType;


    void Start(){}
    void Update(){}

    
     private void OnTriggerEnter(Collider other){

        if(true){ //ther.tag.Equals("charger")){
            AdvanceToNextCellType();
        }
    }


    public void AdvanceToNextCellType(){
        Instantiate(nextCellType, new Vector3(0, 0, 0), Quaternion.identity);
        Destroy(this.gameObject);
    }
}
