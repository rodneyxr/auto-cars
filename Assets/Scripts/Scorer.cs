using UnityEngine;
using System.Collections;

public class Scorer : MonoBehaviour {
    //TODO: Implement text display for score, make jsure it gets updated hwnever the score is increased.
    private uint playerScore;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void scoreIncrement(uint points)
    {
        playerScore += points;
    }
}
