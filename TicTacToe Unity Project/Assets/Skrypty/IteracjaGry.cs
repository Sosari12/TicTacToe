using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IteracjaGry : MonoBehaviour
{
    public int[] Gra;

    public int mojaWartosc;
    public GameObject ojciec;
    public GameObject[] dzieci;

    public bool jestemOjcem = false;
    public bool jestemDzieckiem = false;

    //private bool juzPobrano = false;
    //private int i = 0;

    /*
    public void Update()
    {
        if (i == 25) juzPobrano = true;
        else if(juzPobrano == false)
        {
            Gra[i] = ojciec.GetComponent<MinMax>().aktualnyStanGry[i];
            i++;
        }
    }
    */
}
