// MoveTo.cs
using UnityEngine;
using System.Collections;

public class MoveTo : MonoBehaviour
{

    public Transform goal;

    void Update()
    {
        Vector3 targetPostition = new Vector3(-goal.position.x, this.transform.position.y, -goal.position.z);
        transform.LookAt(targetPostition);
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }
}