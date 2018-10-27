using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainCheck : MonoBehaviour {

    RaycastHit lastHit;
    GameObject parentObj;

    private bool isFlying = false;
    private float TimeStartedFlying;
    private float TimeStoppedFlying;
    private float CoolingFactor;

	// Use this for initialization
	void Start () {
        parentObj = this.gameObject;
        Debug.Log("Attached to " + parentObj.ToString());
        CoolingFactor = parentObj.GetComponent<HeatGenerationController>().BaseCoolingFactor;

    }
	
	// Update is called once per frame
	void Update () {
        if (Physics.Raycast(parentObj.transform.position, parentObj.transform.TransformVector(Vector3.down), out lastHit, 1f)) //if we hit something
        {
            if (isFlying)
            {
                //we aren't flying anymore
                isFlying = false;
                Debug.Log("Not Flying");
                //get the time we stopped flying
                TimeStoppedFlying = Time.time;
                Debug.Log("Heat reduced by "+ ((TimeStartedFlying-TimeStoppedFlying)*400).ToString());
                parentObj.GetComponent<HeatGenerationController>().ChangeHeat((TimeStartedFlying - TimeStoppedFlying), (CoolingFactor*100));

            }
            //Debug.Log("Hit " + lastHit.transform.gameObject.tag);
            if (lastHit.collider.gameObject.tag =="Terrain")
            {
                //Debug.Log("On the Ground!");
                
            }
        }
        else
        {
            //We're flying
            Debug.Log("Flying");
            isFlying = true;
            TimeStartedFlying = Time.time;
        }
		
	}
}
