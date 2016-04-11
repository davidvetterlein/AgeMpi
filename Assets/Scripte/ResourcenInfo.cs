using UnityEngine;
using System.Collections;

public class ResourcenInfo : MonoBehaviour {
    public int Leben;
    public string Resource;
    public GameObject Spieler;
    // Use this for initialization
    void Start () {
        Leben = 100;
	}
	
	// Update is called once per frame
	void Update () {
	    if(Leben <= 0)
        {
            if(Spieler != null)
            {
                Spieler.GetComponent<Animator>().SetBool("Bewegend", true);
                Spieler.GetComponent<Abbauen>().Abgebaut();
                Spieler.GetComponent<NavMeshEinstellung>().FreieBewegung = true;
                Spieler.GetComponent<NavMeshEinstellung>().NeuesZiel();
            }
            Destroy(gameObject);
        }
	}
}
