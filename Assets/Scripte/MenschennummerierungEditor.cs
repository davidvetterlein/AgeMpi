using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class MenschennummerierungEditor : MonoBehaviour {
    int anzahl = 0;
    public GameObject[] Bennenende;
    public string tagg;
    public string[] Namen;

    public void OnEnable()
    {
        Bennenende = GameObject.FindGameObjectsWithTag(tagg);

        foreach (GameObject Umbenennen in Bennenende)
        {
            if(Umbenennen.activeSelf == true && Umbenennen.GetComponent<Personlichkeit>() != null)
            {
                string ausname;
                anzahl += 1;
                ausname = Namen[Random.Range(0, Namen.Length)];
                Umbenennen.name = ausname;
                Umbenennen.GetComponent<Personlichkeit>().personennummer = anzahl;
                Umbenennen.GetComponent<Personlichkeit>().Name = ausname;
            }
        }
        anzahl = 0;
    }

    public void Neu()
    {
        Bennenende = GameObject.FindGameObjectsWithTag(tagg);

        foreach (GameObject Umbenennen in Bennenende)
        {
            if (Umbenennen.activeSelf == true && Umbenennen.GetComponent<Personlichkeit>() != null)
            {
                string ausname;
                anzahl += 1;
                ausname = Namen[Random.Range(0, Namen.Length)];
                Umbenennen.name = ausname;
                Umbenennen.GetComponent<Personlichkeit>().personennummer = anzahl;
                Umbenennen.GetComponent<Personlichkeit>().Name = ausname;
            }
        }
        anzahl = 0;
    }
}
