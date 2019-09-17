using UnityEngine;

public class SteeringBehaviours
{
    public static Vector3 Seek(SBAgent agent, Transform target)
    {
        Vector3 desired = (target.position - agent.transform.position).normalized * agent.maxSpeed;

        Vector3 steer = Vector3.ClampMagnitude(desired - agent.velocity, agent.maxSteer);
        agent.velocity += steer * Time.deltaTime;
        agent.transform.position += agent.velocity * Time.deltaTime;

        return steer;
    }

    public static Vector3 Flee(SBAgent agent, Transform target)
    {
        Vector3 desired = -(target.position - agent.transform.position).normalized * agent.maxSpeed;

        Vector3 steer = Vector3.ClampMagnitude(desired - agent.velocity, agent.maxSteer);
        agent.velocity += steer * Time.deltaTime;
        agent.transform.position += agent.velocity * Time.deltaTime;

        return steer;
    }

    public static Vector3 Arrive(SBAgent agent, Transform target, float range)
    {
        Vector3 desired;
        Vector3 difference = (target.position - agent.transform.position);
        float distance = difference.magnitude;

        desired = difference.normalized * agent.maxSpeed * ((distance > range)?1:0/*(Mathf.Sqrt(distance/range))*/);

        //Cálculo de vectores
        Vector3 steer = Vector3.ClampMagnitude(desired - agent.velocity, agent.maxSteer);
        agent.velocity += steer * Time.deltaTime;
        agent.transform.position += agent.velocity * Time.deltaTime;

        return steer;
    }
}
