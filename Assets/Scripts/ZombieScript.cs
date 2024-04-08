using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ZombieScript : MonoBehaviour
{
  private NavMeshAgent agent;
    private GameObject Player;
   
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player"); 
        agent= GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(Player.transform.position);

        if(Player.transform.position .x  < transform.position.x) 
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
