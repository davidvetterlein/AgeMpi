using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Spielerbefehl : MonoBehaviour {
    public GameObject currentplayer;
    public Transform neuesZiel;
    public Vector3 Bewegungspunkt;

    public Text Name;
    public Text Tag;
    public Text frei;
    public Text Leben;
    public Text berufcan;
    public Text Holz;
    public Text Stein;
    public Text Essen;
    public GameObject Team;
    Ray ray;
    bool bauend = false;
    public GameObject Freiundso;
    bool buttonclick;
    bool lebenabfrage = false;
    GameObject Hittet;

    public void MachNull()
    {
        Hittet = null;
        currentplayer = null;
        neuesZiel = null;
        Tag.text = "-";
        Leben.text = "-";
        Freiundso.SetActive(false);
        Name.text = "-";
        bauend = false;
        GameObject.Find("FreiheitsPlayer (1)").SetActive(false);
        Stein.text = GameObject.Find("Haus2").GetComponent<Team>().Stein.ToString();
        Holz.text = GameObject.Find("Haus2").GetComponent<Team>().Holz.ToString();
        Essen.text = GameObject.Find("Haus2").GetComponent<Team>().Nahrung.ToString();
        Team.SetActive(false);
        if(gameObject.GetComponent<Hausbau>().Current != null)
        {
            gameObject.GetComponent<Hausbau>().Current.transform.position = new Vector3(0, -10, 0);
        }
        gameObject.GetComponent<Hausbau>().enabled = false;
    }

   

    void Update () {
        if(currentplayer != null)
        {
            frei.text = currentplayer.GetComponent<NavMeshEinstellung>().FreieBewegung.ToString();
            berufcan.text = currentplayer.GetComponent<Personlichkeit>().Beruf.ToString();
            Team.SetActive(false);
            Stein.text = currentplayer.GetComponent<Abbauen>().Steine.ToString();
            Holz.text = currentplayer.GetComponent<Abbauen>().Holz.ToString();
            Essen.text = currentplayer.GetComponent<Abbauen>().Nahrung.ToString();
        }
        else
        {
            Stein.text = GameObject.Find("Haus2").GetComponent<Team>().Stein.ToString();
            Holz.text = GameObject.Find("Haus2").GetComponent<Team>().Holz.ToString();
            Essen.text = GameObject.Find("Haus2").GetComponent<Team>().Nahrung.ToString();
        }

        if(lebenabfrage == true && Hittet != null && Hittet.gameObject.tag != "Player" && Hittet.gameObject.tag != "terrain")
        {
            switch (Hittet.tag)
            {
                case "Haus":
                    Leben.text = Hittet.GetComponent<Team>().Leben.ToString();
                    break;
                case "Materialien":
                    Leben.text = Hittet.GetComponent<ResourcenInfo>().Leben.ToString();
                    break;
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            MachNull();
        }
        if (buttonclick == false && bauend == false)
        {
            bool onhit = false;
            if (Input.GetMouseButtonDown(0))
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                onhit = true;
            }
            if (Input.touchCount > 0)
            {
                ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                onhit = true;
            }
            if (onhit == true)
            {
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 1000))
                {
                    Hittet = hit.transform.gameObject;
                    if (currentplayer != null)
                    {
                        switch (Hittet.tag)
                        {
                            case "Player":
                                currentplayer = hit.transform.gameObject;
                                Tag.text = currentplayer.tag;
                                Name.text = currentplayer.name;
                                Leben.text = "100";
                                Freiundso.SetActive(true);
                                Stein.text = Hittet.gameObject.GetComponent<Abbauen>().Steine.ToString();
                                Holz.text = Hittet.gameObject.GetComponent<Abbauen>().Holz.ToString();
                                Essen.text = Hittet.gameObject.GetComponent<Abbauen>().Nahrung.ToString();
                                break;
                            case "Materialien":
                                currentplayer.GetComponent<NavMeshEinstellung>().FreieBewegung = false;
                                neuesZiel = hit.transform;
                                currentplayer.GetComponent<Personlichkeit>().Beruf = Hittet.GetComponent<ResourcenInfo>().Resource;
                                currentplayer.GetComponent<NavMeshEinstellung>().Ziel = neuesZiel;
                                currentplayer.GetComponent<NavMeshEinstellung>().NeuesZiel();
                                currentplayer.GetComponent<Animator>().SetBool("Bewegend", true);
                                currentplayer.GetComponent<Abbauen>().Aufhoren();
                                break;
                            case "terrain":
                                Bewegungspunkt = hit.point;
                                currentplayer.GetComponent<NavMeshAgent>().destination = Bewegungspunkt;
                                currentplayer.GetComponent<NavMeshEinstellung>().Ziel = null;
                                currentplayer.GetComponent<NavMeshEinstellung>().Spitzhacke.SetActive(false);
                                currentplayer.GetComponent<NavMeshEinstellung>().FreieBewegung = false;
                                currentplayer.GetComponent<Animator>().SetBool("Bewegend", true);
                                currentplayer.GetComponent<Abbauen>().Aufhoren();
                                break;
                            case "Haus":
                                currentplayer.GetComponent<NavMeshEinstellung>().FreieBewegung = false;
                                neuesZiel = hit.transform;
                                currentplayer.GetComponent<NavMeshEinstellung>().Ziel = neuesZiel;
                                currentplayer.GetComponent<NavMeshEinstellung>().ZuZentrale();
                                currentplayer.GetComponent<Animator>().SetBool("Bewegend", true);
                                currentplayer.GetComponent<Abbauen>().Aufhoren();
                                break;
                            case "Baustelle":
                                currentplayer.GetComponent<NavMeshEinstellung>().FreieBewegung = false;
                                neuesZiel = hit.transform;
                                currentplayer.GetComponent<NavMeshEinstellung>().Ziel = neuesZiel;
                                currentplayer.GetComponent<NavMeshEinstellung>().NeuesZiel();
                                currentplayer.GetComponent<Animator>().SetBool("Bewegend", true);
                                currentplayer.GetComponent<Abbauen>().Aufhoren();
                                break;

                        }
                    }
                    else
                    {
                        switch (Hittet.tag)
                        {
                            case "Player":
                                currentplayer = hit.transform.gameObject;
                                Tag.text = currentplayer.tag;
                                Name.text = currentplayer.name;
                                Leben.text = "100";
                                Freiundso.SetActive(true);
                                Stein.text = Hittet.gameObject.GetComponent<Abbauen>().Steine.ToString();
                                Holz.text = Hittet.gameObject.GetComponent<Abbauen>().Holz.ToString();
                                Holz.text = Hittet.gameObject.GetComponent<Abbauen>().Nahrung.ToString();
                                break;
                            case "Materialien":
                                Tag.text = Hittet.tag;
                                Name.text = Hittet.name;
                                Leben.text = Hittet.GetComponent<ResourcenInfo>().Leben.ToString();
                                lebenabfrage = true;
                                Team.SetActive(false);
                                break;
                            case "Haus":
                                Tag.text = Hittet.tag;
                                Stein.text = Hittet.gameObject.GetComponent<Team>().Stein.ToString();
                                Holz.text = Hittet.gameObject.GetComponent<Team>().Holz.ToString();
                                Essen.text = Hittet.gameObject.GetComponent<Team>().Nahrung.ToString();
                                Name.text = Hittet.name;
                                Leben.text = Hittet.GetComponent<Team>().Leben.ToString();
                                Team.SetActive(true);
                                lebenabfrage = true;
                                break;
                        }
                    }
                }
            }
        }
        if(buttonclick == true)
        {
            buttonclick = false;
        }

    }
    public void Freiheit()
    {
        buttonclick = true;
        if (currentplayer.GetComponent<NavMeshEinstellung>().FreieBewegung == false)
        {
            currentplayer.GetComponent<NavMeshEinstellung>().Ziel = null;
            currentplayer.GetComponent<NavMeshEinstellung>().FreieBewegung = true;
            currentplayer.GetComponent<Abbauen>().Aufhoren();
        }
        else
        {
            currentplayer.GetComponent<NavMeshEinstellung>().FreieBewegung = false;
        }
    }
    public void Berufswahl()
    {
        switch (currentplayer.GetComponent<Personlichkeit>().Beruf)
        {
            case "Essen":
                currentplayer.GetComponent<Personlichkeit>().Beruf = "Stein";
                break;
            case "Stein":
                currentplayer.GetComponent<Personlichkeit>().Beruf = "Baum";
                break;
            case "Baum":
                currentplayer.GetComponent<Personlichkeit>().Beruf = "Essen";
                break;
        }
        buttonclick = true;
        currentplayer.GetComponent<NavMeshEinstellung>().FreieBewegung = false;
        currentplayer.GetComponent<NavMeshEinstellung>().Ziel = null;
        currentplayer.GetComponent<Abbauen>().Aufhoren();
    }

    public void Bauen()
    {
        buttonclick = true;
        bauend = true;
        gameObject.GetComponent<Hausbau>().enabled = true;
    }
}
