using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCheckpoint : MonoBehaviour
{
    public int LastCheckpointCrossed { get; private set; }
    private RespawnPlayerController respawn;
    private int totalCheckpoints;

    private int lapcount;
    public int LapCount
    {
        get { return this.lapcount; }
        private set
        {
            this.lapcount = value;
            UpdateLapCounter();
        }
    }
    [SerializeField] private Text LapCounter;

    // Use this for initialization
    void Awake()
    {
        LapCount = 0;
    }

    void Start()
    {
        respawn = gameObject.GetComponent<RespawnPlayerController>();
        totalCheckpoints = GameController.CheckpointCount;
        LastCheckpointCrossed = totalCheckpoints - 1;
        Debug.Log("LCC = " + LastCheckpointCrossed);
    }

    private void UpdateLapCounter()
    {
        if (LapCounter != null)
        {
            LapCounter.text = string.Format("Current lap: {0:D}/{1:D}", LapCount, GameController.TotalLapCount);
            if (LapCount > GameController.TotalLapCount)
            {
                //we've finished, so go back to the main menu scene
                SceneManager.LoadScene(0, LoadSceneMode.Single);

                //TODO: add hook for finishing place info
            }
        }
    }

    public void OnCrossCheckpoint(int checkNum, Vector3 pos, Quaternion rot, AudioSource audio = null)
    {
        Debug.Log("LastCheckpointCrossed+1 = " + (LastCheckpointCrossed + 1).ToString());
        //if the checkpoint we crossed was the next one in sequence, update our last crossed checkpoint
        if (checkNum - 1 == LastCheckpointCrossed)
        {
            Debug.Log("Updating last crossed checkpoint to " + checkNum);
            LastCheckpointCrossed = checkNum;
            if (audio!=null && audio.enabled)
            {
                audio.Play();
            }
            respawn.UpdateCheckpoint(pos, rot);
        }
        else if (((LastCheckpointCrossed + 1) == totalCheckpoints) && checkNum == 0)//if we are crossing the finish line in sequence
        {
            LapCount++;
            LastCheckpointCrossed = checkNum;
            respawn.UpdateCheckpoint(pos, rot);
        }
    }
}
