using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallChanger : MonoBehaviour
{
    public bool rotowalem = false;
    private int randomNumber;
    public GameObject set1;
    public GameObject set2;


    // Start is called before the first frame update
    void Start()
    {
        randomNumber = Random.Range(0, 5);
        if(randomNumber == 0)
        {
            set1.SetActive(true);
            //no rotate
        }
        else if(randomNumber == 1)
        {
            set1.SetActive(true);
            transform.rotation = Quaternion.Euler(0, 45, 0);
        }
        else if(randomNumber == 2)
        {
            set1.SetActive(true);
            transform.rotation = Quaternion.Euler(0, -45, 0);

        }
        else if(randomNumber == 3)
        {
            set2.SetActive(true);
            transform.rotation = Quaternion.Euler(0, 90, 0);

        }
        else if(randomNumber == 4)
        {
            set2.SetActive(true);
            transform.rotation = Quaternion.Euler(0, -90, 0);

        }
    }


}
