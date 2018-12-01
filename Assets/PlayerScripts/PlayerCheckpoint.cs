using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCheckpoint : MonoBehaviour {
    public int LastCheckpointCrossed { get; private set; }
    private RespawnPlayerController respawn;
    private int totalCheckpoints;

    private int lapcount;
    public int LapCount {
        get { return this.lapcount; }
        private set {
            this.lapcount = value;
            UpdateLapCounter();
        }
    }
    [SerializeField] private Text LapCounter;

    // Use this for initialization
    void Awake () {
        LapCount = 0;
    }

    void Start()
    {
        respawn = gameObject.GetComponent<RespawnPlayerController>();
        totalCheckpoints = GameController.CheckpointCount;
        LastCheckpointCrossed = totalCheckpoints-1;
    }

    private void UpdateLapCounter()
    {
        if (LapCounter != null)
        {
            LapCounter.text = string.Format("Current lap: {0:D}/{1:D}", LapCount, GameController.TotalLapCount);
        }
    }

    public void OnCrossCheckpoint(int checkNum, Vector3 pos, Quaternion rot)
    {
        if (checkNum-1 == LastCheckpointCrossed)
        {
            LastCheckpointCrossed = checkNum;//if the checkpoint we crossed was the next one in sequence, update our last crossed checkpoint
            respawn.UpdateCheckpoint(pos, rot);
        }
        else if ((LastCheckpointCrossed+1 == totalCheckpoints)&&checkNum==0)//if we are crossing the finish line in sequence
        {
            LapCount++;
            LastCheckpointCrossed = checkNum;
            respawn.UpdateCheckpoint(pos, rot);
        }
    }
}
