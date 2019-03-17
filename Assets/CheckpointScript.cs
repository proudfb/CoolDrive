using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{

    private Vector3 Position;
    private Quaternion Rotation;
    private AudioSource soundCue;

    //With 0 as the start/finish, which checkpoint is this?
    public int CheckpointNumber;

    // Use this for initialization
    void Awake()
    {
        Position = this.transform.position;
        Rotation = this.transform.rotation;
        soundCue = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")//if the object was a player
        {
            Debug.Log("Player crossed checkpoint " + this.CheckpointNumber);
            other.GetComponentInParent<PlayerCheckpoint>().OnCrossCheckpoint(CheckpointNumber, Position, Rotation, soundCue);
        }
    }
}
