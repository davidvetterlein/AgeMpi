using UnityEngine;
using System.Collections;

public class SuchDirEinen : MonoBehaviour {
    public float radius;
    public Collider[] Gesuchte;
    public GameObject[] RichtigeObjekte;
    string vorherigerBeruf;
    public GameObject Naehsten;
    float dist = 0;
	// Use this for initialization
	void Start () {
        vorherigerBeruf = gameObject.GetComponent<Personlichkeit>().Beruf;
	}
	
	// Update is called once per frame
	void Update () {

        dist = 0;
        System.Array.Clear(RichtigeObjekte, 0, RichtigeObjekte.Length);
        Gesuchte = Physics.OverlapSphere(transform.position, radius);
        int i = 0;
        foreach (Collider g in Gesuchte)
        {
            if(g.gameObject.GetComponent<ResourcenInfo>() != null)
            {
                if (g.gameObject.GetComponent<ResourcenInfo>().Resource == gameObject.GetComponent<Personlichkeit>().Beruf && g.gameObject.GetComponent<ResourcenInfo>().Spieler == null)
                {
                    float distance = Vector3.Distance(g.transform.position, gameObject.transform.position);
                    if(dist == 0 || distance <= dist || vorherigerBeruf != gameObject.GetComponent<Personlichkeit>().Beruf)
                    {
                        dist = distance;
                        Naehsten = g.gameObject;
                    }
                    RichtigeObjekte[i] = g.gameObject;
                    i += 1;
                }
            }
        }
    }
}
