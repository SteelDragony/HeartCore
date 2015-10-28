using UnityEngine;
using System.Collections;

public class SimpleAI : MonoBehaviour {

    public Transform[] waypoints;
    private int destPoint = 0;
    NavMeshAgent NMAgent;

	// Use this for initialization
	void Start () {
        NMAgent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (NMAgent.remainingDistance < 0.5f)
            GoToNextPoint();
    }

    void GoToNextPoint()
    {
        // Returns if no points have been set up
        if (waypoints.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        NMAgent.destination = waypoints[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = Random.Range(0, waypoints.Length);
    }
}
