using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Ordnungscript : MonoBehaviour {

    public string tagg;
    GameObject[] Bennenende;
    Transform[] Dings;

	void Update () {
        Dings = gameObject.GetComponentsInChildren<Transform>();
        int i = 0;
        System.Array.Resize(ref Bennenende, Dings.Length);
        foreach (Transform d in Dings)
        {
            Bennenende[i] = d.gameObject;
            i += 1;
        }
        int anzahl = 0;
        foreach (GameObject Umbenennen in Bennenende)
        {
            if(Umbenennen.GetComponent<ResourcenInfo>() != null)
            {
                anzahl += 1;
                Umbenennen.name = Umbenennen.GetComponent<ResourcenInfo>().Resource + anzahl.ToString();
            }
        }
    }
}
