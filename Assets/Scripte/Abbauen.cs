using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Abbauen : MonoBehaviour {
    public GameObject Spitzhacke;
    public GameObject Axt;
    public GameObject Ziel;
    public bool abbauen = false;
    public int speed;
    public int neuspeed;
    public int Holz;
    public int Steine;
    public int Nahrung;
    Text Wood;
    Text Stein;
    // Use this for initialization
    public void Abbaun ()
    {
        Stein = GameObject.Find("SteinAnz").GetComponent<Text>();
        Wood = GameObject.Find("WoodAnz").GetComponent<Text>();
        abbauen = true;
        Ziel.GetComponent<ResourcenInfo>().Spieler = gameObject;
        switch (gameObject.GetComponent<Personlichkeit>().Beruf)
        {
            case "Stein":
                Spitzhacke.SetActive(true);
                gameObject.GetComponent<Animator>().SetBool("AbbauenStein", true);
                break;
            case "Baum":
                Axt.SetActive(true);
                gameObject.GetComponent<Animator>().SetBool("AbbauenHolz", true);
                break;
        }
    }

    public void Abgebaut ()
    {
        abbauen = false;
        gameObject.GetComponent<Animator>().SetBool("AbbauenStein", false);
        gameObject.GetComponent<Animator>().SetBool("AbbauenHolz", false);
        Axt.SetActive(false);
        Spitzhacke.SetActive(false);
        gameObject.GetComponent<NavMeshEinstellung>().Ziel = null;
    }

    public void Aufhoren()
    {
        abbauen = false;
        gameObject.GetComponent<Animator>().SetBool("AbbauenStein", false);
        gameObject.GetComponent<Animator>().SetBool("AbbauenHolz", false);
        Axt.SetActive(false);
        Spitzhacke.SetActive(false);
        if (Ziel != null)
        {
            Ziel.GetComponent<ResourcenInfo>().Spieler = null;
            Ziel = null;
        }
    }

    void Update ()
    {
        if(abbauen == true)
        {
            speed -= 1;
            if(speed <= 0 && Holz <= 99 || speed <= 0 && Steine <= 99)
            {
                speed = neuspeed;
                Ziel.GetComponent<ResourcenInfo>().Leben -= 1;
                switch (Ziel.GetComponent<ResourcenInfo>().Resource)
                {
                    case "Stein":
                        //GameObject.Find("Herrscher").GetComponent<Daten>().Steine += 1;
                        Steine += 1;
                        break;
                    case "Baum":
                        //GameObject.Find("Herrscher").GetComponent<Daten>().Wood += 1;
                        Holz += 1;
                        break;
                    case "Essen":
                        Nahrung += 1;
                        break;
                }
            }
            if(Steine >= 100 || Holz >= 100 || Nahrung >= 100)
            {
                Aufhoren();
                gameObject.GetComponent<NavMeshEinstellung>().ZuZentrale();
            }
        }
    }
}
