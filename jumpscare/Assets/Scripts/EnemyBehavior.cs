using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public GameManager manager; //target
    Transform target;
    public Transform player;
    public NavMeshAgent AI_1; //agent
    public GameObject waypoint1;
    public GameObject waypoint2;
    public GameObject waypoint3;
    public GameObject waypoint4;

    private bool inPoint = false;
    private bool toPoint = false;
    public float distance;
    //bool hitDetect;
    int numWaypoint;

    //public Collider enemy1Collider;

    GameObject[] waypoints;

    //possibilities if one waypoint has been reached

    //int numWaypointIfAtW1;
    //int numWaypointIfAtW2;
    //int numWaypointIfAtW3;
    //int numWaypointIfAtW4;

    int[] optionsIfAtW1;
    int[] optionsIfAtW2;
    int[] optionsIfAtW3;
    int[] optionsIfAtW4;

    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        distance = 2F;
        //enemy1Collider = AI_1.gameObject.GetComponent<Collider>();
        numWaypoint = Random.Range(0, 3); //random waypoint
        waypoints = new GameObject[4] { waypoint1, waypoint2, waypoint3, waypoint4 };

        optionsIfAtW1 = new int[] { 1, 2, 3 };
        optionsIfAtW2 = new int[] { 0, 2, 3 };
        optionsIfAtW3 = new int[] { 0, 1, 3 };
        optionsIfAtW4 = new int[] { 0, 1, 2 };

        target = waypoints[numWaypoint].transform;
        Debug.Log(target.name);
    }

    //reaching a waypoint

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "waypoint")
        {

            Debug.Log("It's a waypoint!");


            if (other.name == "Waypoint1")
            {
                int index = Random.Range(0, optionsIfAtW1.Length);
                Debug.Log(index);
                target = waypoints[optionsIfAtW1[index]].transform;
                Debug.Log(target.name);
            }

            else if (other.name == "Waypoint2")
            {
                int index = Random.Range(0, optionsIfAtW2.Length);
                Debug.Log(index);
                target = waypoints[optionsIfAtW2[index]].transform;
                Debug.Log(target.name);
            }

            else if (other.name == "Waypoint3")
            {
                int index = Random.Range(0, optionsIfAtW3.Length);
                Debug.Log(index);
                target = waypoints[optionsIfAtW3[index]].transform;
                Debug.Log(target.name);
            }

            else if (other.name == "Waypoint4")
            {
                int index = Random.Range(0, optionsIfAtW4.Length);
                Debug.Log(index);
                target = waypoints[optionsIfAtW4[index]].transform;
                Debug.Log(target.name);
            }
        }
    }

    void Update()
    {
        AI_1.SetDestination(target.position);

        // raycast

        RaycastHit hit;

        //react to player in view

        if (Physics.Raycast(AI_1.transform.position, AI_1.transform.TransformDirection(Vector3.forward), out hit, distance))
        {

            if (hit.collider.gameObject == player.gameObject)
            {
                target = manager.player.gameObject.transform;
            }

        }



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
