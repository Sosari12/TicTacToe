using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matryca : MonoBehaviour
{
    public int Tura = 0;

    public int wartosc;
    public int x =0, y = 0;

    public bool turaGracza;
    public bool TuraBota;
    public int dlugosc = 5;

    public GameObject crossAsset;
    public GameObject circleAsset;
    public GameObject znacznik;
    public GameObject lightBlue;
    public GameObject lightYellow;
    public Transform[] spawny;
    public int[] miejsca;
    public int miejsceSpawn = 0;
    public int[] ktoMaTrzy;
    public int[] EnemyktoMaTrzy;
    public int GraczPoints = 0;

    public int spr = 0;
    private int randBotPlace;
    public bool KoniecGry = false;
    public MasterScript Master;

    //public GameObject NoPlace;
    //public GameObject YesPlace;
    public BlockScript[] bloczek;
    public int[] trzyNaTrzy;
    public int[] czteryNaCztery;
    public int[] piecNaPiec;

    public int wariant = 0;
    public Animator[] bloczekAnim;

    public int iloscWolnychMiejsc = 0;
    public int maxIloscWolnychMiejsc = 0;
    private int randomTemp = 0;
    private int zablokowanoBloczki = 0;


    public MainMinMax Root;
    public int zmienna = 0;
    public bool pozwolenieNaWstawienie = false;
    public int najmniejsza = 0;
    public int XnaPlanszy = 0;
    public int maxGlebokosc = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (wariant == 0)
        {
            iloscWolnychMiejsc = 9;
            Root.iloscMiejsc = 9;
            maxIloscWolnychMiejsc = 9;
        }
        if (wariant == 1)
        {
            iloscWolnychMiejsc = 15;
            Root.iloscMiejsc = 15;
            maxIloscWolnychMiejsc = 15;
        }
        if (wariant == 2)
        {
            iloscWolnychMiejsc = 25;
            Root.iloscMiejsc = 25;
            maxIloscWolnychMiejsc = 25;
        }
    }

    // Update is called once per frame
    void Update()
    {
        znacznik.transform.position = new Vector3(spawny[miejsceSpawn].position.x, 1, spawny[miejsceSpawn].position.z);

        if(TuraBota == true)
        {
            lightYellow.GetComponent<Animator>().SetBool("Pojaw", true);
            lightYellow.GetComponent<Animator>().SetBool("Zniknij", false);
        }
        else
        {
            lightYellow.GetComponent<Animator>().SetBool("Pojaw", false);
            lightYellow.GetComponent<Animator>().SetBool("Zniknij", true);
        }

        if(turaGracza == true)
        {
            lightBlue.GetComponent<Animator>().SetBool("Pojaw", true);
            lightBlue.GetComponent<Animator>().SetBool("Zniknij", false);
        }
        else
        {
            lightBlue.GetComponent<Animator>().SetBool("Pojaw", false);
            lightBlue.GetComponent<Animator>().SetBool("Zniknij", true);
        }



        ///             ---TURA GRACZA---
        if(turaGracza == true)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                //substract 1 from [][y]
                if (y > 0)
                {
                    y--;
                    miejsceSpawn -= 5;
                }

            }else if (Input.GetKeyDown(KeyCode.S))
            {
                //add 1 to [][y]
                if(y < dlugosc - 1)
                {
                    y++;
                    miejsceSpawn += 5;
                }

            }else if (Input.GetKeyDown(KeyCode.A))
            {
                //substract 1 from [x][]
                if (x > 0)
                {
                    x--;
                    miejsceSpawn -= 1;
                }

            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                //add 1 to [x][]
                if (x < dlugosc - 1)
                {
                    x++;
                    miejsceSpawn += 1;
                }

            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                //potwierdzenie
                if (miejsca[miejsceSpawn] == 0)
                {
                    miejsca[miejsceSpawn] = 1;
                    GameObject circleObj = Instantiate(circleAsset, spawny[miejsceSpawn].position, Quaternion.identity);
                    circleObj.SetActive(true);
                    circleObj.GetComponent<CheckNeigbours>().mojeMiejsce = miejsceSpawn;
                    iloscWolnychMiejsc--;
                    Root.iloscMiejsc--;
                    Root.StanGry[miejsceSpawn] = 1;

                    turaGracza = false;
                    spr = 0;
                    randBotPlace = Random.Range(0, 24);
                    Tura++;

                }
            }
        }





        ///                 ---Sprawdzenie punktow---
        if(turaGracza == false && TuraBota == false && KoniecGry == false)
        {
            
            ///Sprawdzenie kto wygral
            if (spr < 24)
            {
                ///gdy gracz wygra
                if (ktoMaTrzy[spr] == 1)
                {
                    Master.GraczZdobylPunkt();
                    KoniecGry = true;
                    spr = 0;
                }
                else if(EnemyktoMaTrzy[spr] == 1)//grybot wygra
                {
                    ///gdy bot wygra
                    Master.EnemyZdobylPunkt();
                    spr = 0;
                    KoniecGry = true;
                }else if (iloscWolnychMiejsc == 0)
                {
                    Master.EnemyZdobylPunkt();
                    spr = 0;
                    KoniecGry = true;
                }


                if (KoniecGry == false)
                {
                     spr++;
                }

            }
            else
            {



                if (KoniecGry == false)
                {

                    if (Tura % 2 != 0) TuraBota = true;
                    if (Tura % 2 == 0) turaGracza = true;
                }
                spr = 0;
            }

        }




        ///                 ---proces resetu gry
        if (KoniecGry == true)
        {
            if(spr <= 24)
            {
                if (Master.GraczPoints == 3) wariant = 1;
                if (Master.GraczPoints == 6) wariant = 0;
                if (wariant == 0)
                {
                    bloczek[spr].mojaWartosc = trzyNaTrzy[spr];
                    miejsca[spr] = trzyNaTrzy[spr];
                    Root.StanGry[spr] = trzyNaTrzy[spr];
                    iloscWolnychMiejsc = 9;
                    Root.iloscMiejsc = 9;
                    maxIloscWolnychMiejsc = 9;
                    
                }
                else if (wariant == 1)
                {
                    randomTemp = Random.Range(0, 25);
                    bloczek[spr].mojaWartosc = czteryNaCztery[spr];
                    miejsca[spr] = czteryNaCztery[spr];
                    Root.StanGry[spr] = czteryNaCztery[spr];
                    iloscWolnychMiejsc = 15;
                    Root.iloscMiejsc = 15;
                    maxIloscWolnychMiejsc = 15;

                    if (spr > 23 && miejsca[randomTemp] == 0)
                    {
                        zablokowanoBloczki++;
                        bloczek[randomTemp].mojaWartosc = 3;
                        miejsca[randomTemp] = 3;
                        Root.StanGry[randomTemp] = 3;
                        
                    }
                   

                }
                else if (wariant == 2)
                {
                    randomTemp = Random.Range(0, 25);
                    bloczek[spr].mojaWartosc = piecNaPiec[spr];
                    miejsca[spr] = piecNaPiec[spr];
                    Root.StanGry[spr] = piecNaPiec[spr];
                    iloscWolnychMiejsc = 25;
                    Root.iloscMiejsc = 25;
                    maxIloscWolnychMiejsc = 25;
                    
                    if (spr > 20 && miejsca[randomTemp] == 0)
                    {
                        zablokowanoBloczki++;
                        bloczek[randomTemp].mojaWartosc = 3;
                        miejsca[randomTemp] = 3;
                        Root.StanGry[randomTemp] = 3;
                        
                    }
                    
                }
                ktoMaTrzy[spr] = 0;
                EnemyktoMaTrzy[spr] = 0;
                spr++;
            }
            else
            {
                //funkcja z master ktora wywoluje animacje robota i mapy a z tamtat wysyla info do 
                if (wariant == 1)
                {
                    iloscWolnychMiejsc = 15 - zablokowanoBloczki;
                    maxIloscWolnychMiejsc = 15 - zablokowanoBloczki;
                    Root.iloscMiejsc = 15 - zablokowanoBloczki;
                }
                if (wariant == 2)
                {
                    iloscWolnychMiejsc = 25 - zablokowanoBloczki;
                    maxIloscWolnychMiejsc = 25 - zablokowanoBloczki;
                    Root.iloscMiejsc = 25 - zablokowanoBloczki;
                }

                zablokowanoBloczki = 0;
                spr = 0;
                randBotPlace = Random.Range(0, 24);
            }
        }



        ///                     ---TURA BOTA---
        if(TuraBota == true)
        {

            

            if (iloscWolnychMiejsc == maxIloscWolnychMiejsc || iloscWolnychMiejsc + 1 == maxIloscWolnychMiejsc)
            {
                Debug.Log("LOS LOS LOS LOS");
                ///Narazie w losowe wolne miejsce
                if (miejsca[randBotPlace] != 0)
                {
                    randBotPlace = Random.Range(0, 24);

                }
                else
                {
                    postawDlaBota(randBotPlace);
                }
            }
            else
            {

                if (zmienna < 25)
                {
                    if (miejsca[zmienna] == 0)
                    {
                        Root.nowaWersja(zmienna, iloscWolnychMiejsc, true, Root.gameObject, 0, true, maxGlebokosc);

                    }
                    zmienna++;
                }

                if (pozwolenieNaWstawienie == true)
                {
                    postawDlaBota(najmniejsza);
                }
            }


        }


    }

    public void procesResetuGry()
    {
        if (Tura % 2 != 0) TuraBota = true;
        if (Tura % 2 == 0) turaGracza = true;
        KoniecGry = false;
    }


    public void postawDlaBota(int place)
    {
        miejsca[place] = 2;
        Root.StanGry[place] = 2;
        GameObject crossObj = Instantiate(crossAsset, spawny[place].position, Quaternion.identity);
        //GameObject crossObj = Instantiate(crossAsset, spawny[randBotPlace].position, Quaternion.identity);
        crossObj.SetActive(true);
        iloscWolnychMiejsc--;
        Root.iloscMiejsc--;
        crossObj.GetComponent<CheckNeigbours>().mojeMiejsce = place;
        //crossObj.GetComponent<CheckNeigbours>().mojeMiejsce = randBotPlace;
        pozwolenieNaWstawienie = false;
        spr = 0;
        najmniejsza = 0;
        zmienna = 0;
        TuraBota = false;
        Tura++;
    }

}
