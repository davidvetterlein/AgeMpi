using UnityEngine;
using System.Collections;

public class BauAbfrage : MonoBehaviour {
    public bool buildable = true;
    public bool terrain = false;
    public Material[] geht;
    public Material[] gehtnicht;
    int minsteine;
    int minwood;
    // Use this for initialization
    void Start () {
	    minsteine = GameObject.Find("Herrscher").GetComponent<Hausbau>().minstein;
        minwood = GameObject.Find("Herrscher").GetComponent<Hausbau>().minwood;
    }
	
	// Update is called once per frame
	void Update () {
        if(buildable == true && terrain == true && GameObject.Find("Haus2").GetComponent<Team>().Holz >= minwood && GameObject.Find("Haus2").GetComponent<Team>().Stein >= minsteine)
        {
            gameObject.GetComponentInChildren<MeshRenderer>().materials = geht;
        }
        else
        {
            gameObject.GetComponentInChildren<MeshRenderer>().materials = gehtnicht;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        buildable = false;
    }
    void OnTriggerExit(Collider other)
    {
        buildable = true;
    }
}
