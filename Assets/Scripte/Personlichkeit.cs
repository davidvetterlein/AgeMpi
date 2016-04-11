using UnityEngine;
using System.Collections;

public class Personlichkeit : MonoBehaviour {
    int maxnamen;
    int namennummer;
    public string Name;


    public int personennummer;
    public string Beruf;
    GameObject Herrscher;
	// Use this for initialization
	void Start () {
        Herrscher = GameObject.Find("Herrscher");
        maxnamen = Herrscher.GetComponent<Daten>().namen.Length;
        namennummer = Random.Range(0, maxnamen);
        Herrscher.GetComponent<Daten>().personenzahl += 1;
        Berufanderung();
    }

    // Update is called once per frame
    public void Berufanderung()
    {
        switch (Beruf)
        {
            case "Stein":
                Beruf = "Baum";
                break;
            case "Baum":
                Beruf = "Essen";
                break;
            case "Essen":
                Beruf = "Stein";
                break;
            case "":
                Beruf = GameObject.Find("Herrscher").GetComponent<Berufe>().Beruf[Random.Range(0, GameObject.Find("Herrscher").GetComponent<Berufe>().Beruf.Length)];
                break;
        }
    }
}
