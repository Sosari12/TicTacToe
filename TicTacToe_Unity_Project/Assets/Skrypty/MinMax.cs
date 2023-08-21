using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinMax : MonoBehaviour
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
    public int mojaWartoscX = 0;
    public int mojaWartoscO = 0;
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
    public bool znalazlemNaj = false;
    public int ileDzieciZrodzilem = 0;
    public int ileDzieciStracilem = 0;
    public bool ZwycieskaGracz = false;
    public bool ZwycieskaBot = false;
    private bool zwyc = false;
    public int maxGlebokosc = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /// ----             POBIERANIE GRY         ---
        if (i < 25)
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
        else
        {
            pobralemGre = true;
        }


        /// ---             ZLICZANIE WARTOSCI      ---
        if (wolneMiejsca >= 0)
        {
            if (pobralemGre == true && zliczylem == false)
            {

                if (j < 25)
                {
                    //zliczanie wartosci gry

                    /// ===             sprawdzanie X           ===
                    if (aktualnyStanGry[j] == 2)
                    {
                        if(mojaWartoscX == 0)mojaWartoscX = -2;
                        if (j != 0 && j != 4 && j != 20 && j != 24)
                        {
                            //poziomo
                            if (j != 5 && j != 10 && j != 15 && j != 9 && j != 14 && j != 19)
                            {
                                if (aktualnyStanGry[j - 1] == 0 && aktualnyStanGry[j + 1] == 0 && mojaWartoscX > -6) mojaWartoscX = -4;
                                if (aktualnyStanGry[j - 1] == 2 && aktualnyStanGry[j + 1] == 0) mojaWartoscX = -6;
                                if (aktualnyStanGry[j + 1] == 2 && aktualnyStanGry[j - 1] == 0) mojaWartoscX = -6;
                                if (aktualnyStanGry[j - 1] == 2 && aktualnyStanGry[j + 1] == 2) { mojaWartosc = -1000; zliczylem = true; ZwycieskaBot = true; zwyc = true; Debug.Log("POZIOMO BOT"); }
                            }

                            //pion
                            if (j != 1 && j != 2 && j != 3 && j != 21 && j != 22 && j != 23)
                            {
                                if (aktualnyStanGry[j - 5] == 0 && aktualnyStanGry[j + 5] == 0 && mojaWartoscX > -6) mojaWartoscX = -4;
                                if (aktualnyStanGry[j - 5] == 2 && aktualnyStanGry[j + 5] == 0) mojaWartoscX = -6;
                                if (aktualnyStanGry[j + 5] == 2 && aktualnyStanGry[j - 5] == 0) mojaWartoscX = -6;
                                if (aktualnyStanGry[j + 5] == 2 && aktualnyStanGry[j - 5] == 2) { mojaWartosc = -1000; zliczylem = true; ZwycieskaBot = true; zwyc = true; Debug.Log("PION BOT"); }
                            }

                            //skos
                            if (j != 5 && j != 10 && j != 15 && j != 9 && j != 14 && j != 19 && j != 1 && j != 2 && j != 3 && j != 21 && j != 22 && j != 23)
                            {
                                //skos 1
                                if (aktualnyStanGry[j - 6] == 0 && aktualnyStanGry[j + 6] == 0 && mojaWartoscX > -6) mojaWartoscX = -4;
                                if (aktualnyStanGry[j - 6] == 2 && aktualnyStanGry[j + 6] == 0) mojaWartoscX = -6;
                                if (aktualnyStanGry[j + 6] == 2 && aktualnyStanGry[j - 6] == 0) mojaWartoscX = -6;
                                if (aktualnyStanGry[j + 6] == 2 && aktualnyStanGry[j - 6] == 2) { mojaWartosc = -1000; zliczylem = true; ZwycieskaBot = true; zwyc = true; Debug.Log("SKOS BOT"); }

                                //skok 2
                                if (aktualnyStanGry[j - 4] == 0 && aktualnyStanGry[j + 4] == 0 && mojaWartoscX > -6) mojaWartoscX = -4;
                                if (aktualnyStanGry[j - 4] == 2 && aktualnyStanGry[j + 4] == 0) mojaWartoscX = -6;
                                if (aktualnyStanGry[j + 4] == 2 && aktualnyStanGry[j - 4] == 0) mojaWartoscX = -6;
                                if (aktualnyStanGry[j + 4] == 2 && aktualnyStanGry[j - 4] == 2) { mojaWartosc = -1000; zliczylem = true; ZwycieskaBot = true; zwyc = true; Debug.Log("SKOS BOT"); }

                            }

                        }

                        //poziomo 2a
                        if(j != 0 && j != 1 && j != 5  && j != 6 && j != 10 && j != 11 && j != 15 && j != 16 && j != 20 && j != 21)
                        {
                            //TUTAJ I DLA "O" DODAJ JESZCZE GDY JEST XX- LUB 00- I TAK DALEJ
                            if (aktualnyStanGry[j - 2] == 0 && aktualnyStanGry[j - 1] == 0 && mojaWartoscX > -6) mojaWartoscX = -4;
                            if (aktualnyStanGry[j - 2] == 0 && aktualnyStanGry[j - 1] == 2) mojaWartoscX = -6;
                            if (aktualnyStanGry[j - 2] == 2 && aktualnyStanGry[j - 1] == 0) mojaWartoscX = -6;
                            if (aktualnyStanGry[j - 2] == 2 && aktualnyStanGry[j - 1] == 2) { mojaWartosc = -1000; zliczylem = true; ZwycieskaBot = true; zwyc = true; Debug.Log("POZIOM BOT"); }
                        }
                        //poziomo 2b
                        if (j != 3 && j != 4 && j != 8 && j != 9 && j != 13 && j != 14 && j != 18 && j != 19 && j != 23 && j != 24)
                        {
                            if (aktualnyStanGry[j + 2] == 0 && aktualnyStanGry[j + 1] == 0 && mojaWartoscX > -6) mojaWartoscX = -4;
                            if (aktualnyStanGry[j + 2] == 0 && aktualnyStanGry[j + 1] == 2) mojaWartoscX = -6;
                            if (aktualnyStanGry[j + 2] == 2 && aktualnyStanGry[j + 1] == 0) mojaWartoscX = -6;
                            if (aktualnyStanGry[j + 2] == 2 && aktualnyStanGry[j + 1] == 2) { mojaWartosc = -1000; zliczylem = true; ZwycieskaBot = true; zwyc = true; Debug.Log("POZIOM BOT"); }
                        }

                        //pion 2a
                        if (j != 0 && j != 1 && j != 2 && j != 3 && j != 4 && j != 5 && j != 6 && j != 7 && j != 8 && j != 9)
                        {
                            if (aktualnyStanGry[j - 10] == 0 && aktualnyStanGry[j - 5] == 0 && mojaWartoscX > -6) mojaWartoscX = -4;
                            if (aktualnyStanGry[j - 10] == 0 && aktualnyStanGry[j - 5] == 2) mojaWartoscX = -6;
                            if (aktualnyStanGry[j - 10] == 2 && aktualnyStanGry[j - 5] == 0) mojaWartoscX = -6;
                            if (aktualnyStanGry[j - 10] == 2 && aktualnyStanGry[j - 5] == 2) { mojaWartosc = -1000; zliczylem = true; ZwycieskaBot = true; zwyc = true; Debug.Log("PION BOT"); }

                        }

                        //pion 2b
                        if (j != 15 && j != 16 && j != 17 && j != 18 && j != 19 && j != 20 && j != 21 && j != 22 && j != 23 && j != 24)
                        {
                            if (aktualnyStanGry[j + 10] == 0 && aktualnyStanGry[j + 5] == 0 && mojaWartoscX > -6) mojaWartoscX = -4;
                            if (aktualnyStanGry[j + 10] == 0 && aktualnyStanGry[j + 5] == 2) mojaWartoscX = -6;
                            if (aktualnyStanGry[j + 10] == 2 && aktualnyStanGry[j + 5] == 0) mojaWartoscX = -6;
                            if (aktualnyStanGry[j + 10] == 2 && aktualnyStanGry[j + 5] == 2) { mojaWartosc = -1000; zliczylem = true; ZwycieskaBot = true; zwyc = true; Debug.Log("PION BOT"); }

                        }

                        //skos 3a
                        if (j != 3 && j != 4 && j != 8 && j != 9 && j != 13 && j != 14 && j != 15 && j != 16 && j != 17 && j != 18 && j != 19 && j != 20 && j != 21 && j != 22 && j != 23 && j != 24)
                        {
                            if (aktualnyStanGry[j + 12] == 0 && aktualnyStanGry[j + 6] == 0 && mojaWartoscX > -6) mojaWartoscX = -4;
                            if (aktualnyStanGry[j + 12] == 0 && aktualnyStanGry[j + 6] == 2) mojaWartoscX = -6;
                            if (aktualnyStanGry[j + 12] == 2 && aktualnyStanGry[j + 6] == 0) mojaWartoscX = -6;
                            if (aktualnyStanGry[j + 12] == 2 && aktualnyStanGry[j + 6] == 2) { mojaWartosc = -1000; zliczylem = true; ZwycieskaBot = true; zwyc = true; Debug.Log("SKOS BOT"); }
                        }

                        //skos 3b
                        if (j != 0 && j != 1 && j != 2 && j != 3 && j != 4 && j != 5 && j != 6 && j != 7 && j != 8 && j != 9 && j != 10 && j != 11 && j != 15 && j != 16 && j != 20 && j != 21)
                        {
                            if (aktualnyStanGry[j - 12] == 0 && aktualnyStanGry[j - 6] == 0 && mojaWartoscX > -6) mojaWartoscX = -4;
                            if (aktualnyStanGry[j - 12] == 0 && aktualnyStanGry[j - 6] == 2) mojaWartoscX = -6;
                            if (aktualnyStanGry[j - 12] == 2 && aktualnyStanGry[j - 6] == 0) mojaWartoscX = -6;
                            if (aktualnyStanGry[j - 12] == 2 && aktualnyStanGry[j - 6] == 2) { mojaWartosc = -1000; zliczylem = true; ZwycieskaBot = true; zwyc = true; Debug.Log("SKOS BOT"); }
                        }

                        //skos 4a
                        if (j != 0 && j != 1 && j != 2 && j != 3 && j != 4 && j != 5 && j != 6 && j != 7 && j != 8 && j != 9 && j != 13 && j != 14 && j != 18 && j != 19 && j != 23 && j != 24)
                        {
                            if (aktualnyStanGry[j - 8] == 0 && aktualnyStanGry[j - 4] == 0 && mojaWartoscX > -6) mojaWartoscX = -4;
                            if (aktualnyStanGry[j - 8] == 0 && aktualnyStanGry[j - 4] == 2) mojaWartoscX = -6;
                            if (aktualnyStanGry[j - 8] == 2 && aktualnyStanGry[j - 4] == 0) mojaWartoscX = -6;
                            if (aktualnyStanGry[j - 8] == 2 && aktualnyStanGry[j - 4] == 2) { mojaWartosc = -1000; zliczylem = true; ZwycieskaBot = true; zwyc = true; Debug.Log("SKOS BOT"); }

                        }
                        //skos 4b
                        if(j != 0 && j != 1 && j != 5 && j != 6 && j != 10 && j != 11 && j != 15 && j != 16 && j != 17 && j != 18 && j != 19 && j != 20 && j != 21 && j != 22 && j != 23 && j != 24)
                        {
                            if (aktualnyStanGry[j + 8] == 0 && aktualnyStanGry[j + 4] == 0 && mojaWartoscX > -6) mojaWartoscX = -4;
                            if (aktualnyStanGry[j + 8] == 0 && aktualnyStanGry[j + 4] == 2) mojaWartoscX = -6;
                            if (aktualnyStanGry[j + 8] == 2 && aktualnyStanGry[j + 4] == 0) mojaWartoscX = -6;
                            if (aktualnyStanGry[j + 8] == 2 && aktualnyStanGry[j + 4] == 2) { mojaWartosc = -1000; zliczylem = true; ZwycieskaBot = true; zwyc = true; Debug.Log("SKOS BOT"); }

                        }
                    }

                    /// ===             Sprawdzanie O           ===
                    if (aktualnyStanGry[j] == 1)
                    {
                        if(mojaWartoscO == 0)mojaWartoscO = 2;
                        if (j != 0 && j != 4 && j != 20 && j != 24)
                        {
                            //poziomo
                            if (j != 5 && j != 10 && j != 15 && j != 9 && j != 14 && j != 19)
                            {
                                if (aktualnyStanGry[j - 1] == 0 && aktualnyStanGry[j + 1] == 0 && mojaWartoscO < 6) mojaWartoscO = 4;
                                if (aktualnyStanGry[j - 1] == 1 && aktualnyStanGry[j + 1] == 0) mojaWartoscO = 6;
                                if (aktualnyStanGry[j + 1] == 1 && aktualnyStanGry[j - 1] == 0) mojaWartoscO = 6;
                                if (aktualnyStanGry[j - 1] == 1 && aktualnyStanGry[j + 1] == 1) { mojaWartosc = 1000; zliczylem = true; ZwycieskaGracz = true; zwyc = true; Debug.Log("POZIOMO GRACZ"); }
                            }

                            //pion
                            if (j != 1 && j != 2 && j != 3 && j != 21 && j != 22 && j != 23)
                            {
                                if (aktualnyStanGry[j - 5] == 0 && aktualnyStanGry[j + 5] == 0 && mojaWartoscO < 6) mojaWartoscO = 4;
                                if (aktualnyStanGry[j - 5] == 1 && aktualnyStanGry[j + 5] == 0) mojaWartoscO = 6;
                                if (aktualnyStanGry[j + 5] == 1 && aktualnyStanGry[j - 5] == 0) mojaWartoscO = 6;
                                if (aktualnyStanGry[j + 5] == 1 && aktualnyStanGry[j - 5] == 1) { mojaWartosc = 1000; zliczylem = true; ZwycieskaGracz = true; zwyc = true; Debug.Log("PION GRACZ"); }
                            }

                            //skos
                            if (j != 5 && j != 10 && j != 15 && j != 9 && j != 14 && j != 19 && j != 1 && j != 2 && j != 3 && j != 21 && j != 22 && j != 23)
                            {
                                //skos 1
                                if (aktualnyStanGry[j - 6] == 0 && aktualnyStanGry[j + 6] == 0 && mojaWartoscO < 6) mojaWartoscO = 4;
                                if (aktualnyStanGry[j - 6] == 1 && aktualnyStanGry[j + 6] == 0) mojaWartoscO = 6;
                                if (aktualnyStanGry[j + 6] == 1 && aktualnyStanGry[j - 6] == 0) mojaWartoscO = 6;
                                if (aktualnyStanGry[j + 6] == 1 && aktualnyStanGry[j - 6] == 1) { mojaWartosc = 1000; zliczylem = true; ZwycieskaGracz = true; zwyc = true; Debug.Log("SKOS GRACZ"); }

                                //skok 2
                                if (aktualnyStanGry[j - 4] == 1 && aktualnyStanGry[j + 4] == 0 && mojaWartoscO < 6) mojaWartoscO = 4;
                                if (aktualnyStanGry[j - 4] == 1 && aktualnyStanGry[j + 4] == 0) mojaWartoscO = 6;
                                if (aktualnyStanGry[j + 4] == 1 && aktualnyStanGry[j - 4] == 0) mojaWartoscO = 6;
                                if (aktualnyStanGry[j + 4] == 1 && aktualnyStanGry[j - 4] == 1) { mojaWartosc = 1000; zliczylem = true; ZwycieskaGracz = true; zwyc = true; Debug.Log("SKOS GRACZ"); }

                            }
                        }

                        //poziomo 2a
                        if (j != 0 && j != 1 && j != 5 && j != 6 && j != 10 && j != 11 && j != 15 && j != 16 && j != 20 && j != 21)
                        {
                            if (aktualnyStanGry[j - 2] == 0 && aktualnyStanGry[j - 1] == 0 && mojaWartoscO < 6) mojaWartoscO = 4;
                            if (aktualnyStanGry[j - 2] == 0 && aktualnyStanGry[j - 1] == 1) mojaWartoscO = 6;
                            if (aktualnyStanGry[j - 2] == 1 && aktualnyStanGry[j - 1] == 0) mojaWartoscO = 6;
                            if (aktualnyStanGry[j - 2] == 1 && aktualnyStanGry[j - 1] == 1) { mojaWartosc = 1000; zliczylem = true; ZwycieskaGracz = true; zwyc = true; Debug.Log("POZIOMO GRACZ"); }
                        }
                        //poziomo 2b
                        if (j != 3 && j != 4 && j != 8 && j != 9 && j != 13 && j != 14 && j != 18 && j != 19 && j != 23 && j != 24)
                        {
                            if (aktualnyStanGry[j + 2] == 0 && aktualnyStanGry[j + 1] == 0 && mojaWartoscO < 6) mojaWartoscO = 4;
                            if (aktualnyStanGry[j + 2] == 0 && aktualnyStanGry[j + 1] == 1) mojaWartoscO = 6;
                            if (aktualnyStanGry[j + 2] == 1 && aktualnyStanGry[j + 1] == 0) mojaWartoscO = 6;
                            if (aktualnyStanGry[j + 2] == 1 && aktualnyStanGry[j + 1] == 1) { mojaWartosc = 1000; zliczylem = true; ZwycieskaGracz = true; zwyc = true; Debug.Log("POZIOMO GRACZ"); }
                        }

                        //pion 2a
                        if (j != 0 && j != 1 && j != 2 && j != 3 && j != 4 && j != 5 && j != 6 && j != 7 && j != 8 && j != 9)
                        {
                            if (aktualnyStanGry[j - 10] == 0 && aktualnyStanGry[j - 5] == 0 && mojaWartoscO < 6) mojaWartoscO = 4;
                            if (aktualnyStanGry[j - 10] == 0 && aktualnyStanGry[j - 5] == 1) mojaWartoscO = 6;
                            if (aktualnyStanGry[j - 10] == 1 && aktualnyStanGry[j - 5] == 0) mojaWartoscO = 6;
                            if (aktualnyStanGry[j - 10] == 1 && aktualnyStanGry[j - 5] == 1) { mojaWartosc = 1000; zliczylem = true; ZwycieskaGracz = true; zwyc = true; Debug.Log("PION GRACZ"); }

                        }

                        //pion 2b
                        if (j != 15 && j != 16 && j != 17 && j != 18 && j != 19 && j != 20 && j != 21 && j != 22 && j != 23 && j != 24)
                        {
                            if (aktualnyStanGry[j + 10] == 0 && aktualnyStanGry[j + 5] == 0 && mojaWartoscO < 6) mojaWartoscO = 4;
                            if (aktualnyStanGry[j + 10] == 0 && aktualnyStanGry[j + 5] == 1) mojaWartoscO = 6;
                            if (aktualnyStanGry[j + 10] == 1 && aktualnyStanGry[j + 5] == 0) mojaWartoscO = 6;
                            if (aktualnyStanGry[j + 10] == 1 && aktualnyStanGry[j + 5] == 1) { mojaWartosc = 1000; zliczylem = true; ZwycieskaGracz = true; zwyc = true; Debug.Log("PION GRACZ"); }

                        }

                        //skos 3a
                        if (j != 3 && j != 4 && j != 8 && j != 9 && j != 13 && j != 14 && j != 15 && j != 16 && j != 17 && j != 18 && j != 19 && j != 20 && j != 21 && j != 22 && j != 23 && j != 24)
                        {
                            if (aktualnyStanGry[j + 12] == 0 && aktualnyStanGry[j + 6] == 0 && mojaWartoscO < 6) mojaWartoscO = 4;
                            if (aktualnyStanGry[j + 12] == 0 && aktualnyStanGry[j + 6] == 1) mojaWartoscO = 6;
                            if (aktualnyStanGry[j + 12] == 1 && aktualnyStanGry[j + 6] == 0) mojaWartoscO = 6;
                            if (aktualnyStanGry[j + 12] == 1 && aktualnyStanGry[j + 6] == 1) { mojaWartosc = 1000; zliczylem = true; ZwycieskaGracz = true; zwyc = true; Debug.Log("SKOS GRACZ"); }
                        }

                        //skos 3b
                        if (j != 0 && j != 1 && j != 2 && j != 3 && j != 4 && j != 5 && j != 6 && j != 7 && j != 8 && j != 9 && j != 10 && j != 11 && j != 15 && j != 16 && j != 20 && j != 21)
                        {
                            if (aktualnyStanGry[j - 12] == 0 && aktualnyStanGry[j - 6] == 0 && mojaWartoscO < 6) mojaWartoscO = 4;
                            if (aktualnyStanGry[j - 12] == 0 && aktualnyStanGry[j - 6] == 1) mojaWartoscO = 6;
                            if (aktualnyStanGry[j - 12] == 1 && aktualnyStanGry[j - 6] == 0) mojaWartoscO = 6;
                            if (aktualnyStanGry[j - 12] == 1 && aktualnyStanGry[j - 6] == 1) { mojaWartosc = 1000; zliczylem = true; ZwycieskaGracz = true; zwyc = true; Debug.Log("SKOS GRACZ"); }
                        }

                        //skos 4a
                        if (j != 0 && j != 1 && j != 2 && j != 3 && j != 4 && j != 5 && j != 6 && j != 7 && j != 8 && j != 9 && j != 13 && j != 14 && j != 18 && j != 19 && j != 23 && j != 24)
                        {
                            if (aktualnyStanGry[j - 8] == 0 && aktualnyStanGry[j - 4] == 0 && mojaWartoscO < 6) mojaWartoscO = 4;
                            if (aktualnyStanGry[j - 8] == 0 && aktualnyStanGry[j - 4] == 1) mojaWartoscO = 6;
                            if (aktualnyStanGry[j - 8] == 1 && aktualnyStanGry[j - 4] == 0) mojaWartoscO = 6;
                            if (aktualnyStanGry[j - 8] == 1 && aktualnyStanGry[j - 4] == 1) { mojaWartosc = 1000; zliczylem = true; ZwycieskaGracz = true; zwyc = true; Debug.Log("SKOS GRACZ"); }

                        }
                        //skos 4b
                        if (j != 0 && j != 1 && j != 5 && j != 6 && j != 10 && j != 11 && j != 15 && j != 16 && j != 17 && j != 18 && j != 19 && j != 20 && j != 21 && j != 22 && j != 23 && j != 24)
                        {
                            if (aktualnyStanGry[j + 8] == 0 && aktualnyStanGry[j + 4] == 0 && mojaWartoscO < 6) mojaWartoscO = 4;
                            if (aktualnyStanGry[j + 8] == 0 && aktualnyStanGry[j + 4] == 1) mojaWartoscO = 6;
                            if (aktualnyStanGry[j + 8] == 1 && aktualnyStanGry[j + 4] == 0) mojaWartoscO = 6;
                            if (aktualnyStanGry[j + 8] == 1 && aktualnyStanGry[j + 4] == 1) { mojaWartosc = 1000; zliczylem = true; ZwycieskaGracz = true; zwyc = true; Debug.Log("SKOS GRACZ"); }

                        }  
                    }

                    j++;
                }
                else
                {
                    if(zwyc == false)
                    {
                        Debug.Log("X = " + mojaWartoscX + " O = " + mojaWartoscO);
                        if (mojaWartoscO + mojaWartoscX == 0)
                        {
                            if (jestemMin == true)
                            {
                                if (mojaWartoscO == 4)
                                {
                                    mojaWartosc = -4;
                                }
                                if (mojaWartoscO == 6)
                                {
                                    mojaWartosc = mojaWartoscO;
                                }
                            }
                            else
                            {
                                if (mojaWartoscX == -4)
                                {
                                    mojaWartosc = 4;
                                }
                                if (mojaWartoscX == -6)
                                {
                                    mojaWartosc = mojaWartoscX;
                                }

                            }
                        }


                        if (mojaWartoscO + mojaWartoscX < 0) mojaWartosc = mojaWartoscX;
                        if (mojaWartoscO + mojaWartoscX > 0) mojaWartosc = mojaWartoscO;
                        //Debug.Log("Zliczylem wartosc: " + mojaWartosc)
                        zliczylem = true;
                    }
                    
                }

            }
        }


        ///---              OGRANICZENIE DO 3           ---
        if(zliczylem == true && glebokosc < maxGlebokosc)
        {
            ///---          ZWYCIESTWO          ---
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
            else
            {
                ///---            TWORZENIE DZIECI          ---
                if (wolneMiejsca > 0)
                {
                    if (pobralemGre == true && stworzylemdzieci == false && zliczylem == true)
                    {
                        if (zmienna < 25)
                        {
                            if (aktualnyStanGry[zmienna] == 0)
                            {
                                if (jestemMin == true) main.nowaWersja(zmienna, wolneMiejsca, false, this.gameObject, glebokosc, false, maxGlebokosc);
                                if (jestemMax == true) main.nowaWersja(zmienna, wolneMiejsca, true, this.gameObject, glebokosc, false, maxGlebokosc);
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

                ///---          PRZEKAZANIE DALEJ JAK JESTEM LISCIEM                ---
                if (wolneMiejsca == 0 && zliczylem == true)
                {
                    PrzekazDalej(mojaWartosc);
                }





                ///---          PRZEKAZYWANIE DALEJ I SPRAWDZANIE NAJM/NAJW         ---
                if (przekazujemy == true && ileDzieciStracilem == ileDzieciZrodzilem && wolneMiejsca > 0)
                {
                    //znajdowanie najmniejszego
                    if (tempWar < 25)
                    {
                        if (wartosci[tempWar] < najmniejsza && wartosci[tempWar] != -1)
                        {

                            if (miejsca[tempWar] != -1) najmniejsza = wartosci[tempWar];

                        }
                        if (wartosci[tempWar] > najwieksza && wartosci[tempWar] != -1)
                        {

                            if (miejsca[tempWar] != -1) najwieksza = wartosci[tempWar];

                        }
                        tempWar++;
                    }
                    else
                    {
                        Debug.Log("najMNIEJSZA " + najmniejsza + " Dla: " + wolneMiejsca + "MinMax: " + jestemMin + " Wolne: " + wolneMiejsca);
                        Debug.Log("najWIEKSZA " + najwieksza + " Dla: " + wolneMiejsca + "MinMax: " + jestemMin + " Wolne: " + wolneMiejsca);
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




            }//-zwyc
        }//-ograniczenie

        if (zliczylem == true && glebokosc >= maxGlebokosc)
        {
            PrzekazDalej(mojaWartosc);
        }











    }//-update

    
    //to tylko jak jest glebokosc == 0
    public void PrzekazDalej(int warDoWstaw)
    {
        if(jestemRootem == false)
        {
            ojciec.GetComponent<MinMax>().miejsca[MiejsceGdzieMamWejsc] = MiejsceGdzieMamWejsc;
            ojciec.GetComponent<MinMax>().wartosci[MiejsceGdzieMamWejsc] = warDoWstaw;
            ojciec.GetComponent<MinMax>().ileDzieciStracilem++;
            ojciec.GetComponent<MinMax>().przekazujemy = true;
            //Debug.Log("no win LISC: Wstawiam: " + warDoWstaw + " Dla wolnych: " + wolneMiejsca + " MinMax: " + jestemMin);

            //GameObject dzieckoObj = Instantiate(this.gameObject, transform.position, Quaternion.identity);
            //dzieckoObj.SetActive(false);

            Destroy(gameObject);
        }
        else
        {
            ojciec.GetComponent<MainMinMax>().miejsca[MiejsceGdzieMamWejsc] = MiejsceGdzieMamWejsc;
            ojciec.GetComponent<MainMinMax>().wartosci[MiejsceGdzieMamWejsc] = warDoWstaw;
            ojciec.GetComponent<MainMinMax>().ileRootow--;
            ojciec.GetComponent<MainMinMax>().wstawiam = true;
           // Debug.Log("no win ROOT: Wstawiam: " + warDoWstaw + " Dla wolnych: " + wolneMiejsca + " MinMax: " + jestemMin);

            //GameObject dzieckoObj = Instantiate(this.gameObject, transform.position, Quaternion.identity);
            //dzieckoObj.SetActive(false);

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
            ojciec.GetComponent<MinMax>().przekazujemy = true;
           // Debug.Log("win LISC: Wstawiam: " + warDoWstaw + " Dla wolnych: " + wolneMiejsca + " MinMax: " + jestemMin);

            //GameObject dzieckoObj = Instantiate(this.gameObject, transform.position, Quaternion.identity);
            //dzieckoObj.SetActive(false);

            Destroy(gameObject);
        }
        else
        {
            ojciec.GetComponent<MainMinMax>().miejsca[MiejsceGdzieMamWejsc] = MiejsceGdzieMamWejsc;
            ojciec.GetComponent<MainMinMax>().wartosci[MiejsceGdzieMamWejsc] = warDoWstaw;
            ojciec.GetComponent<MainMinMax>().ileRootow--;
            ojciec.GetComponent<MainMinMax>().wstawiam = true;

          //  Debug.Log("win ROOT: Wstawiam: " + warDoWstaw + " Dla wolnych: " + wolneMiejsca + " MinMax: " + jestemMin);
            
            //GameObject dzieckoObj = Instantiate(this.gameObject, transform.position, Quaternion.identity);
            //dzieckoObj.SetActive(false);

            Destroy(gameObject);
        }
    }
    
}//==end end==



