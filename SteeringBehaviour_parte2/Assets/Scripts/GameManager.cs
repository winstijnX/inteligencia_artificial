using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static List<GameObject> agents = new List<GameObject>();
    int N = 10;

    void Start()
    {
        for (int i = 0; i < N; i++)
        {
            GameObject agent = Resources.Load<GameObject>("Agent");
            GameObject instance = Instantiate(agent);
            instance.GetComponent<Renderer>().sharedMaterial.color = new Color(Random.value,Random.value,Random.value); 
            instance.GetComponent<Agent>().maxSpeed = 1f;
            instance.GetComponent<Agent>().maxSteer = 1f;
            instance.transform.position = new Vector3(Random.Range(-9, 9), Random.Range(-5, 5), 0);
            
            //if(i==0){
               instance.GetComponent<Agent>().target = GameObject.Find("Target").transform;
            //}
            //else {
            //   instance.GetComponent<Agent>().target = agents[i-1].transform;
            //}
            instance.name = "Agent" + i.ToString();
            agents.Add(instance);
        }
    }
}
