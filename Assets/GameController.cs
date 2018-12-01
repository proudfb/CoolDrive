using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameObject[] ListOfCheckpoints { get; private set; }
    public static GameObject[] ListOfPlayers { get; private set; }
    public static int CheckpointCount { get; private set; }
    public static int PlayerCount { get; private set; }
    public static int TotalLapCount=3;
    [SerializeField] private int TotalLaps = 3;

    // Use this for initialization

    void Awake()
    {
        if (TotalLaps>0)
        {
            //override default values
            TotalLapCount = TotalLaps;
        }
    }

    void Start () {
        ListOfCheckpoints = GameObject.FindGameObjectsWithTag("Checkpoint");
        CheckpointCount = ListOfCheckpoints.Length;
	}
	
}
