using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hausbau : MonoBehaviour {
    public GameObject Haus;
    public GameObject Baustelle;
    public GameObject Baum;
    public GameObject Feld;
    Vector3 lasthit;
    public int mask;
    public int minwood;
    public int minstein;
    public GameObject Bauauswahl;
    bool waitofcurrent = true;
    bool clicked = false;

    public GameObject Current;
    // Use this for initialization
    void OnEnable () {
        Bauauswahl.SetActive(true);
        Current = Haus;
        waitofcurrent = true;
        GameObject.Find("MinusTxtStein").GetComponent<Text>().text = "- " + minstein.ToString();
        GameObject.Find("MinusTxtStein").GetComponent<Animator>().SetTrigger("On");
        GameObject.Find("MinusTxtHolz").GetComponent<Text>().text = "- " + minwood.ToString();
        GameObject.Find("MinusTxtHolz").GetComponent<Animator>().SetTrigger("On");
    }

    // Update is called once per frame
    void Update()
    {
        if (waitofcurrent == false)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000, mask) && clicked == false)
            {
                if (lasthit != hit.point && hit.transform.gameObject.tag == "terrain")
                {
                    Current.transform.position = hit.point + new Vector3(0, 0.5f, 0);
                    lasthit = hit.point;
                    Current.GetComponent<BauAbfrage>().terrain = true;
                }
                if (hit.transform.gameObject.tag != "terrain" && lasthit != hit.point)
                {
                    Current.transform.position = hit.point + new Vector3(0, 0.5f, 0);
                    lasthit = hit.point;
                }
            }
            if (Input.GetMouseButtonDown(0) && clicked == false)
            {
                if (Haus.GetComponent<BauAbfrage>().terrain == true && Haus.GetComponent<BauAbfrage>().buildable == true && GameObject.Find("Haus2").GetComponent<Team>().Holz >= minwood && GameObject.Find("Haus2").GetComponent<Team>().Stein >= minstein)  //Klappt noch nicht
                {
                    GameObject.Find("Haus2").GetComponent<Team>().Holz -= minwood;
                    GameObject.Find("Haus2").GetComponent<Team>().Stein -= minstein;
                    GameObject Baust = Instantiate(Baustelle, Current.transform.position, Quaternion.identity) as GameObject;
                    if (Current == Haus)
                    {
                        Baust.GetComponent<Baustelle>().Current = Baust.GetComponent<Baustelle>().Haus;
                    }
                    if (Current == Feld)
                    {
                        Baust.GetComponent<Baustelle>().Current = Baust.GetComponent<Baustelle>().Feld;
                    }
                    if (Current == Baum)
                    {
                        Baust.GetComponent<Baustelle>().Current = Baust.GetComponent<Baustelle>().Baum;
                    }
                }
            }
            if(clicked == true)
            {
                clicked = false;
            }
        }
    }
    public void Hausbaun()
    {
        clicked = true;
        Current.transform.position = new Vector3(0, -10, 0);
        Current = Haus;
        waitofcurrent = false;
    }
    public void Feldbaun()
    {
        clicked = true;
        Current.transform.position = new Vector3(0, -10, 0);
        Current = Feld;
        waitofcurrent = false;
    }
    public void Baumbaun()
    {
        clicked = true;
        Current.transform.position = new Vector3(0, -10, 0);
        Current = Baum;
        waitofcurrent = false;
    }



}
