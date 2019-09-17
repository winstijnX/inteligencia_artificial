using UnityEngine;

public class Agent : SBAgent
{
    public Transform target;

    void Update()
    {
        velocity += SteeringBehaviours.Arrive(this, target, 1f);
    }
}
