using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    List<GameObject> agents = new List<GameObject>();
    int N = 10;

    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject agent = Resources.Load<GameObject>("Agent");
            
            
            if(i==0){
                agent.GetComponent<Agent>().target = GameObject.Find("Target").transform;
            }
            else if(i==1){
                agent.GetComponent<Agent>().target = agents[0].transform;
            }

            agents.Add(agent);
            Instantiate(agent);
        }
    }
}
