using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinMaxZap : MonoBehaviour
{

    //jest zapisywana wartosc poszczegolnej gry
    //teraz trzeba zrobic by zliczala sie ta wartosc dopiero na gdy glebokosc jest == ilosci wolnych miejsc
    //wiec obiekty w srodku i na poczatku pobieraja zliczanie od tych na koncu




    public int[] aktualnyStanGry;
    public MainMinMax main;
    public GameObject ojciec;

    public GameObject Dziecko;
    public bool jestemMin = false;
    public bool jestemMax = false;
    public bool jestemRootem = false;

    public bool pobralemGre = false;
    public bool zliczylem = false;
    public bool stworzylemdzieci = false;

    private int i = 0;
    private int j = 0;

    public int mojaWartosc = 0;
    public int MiejsceGdzieMamWejsc = 0;
    public int[] wartosci;
    public int[] miejsca;

    public int glebokosc = 0;
    public int wolneMiejsca = 0;
    private int zmienna = 0;

    public int maxDepth = 0;

    public int najmniejsza = 1100;
    public int najwieksza = -1100;
    private int tempWar = 0;
    private int tempWarNajw = 0;

    public bool przekazujemy = false;
    public bool znalazlemNajm = false;
    public bool znalazlemNajw = false;
    public int ileDzieciZrodzilem = 0;
    public int ileDzieciStracilem = 0;
    public bool ZwycieskaGracz = false;
    public bool ZwycieskaBot = false;
    private bool zwyc = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (wolneMiejsca >= 0)
        {
            if (i == 25) pobralemGre = true;
            else if (pobralemGre == false)
            {
                if (i == MiejsceGdzieMamWejsc)
                {
                    if (jestemMax == true) aktualnyStanGry[MiejsceGdzieMamWejsc] = 1;
                    if (jestemMin == true) aktualnyStanGry[MiejsceGdzieMamWejsc] = 2;
                }
                else
                {
                    if (jestemRootem == true)
                    {

                        aktualnyStanGry[i] = ojciec.GetComponent<MainMinMax>().StanGry[i];

                    }
                    else
                    {
                        aktualnyStanGry[i] = ojciec.GetComponent<MinMax>().aktualnyStanGry[i];

                    }
                }
                i++;
            }

            if (zwyc == false)
            {
                //zliczanie mojawartosc
                if (wolneMiejsca >= 0)
                {
                    if (pobralemGre == true && zliczylem == false)
                    {

                        if (j < 25)
                        {
                            //zliczanie wartosci gry

                            //sprawdzanie X
                            if (aktualnyStanGry[j] == 2 && zwyc == false)
                            {
                                if (j != 0 && j != 4 && j != 20 && j != 24)
                                {
                                    //poziomo
                                    if (j != 5 && j != 10 && j != 15 && j != 9 && j != 14 && j != 19)
                                    {
                                        if (aktualnyStanGry[j - 1] == 2) mojaWartosc -= 4;
                                        if (aktualnyStanGry[j + 1] == 2) mojaWartosc -= 4;
                                        if (aktualnyStanGry[j - 1] == 2 && aktualnyStanGry[j + 1] == 2) { mojaWartosc = -1000; zliczylem = true; ZwycieskaBot = true; zwyc = true; }
                                    }

                                    //pion
                                    if (j != 1 && j != 2 && j != 3 && j != 21 && j != 22 && j != 23)
                                    {
                                        if (aktualnyStanGry[j - 5] == 2) mojaWartosc -= 4;
                                        if (aktualnyStanGry[j + 5] == 2) mojaWartosc -= 4;
                                        if (aktualnyStanGry[j + 5] == 2 && aktualnyStanGry[j - 5] == 2) { mojaWartosc = -1000; zliczylem = true; ZwycieskaBot = true; zwyc = true; }
                                    }

                                    //skos
                                    if (j != 5 && j != 10 && j != 15 && j != 9 && j != 14 && j != 19 && j != 1 && j != 2 && j != 3 && j != 21 && j != 22 && j != 23)
                                    {
                                        //skos 1
                                        if (aktualnyStanGry[j - 6] == 2) mojaWartosc -= 4;
                                        if (aktualnyStanGry[j + 6] == 2) mojaWartosc -= 4;
                                        if (aktualnyStanGry[j + 6] == 2 && aktualnyStanGry[j - 6] == 2) { mojaWartosc = -1000; zliczylem = true; ZwycieskaBot = true; zwyc = true; }

                                        //skok 2
                                        if (aktualnyStanGry[j - 4] == 2) mojaWartosc -= 4;
                                        if (aktualnyStanGry[j + 4] == 2) mojaWartosc -= 4;
                                        if (aktualnyStanGry[j + 4] == 2 && aktualnyStanGry[j - 4] == 2) { mojaWartosc = -1000; zliczylem = true; ZwycieskaBot = true; zwyc = true; }

                                    }

                                }
                                mojaWartosc -= 2;
                            }

                            //Sprawdzanie O
                            if (aktualnyStanGry[j] == 1 && zwyc == false)
                            {
                                if (j != 0 && j != 4 && j != 20 && j != 24)
                                {
                                    //poziomo
                                    if (j != 5 && j != 10 && j != 15 && j != 9 && j != 14 && j != 19)
                                    {
                                        if (aktualnyStanGry[j - 1] == 1) mojaWartosc += 4;
                                        if (aktualnyStanGry[j + 1] == 1) mojaWartosc += 4;
                                        if (aktualnyStanGry[j - 1] == 1 && aktualnyStanGry[j + 1] == 1) { mojaWartosc = 1000; zliczylem = true; ZwycieskaGracz = true; zwyc = true; }
                                    }

                                    //pion
                                    if (j != 1 && j != 2 && j != 3 && j != 21 && j != 22 && j != 23)
                                    {
                                        if (aktualnyStanGry[j - 5] == 1) mojaWartosc += 4;
                                        if (aktualnyStanGry[j + 5] == 1) mojaWartosc += 4;
                                        if (aktualnyStanGry[j + 5] == 1 && aktualnyStanGry[j - 5] == 1) { mojaWartosc = 1000; zliczylem = true; ZwycieskaGracz = true; zwyc = true; }
                                    }

                                    //skos
                                    if (j != 5 && j != 10 && j != 15 && j != 9 && j != 14 && j != 19 && j != 1 && j != 2 && j != 3 && j != 21 && j != 22 && j != 23)
                                    {
                                        //skos 1
                                        if (aktualnyStanGry[j - 6] == 1) mojaWartosc += 4;
                                        if (aktualnyStanGry[j + 6] == 1) mojaWartosc += 4;
                                        if (aktualnyStanGry[j + 6] == 1 && aktualnyStanGry[j - 6] == 1) { mojaWartosc = 1000; zliczylem = true; ZwycieskaGracz = true; zwyc = true; }

                                        //skok 2
                                        if (aktualnyStanGry[j - 4] == 1) mojaWartosc += 4;
                                        if (aktualnyStanGry[j + 4] == 1) mojaWartosc += 4;
                                        if (aktualnyStanGry[j + 4] == 1 && aktualnyStanGry[j - 4] == 1) { mojaWartosc = 1000; zliczylem = true; ZwycieskaGracz = true; zwyc = true; }

                                    }
                                }
                                mojaWartosc += 2;
                            }

                            j++;
                        }
                        else
                        {
                            zliczylem = true;
                        }

                    }
                }
            }

            if (zwyc == false)
            {
                //tworz dzieci gdy sa jeszcze wolne miesjca
                if (wolneMiejsca > 0)
                {
                    if (pobralemGre == true && stworzylemdzieci == false)
                    {
                        if (zmienna < 25)
                        {
                            if (aktualnyStanGry[zmienna] == 0)
                            {
                                if (jestemMin == true) main.nowaWersja(zmienna, wolneMiejsca, false, this.gameObject, glebokosc + 1, false, 0);
                                if (jestemMax == true) main.nowaWersja(zmienna, wolneMiejsca, true, this.gameObject, glebokosc + 1, false, 0);
                                ileDzieciZrodzilem++;
                            }
                            zmienna++;
                        }
                        else
                        {
                            stworzylemdzieci = true;
                        }
                    }
                }

                if (wolneMiejsca == 0)
                {

                    if (zliczylem == true)
                    {
                        PrzekazDalej(mojaWartosc);
                    }
                }

            }


        }// - if wolnemiejsca == 0



        //if (ileDzieciStracilem == ileDzieciZrodzilem) przekazujemy = true;
        if (zwyc == false)
        {
            if (przekazujemy == true)
            {
                //znajdowanie najmniejszego
                if (tempWar < 25)
                {
                    if (wartosci[tempWar] < najmniejsza)
                    {

                        if (miejsca[tempWar] != -1 && wartosci[tempWar] != 0) najmniejsza = wartosci[tempWar];

                    }
                    if (wartosci[tempWar] > najwieksza)
                    {

                        if (miejsca[tempWar] != -1 && wartosci[tempWar] != 0) najwieksza = wartosci[tempWar];

                    }
                    tempWar++;
                }
                else
                {
                    znalazlemNajm = true;
                }

                //znajdowanie najwiekszego
                if (tempWarNajw < 25)
                {
                    if (wartosci[tempWarNajw] > najwieksza)
                    {

                        if (wartosci[tempWarNajw] != -1 && wartosci[tempWarNajw] != 0) najwieksza = wartosci[tempWarNajw];

                    }
                    tempWarNajw++;
                }
                else
                {
                    znalazlemNajw = true;
                }

                if (znalazlemNajm == true && znalazlemNajw == true)
                {
                    //Debug.Log("najMNIEJSZA " + najmniejsza + " Dla: " + wolneMiejsca + "MinMax: " + jestemMin);
                    //Debug.Log("najWIEKSZA " + najwieksza + " Dla: " + wolneMiejsca + "MinMax: " + jestemMin);
                    if (jestemMin == true)
                    {
                        PrzekazDalej(najmniejsza);
                    }
                    if (jestemMax == true)
                    {
                        PrzekazDalej(najwieksza);
                    }
                }
            }
        }

        if (zwyc == true)
        {
            if (ZwycieskaBot == true)
            {
                Victory(-1000);
            }
            if (ZwycieskaGracz == true)
            {
                Victory(1000);
            }
        }


    }//-update



    public void MiniMax()
    {
        if (tempWar < 25)
        {
            if (wartosci[tempWar] < najmniejsza && miejsca[tempWar] != -1) najmniejsza = wartosci[tempWar];
            if (wartosci[tempWar] > najwieksza && miejsca[tempWar] != -1) najwieksza = wartosci[tempWar];
            tempWar++;
        }
        else
        {
            if (jestemMin == true)
            {
                //if(jestemRootem == false) ojciec.GetComponent<MinMax>().mojaWartosc = najmniejsza;
                PrzekazDalej(mojaWartosc);
            }
            if (jestemMax == true)
            {
                //if (jestemRootem == false) ojciec.GetComponent<MinMax>().mojaWartosc = najwieksza;
                PrzekazDalej(mojaWartosc);
            }
        }


    }

    //to tylko jak jest glebokosc == 0
    public void PrzekazDalej(int warDoWstaw)
    {
        if (jestemRootem == false)
        {
            ojciec.GetComponent<MinMax>().miejsca[MiejsceGdzieMamWejsc] = MiejsceGdzieMamWejsc;
            ojciec.GetComponent<MinMax>().wartosci[MiejsceGdzieMamWejsc] = warDoWstaw;
            ojciec.GetComponent<MinMax>().ileDzieciStracilem++;
            ojciec.GetComponent<MinMax>().przekazujemy = true;
            Destroy(gameObject);
        }
        else
        {
            ojciec.GetComponent<MainMinMax>().miejsca[MiejsceGdzieMamWejsc] = MiejsceGdzieMamWejsc;
            ojciec.GetComponent<MainMinMax>().wartosci[MiejsceGdzieMamWejsc] = warDoWstaw;
            ojciec.GetComponent<MainMinMax>().ileRootow--;
            ojciec.GetComponent<MainMinMax>().wstawiam = true;
            Destroy(gameObject);
        }

    }


    public void Victory(int warDoWstaw)
    {
        if (jestemRootem == false)
        {
            ojciec.GetComponent<MinMax>().miejsca[MiejsceGdzieMamWejsc] = MiejsceGdzieMamWejsc;
            ojciec.GetComponent<MinMax>().wartosci[MiejsceGdzieMamWejsc] = warDoWstaw;
            ojciec.GetComponent<MinMax>().ileDzieciStracilem++;
            Destroy(gameObject);
        }
        else
        {
            ojciec.GetComponent<MainMinMax>().miejsca[MiejsceGdzieMamWejsc] = MiejsceGdzieMamWejsc;
            ojciec.GetComponent<MainMinMax>().wartosci[MiejsceGdzieMamWejsc] = warDoWstaw;
            ojciec.GetComponent<MainMinMax>().ileRootow--;
            ojciec.GetComponent<MainMinMax>().wstawiam = true;
            Destroy(gameObject);
        }
    }

}



