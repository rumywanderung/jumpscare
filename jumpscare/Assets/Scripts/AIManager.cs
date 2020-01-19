using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIManager : MonoBehaviour
{
    public GameManager manager; //target
    Transform target;
    public NavMeshAgent AI_1; //agent
    public GameObject waypoint1;
    public GameObject waypoint2;
    public GameObject waypoint3;
    public GameObject waypoint4;

    private bool inPoint = false;
    private bool toPoint = false;
    public float distance;
    bool hitDetect;

    public Collider enemy1Collider;

    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        target = manager.player.gameObject.transform;
        distance = 10F;
        //enemy1Collider = AI_1.gameObject.GetComponent<Collider>();
    }
    
    void Update()
    {
        AI_1.SetDestination(target.position);

        // raycast

        RaycastHit hit;
        if (Physics.Raycast(AI_1.transform.position, AI_1.transform.TransformDirection(Vector3.forward), out hit, distance))
        {
            Debug.DrawRay(AI_1.transform.position, AI_1.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");
            //Add small rays
        }
        else
        {
            Debug.DrawRay(AI_1.transform.position, AI_1.transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            //Debug.Log("Did not Hit");
            //Add huge red rays
        }
    }

    /*private void OnDrawGizmos()
    {
        RaycastHit hit;
        Gizmos.color = Color.red;

        hitDetect = Physics.BoxCast(enemy1Collider.bounds.center, transform.localScale, transform.forward, out hit, transform.rotation, distance);
        if (hitDetect)
        {
            Debug.Log("we found!!!");
            Gizmos.DrawRay(transform.position, transform.forward * distance);
            Gizmos.DrawWireCube(transform.position + transform.forward * distance, transform.localScale);
        }
        else
        {
            Debug.Log("we didn't find anyone");
        }
            
    }*/
}
