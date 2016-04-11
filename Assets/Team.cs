using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Team : MonoBehaviour {
    public GameObject Player;
    public Transform Spawn;
    public string team;
    public int HausAnz;
    public int Spieler;
    public int Leben;
    public int minwood;
    public int minnahrung;
    public int minstein;
    public int Holz;
    public int Nahrung;
    public int Stein;

    public void CreatePlayer () {

        GameObject.Find("MinusTxtStein").GetComponent<Text>().text = "- " + minstein.ToString();
        GameObject.Find("MinusTxtStein").GetComponent<Animator>().SetTrigger("On");
        GameObject.Find("MinusTxtHolz").GetComponent<Text>().text = "- " + minwood.ToString();
        GameObject.Find("MinusTxtHolz").GetComponent<Animator>().SetTrigger("On");
        GameObject.Find("MinusTxtEssen").GetComponent<Text>().text = "- " + minnahrung.ToString();
        GameObject.Find("MinusTxtEssen").GetComponent<Animator>().SetTrigger("On");

        if (Nahrung >= minnahrung && HausAnz > Spieler)
        {
            Spieler += 1;
            Nahrung -= minnahrung;
            Instantiate(Player, Spawn.position, Quaternion.identity);
            GameObject.Find("Menschen").GetComponent<MenschennummerierungEditor>().Neu();
        }
	}
}
