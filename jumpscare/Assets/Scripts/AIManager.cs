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
    bool hitDetect;

    public Collider enemy1Collider;

    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        target = manager.player.gameObject.transform;
        //enemy1Collider = AI_1.gameObject.GetComponent<Collider>();
    }
    
    void Update()
    {
        /* if (Physics.Raycast(transform.position, Vector3.forward, out hit, 50F))
        {
            Debug.Log(hit.rigidbody.name);
        }*/
        AI_1.SetDestination(target.position);
    }

    private void OnDrawGizmos()
    {
        RaycastHit hit;
        Gizmos.color = Color.red;

        hitDetect = Physics.BoxCast(enemy1Collider.bounds.center, transform.localScale, transform.forward, out hit, transform.rotation, 30F);
        if (hitDetect)
        {
            Debug.Log("we found!!!");
            Gizmos.DrawRay(transform.position, transform.forward * 30F);
            Gizmos.DrawWireCube(transform.position + transform.forward * 30F, transform.localScale);
        }
        else
        {
            Debug.Log("we didn't find anyone");
        }
            
    }
}
