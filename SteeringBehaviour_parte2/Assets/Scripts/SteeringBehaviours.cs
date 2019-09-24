using UnityEngine;
using System.Collections.Generic;

public class SteeringBehaviours
{
    public static Vector3 Seek(SBAgent agent, Transform target, float range = 99999)
    {
        //Cálculo del vector deseado
        Vector3 desired = Vector3.zero;
        Vector3 difference = (target.position - agent.transform.position);
        float distance = difference.magnitude;
        desired = difference.normalized * agent.maxSpeed;

        if(distance < range)
        {
            return Vector3.ClampMagnitude(desired - agent.velocity, agent.maxSteer);
        }
        else
        {
            return Vector3.zero;
        }
    }

    public static Vector3 Flee(SBAgent agent, Transform target, float range = 99999)
    {
        Vector3 desired = Vector3.zero;
        Vector3 difference = -(target.position - agent.transform.position);
        float distance = difference.magnitude;
        desired = difference.normalized * agent.maxSpeed;

        if(distance < range)
        {
            return Vector3.ClampMagnitude(desired - agent.velocity, agent.maxSteer);
        }
        else
        {
            return Vector3.zero;
        }
    }

    public static Vector3 Arrive(SBAgent agent, Transform target, float range)
    {
        Vector3 desired;
        Vector3 difference = (target.position - agent.transform.position);
        float distance = difference.magnitude;

        desired = difference.normalized * agent.maxSpeed * ((distance > range)?1:(distance/range));

        //Cálculo de vectores
        Vector3 steer = Vector3.ClampMagnitude(desired - agent.velocity, agent.maxSteer);

        return steer;
    }

    public static Vector3 Separate(SBAgent agent, List<GameObject> agentsToAvoid, float range)
    {
        Vector3 steer = Vector3.zero;
        
        for(int i = 0; i < agentsToAvoid.Count; i++)
        {
            steer += Flee(agent, agentsToAvoid[i].transform, range);
        }

        return steer;
    }
}
