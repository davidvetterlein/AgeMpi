using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NavMeshEinstellung : MonoBehaviour {

    public Transform Ziel;
    NavMeshAgent nav;
    bool abbauen = true;
    public bool FreieBewegung = false;
    string zieltag;
    public float Nearing;
    bool einmal;
    public GameObject Spitzhacke;
    public GameObject Axt;
    bool bautab = false;
    public GameObject Zentrale;
    bool zuzen;

    // Use this for initialization
    void Start () {
        Zentrale = GameObject.Find("Haus2");
        nav = gameObject.GetComponent<NavMeshAgent>();
        nav.updateRotation = true;
    }
	
	// Update is called once per frame
	void Update () {
        float distance;
        distance = Vector3.Distance(gameObject.transform.position, nav.destination);

        if (distance <= Nearing && einmal == true)
        {
            nav.updatePosition = false;
            nav.updateRotation = false;
            if(Ziel != null)
            {
                transform.LookAt(new Vector3(Ziel.position.x, transform.position.y, Ziel.position.z));
            }
            einmal = false;
            gameObject.GetComponent<Animator>().SetBool("Bewegend", false);
            if (zuzen == true && Ziel.gameObject == Zentrale)
            {
                Zentrale.GetComponent<Team>().Holz += gameObject.GetComponent<Abbauen>().Holz;
                Zentrale.GetComponent<Team>().Stein += gameObject.GetComponent<Abbauen>().Steine;
                Zentrale.GetComponent<Team>().Nahrung += gameObject.GetComponent<Abbauen>().Nahrung;
                gameObject.GetComponent<Abbauen>().Steine = 0;
                gameObject.GetComponent<Abbauen>().Holz = 0;
                gameObject.GetComponent<Abbauen>().Nahrung = 0;
                zuzen = false;
                Ziel = null;
                FreieBewegung = true;
            }
            if(Ziel != null)
            {
                if (Ziel.gameObject.tag == "Baustelle")
                {
                    Ziel.gameObject.GetComponent<Baustelle>().Baut = true;
                }
            }
            if (abbauen == true)
            {
                Abbau();
            }
        }
        if (distance > Nearing + 2)
        {
            nav.updateRotation = true;
            nav.updatePosition = true;
            einmal = true;
        }

        if (FreieBewegung == true && Ziel == null)
        {
            NeuesZiel();
        }

    }

    public void ZuZentrale()
    {
        bautab = false;
        abbauen = true;
        Ziel = Zentrale.transform;
        zuzen = true;
        gameObject.GetComponent<Animator>().SetBool("Bewegend", true);
        nav.destination = Ziel.position;
    }

    public void NeuesZiel ()
    {
        bautab = false;
        abbauen = true;
        if (FreieBewegung == true)
        {
            if(gameObject.GetComponent<SuchDirEinen>().Naehsten != null)
            {
                Ziel = gameObject.GetComponent<SuchDirEinen>().Naehsten.transform;
                abbauen = true;
            }
        }
        if (Ziel != null)
        {
            gameObject.GetComponent<Animator>().SetBool("Bewegend", true);
            nav.destination = Ziel.position;
        }
    }

    public void Abbau()
    {
        gameObject.GetComponent<Animator>().SetBool("Bewegend", false);
        if (Ziel != null && Ziel.gameObject.GetComponent<ResourcenInfo>().Resource != null)
        {
            abbauen = false;
            if (Ziel.gameObject.GetComponent<ResourcenInfo>().Resource == gameObject.GetComponent<Personlichkeit>().Beruf && Ziel.gameObject.GetComponent<ResourcenInfo>().Spieler == null)
            {
                bautab = true;
                gameObject.GetComponent<Abbauen>().Ziel = Ziel.gameObject;
                gameObject.GetComponent<Abbauen>().Abbaun();
            }
        }
    }

}
