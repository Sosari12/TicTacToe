using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMinMax : MonoBehaviour
{
    public Matryca matrix;
    public int[] StanGry;
    public GameObject wersjaGry;
    public int iloscMiejsc = 0;
    //private int i = 0;

    public int[] wartosci;
    public int[] miejsca;

    public int MiejsceGdzieMamWejsc = 0;
    private int i = 0;
    public bool wstawiam = false;
    public int najmniejsza = 1100;
    public int najwieksza = -1100;
    public int ileRootow = 0;
    public int lokacjaDlaX = 0;
    public int lokacjaDlaO = 0;
    public bool mam = false;
    private int losowa = 0;
    private int priorytet = 0;
    public int maxGlebokosc = 0;

    // Start is called before the first frame update
    void Start()
    {
        losowa = Random.Range(0, iloscMiejsc);
    }

    // Update is called once per frame
    void Update()
    {


        if(wstawiam == true && ileRootow==0)
        {
            if (i < 25)
            {
                if (wartosci[i] < najmniejsza && StanGry[i] == 0)
                {
                    najmniejsza = wartosci[i];
                    lokacjaDlaX = i;
                    mam = true;
                }
                if (wartosci[i] > najwieksza && StanGry[i] == 0)
                {
                    najwieksza = wartosci[i];
                    lokacjaDlaO = i;
                    mam = true;
                }

                Debug.Log("Wartosc[" + i + "] : " + wartosci[i]);
                miejsca[i] = -1;
                wartosci[i] = -1;
                i++;
            }
            else
            {
                if(mam == true)
                {
                    if (najmniejsza == -1000)
                    {
                        matrix.najmniejsza = lokacjaDlaX;
                        priorytet = 4;
                    }

                    
                    if (najwieksza == 1000 && priorytet != 4)
                    {
                        matrix.najmniejsza = lokacjaDlaO;
                        priorytet = 3;
                    }

                    
                    if (najmniejsza <= 0 && priorytet != 3 && priorytet != 4 && najmniejsza > -1000)
                    {
                        matrix.najmniejsza = lokacjaDlaX;
                        priorytet = 2;
                    }

                    if (najwieksza >=0 && priorytet != 2 && priorytet != 3 && priorytet != 4 && najwieksza < 1000)
                    {
                        matrix.najmniejsza = lokacjaDlaO;
                    }
                    
                    Debug.Log("Priority " + priorytet);
                    Debug.Log("Miejsce O: " + lokacjaDlaO + " = Miejsce X: " + lokacjaDlaX);
                    Debug.Log("Najmniejsza: " + najmniejsza + " Najwieksza: " + najwieksza);
                    priorytet = 0;
                    i = 0;
                    najmniejsza = 0;
                    najwieksza = 0;
                    wstawiam = false;
                    mam = false;
                    najmniejsza = 1100;
                    najwieksza = -1100;
                    matrix.pozwolenieNaWstawienie = true;

                }
                else
                {
                    if(StanGry[losowa] == 0)
                    {
                        matrix.najmniejsza = losowa;

                        matrix.pozwolenieNaWstawienie = true;
                        i = 0;
                        najmniejsza = 0;
                        najwieksza = 0;
                        wstawiam = false;
                        najmniejsza = 1100;
                        najwieksza = -1100;
                    }
                    else
                    {
                        losowa = Random.Range(0, iloscMiejsc);
                    }





                }






            }
        }
    }



    public void nowaWersja(int miejsce, int wolneMiejsca, bool minOrMax, GameObject ojciec, int glebokosc, bool root, int maxglb)
    {
        GameObject dziecko = Instantiate(wersjaGry, transform.position, Quaternion.identity);
        dziecko.GetComponent<MinMax>().ojciec = ojciec;
        if(wolneMiejsca > 0)
        {
            dziecko.GetComponent<MinMax>().wolneMiejsca = wolneMiejsca - 1;
        }
        dziecko.GetComponent<MinMax>().jestemRootem = root;
        dziecko.GetComponent<MinMax>().MiejsceGdzieMamWejsc = miejsce;
        dziecko.GetComponent<MinMax>().glebokosc = glebokosc + 1;
        dziecko.GetComponent<MinMax>().maxGlebokosc = maxglb;
        if (minOrMax == true)
        {
            dziecko.GetComponent<MinMax>().jestemMin = true;
        }
        else
        {
            dziecko.GetComponent<MinMax>().jestemMax = true;
        }
        if (root == true) ileRootow++;
        


        dziecko.SetActive(true);
    }


    public void WstawNajm(int najm)
    {
        if(i < 25)
        {

            miejsca[i] = -1;
            wartosci[i] = 0;
            i++;
        }
        else
        {
            i = 0;
            wstawiam = false;
            //matrix.postawDlaBota(najm);
        }

        
    }



}
