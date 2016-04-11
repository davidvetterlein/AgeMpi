using UnityEngine;
using System.Collections;

public class Naherung : MonoBehaviour {
    Transform Ziel;
    public float Nearing;
    NavMeshAgent nav;

    void Start ()
    {
        nav = gameObject.GetComponent<NavMeshAgent>();
    }

    void Update () {
        float distance;
        distance = Vector3.Distance(gameObject.transform.position, nav.destination);

        if (distance <= Nearing)
        {
            nav.updatePosition = false;
            nav.updateRotation = false;
            if (Ziel != null)
            {
                transform.LookAt(new Vector3(Ziel.position.x, transform.position.y, Ziel.position.z));
            }
            gameObject.GetComponent<Animator>().SetBool("Bewegend", false);
        }
        if (distance > Nearing + 2)
        {
            nav.updateRotation = true;
            nav.updatePosition = true;
        }

    }

    public void ZielErkennung(Transform neuZiel)
    {
        Ziel = neuZiel;
    }
}
