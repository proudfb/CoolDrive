using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayerController : MonoBehaviour {
    public Vector3 LastCheckpoint { get; private set; }

    public Quaternion LastCheckpointRotation { get; private set; }

    public Rigidbody rb;



    // Use this for initialization
    void Start () {
        LastCheckpoint = new Vector3(135.5f, 0.1f, 77.5f);
        LastCheckpointRotation = Quaternion.Euler(0, 0, 0);
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RespawnPlayer()
    {
        gameObject.transform.SetPositionAndRotation(LastCheckpoint, LastCheckpointRotation);
        rb.velocity = new Vector3(0, 0, 0);
    }

    public void RespawnPlayer(int deathFlag)
    {
        switch (deathFlag)
        {
            case 0: //FREEZE
                gameObject.GetComponent<HeatGenerationController>().ResetHeat();
                Debug.Log("Player was too cool.");
                break;
            case 1: //OVERHEAT
                gameObject.GetComponent<HeatGenerationController>().ResetHeat();
                Debug.Log("Player was way too hot.");
                break;
            default:
                Debug.Log("Player broke the game, and was punished for their foolishness.");
                break;
        }
        Debug.Log("Respawning Player");
        gameObject.transform.SetPositionAndRotation(LastCheckpoint, LastCheckpointRotation);
        rb.velocity = new Vector3(0, 0, 0);
        rb.angularVelocity = Vector3.zero;
    }
}
