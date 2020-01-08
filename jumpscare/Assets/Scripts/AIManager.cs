using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIManager : MonoBehaviour
{
    public GameManager manager; //target
    Transform target;
    public NavMeshAgent AI_1; //agent
    //public float radius = 2F; //juste pour 1 AI

    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        target = manager.player.gameObject.transform;
    }
    
    void Update()
    {
        AI_1.SetDestination(target.position);
    }
}
