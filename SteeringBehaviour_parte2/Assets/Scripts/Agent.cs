using UnityEngine;

public class Agent : SBAgent
{
    [HideInInspector]
    public Transform target;
    [HideInInspector]
    public Transform target2;

    void Start()
    {
        maxSpeed = 12f;
        maxSteer = 2f;

        target2 = GameObject.Find("Obstaculo").transform;
    }
    void Update()
    {
        velocity += SteeringBehaviours.Arrive(this, target, 3f);
        velocity += SteeringBehaviours.Flee(this, target2, 4f);
        velocity += 0.8f * SteeringBehaviours.Separate(this, GameManager.agents, 2f);
        transform.position += velocity * Time.deltaTime;
    }
}
