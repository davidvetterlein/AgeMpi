using UnityEngine;
using System.Collections;

public class Baustelle : MonoBehaviour {
    public bool Baut;
    public GameObject Current;
    public GameObject Haus;
    public GameObject Feld;
    public GameObject Baum;
    public GameObject Baustell;
    public Vector3 vec;
    public Transform Goto;
    public float speed;


	void Update () {
        if (Current != null)
        {
            float step = speed * Time.deltaTime;
            if (Baut == true)
            {
                Current.transform.position = Vector3.MoveTowards(Current.transform.position, Goto.position, step);
            }
            if (Current.transform.position == Goto.position)
            {
                Destroy(Goto.gameObject);
                Destroy(Baustell);
                GameObject.Find("Haus2").GetComponent<Team>().HausAnz += 1;
                gameObject.GetComponent<Baustelle>().enabled = false;
            }
        }
	}

}
