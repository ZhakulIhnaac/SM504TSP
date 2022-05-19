using System.ComponentModel;
using Game.Scripts.Behaviours;
using Game.Scripts.Controllers;
using UnityEngine;

public partial class SROptions
{
    private float _lotCarAcceleration;
    private float _lotCarMaxForwardSpeed;
    private float _lotCarBackwardSpeed;
    private float _lotCarJoiningTrafficLimit;
    private float _lotCarFollowingDistance;
    private float _perfectFitAllowedErrorPercentage;
    private float _carRotationOnJoinRoadZAxis;
    private float _carRotationOnJoinRoadYAxis;

    [Category("Overall")]
    public void ResetPlayerPrefsAndQuit()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }

    [Category("Level")]
    public void SolveAllPuzzles()
    {
        var puzzles = Object.FindObjectsOfType<PuzzleController>();

        foreach (var puzzle in puzzles)
        {
            puzzle.ToggleLock();
        }
    }
    
    [Category("Level")]
    public void ShowSolutions()
    {
        var puzzles = Object.FindObjectsOfType<PuzzleController>();

        foreach (var puzzle in puzzles)
        {
            for (int i = 0; i < puzzle.PuzzlePlatesSuccessOrder.Length; i++)
            {
                puzzle.PuzzlePlatesSuccessOrder[i].copyText.text = i.ToString();
            }
        }
    }
}