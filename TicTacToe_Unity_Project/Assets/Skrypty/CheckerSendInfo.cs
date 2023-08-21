using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckerSendInfo : MonoBehaviour
{
    public CheckNeigbours wlasciciel;
    public bool JestemPoz;
    public bool JestemPion;
    public bool JestemUkosLP;
    public bool JestemUkosPL;
    public bool SprawdzamCircle = false;
    public bool SprawdzamCross = false;
    public GameObject particleCirlce;
    public GameObject particleCross;


    private void OnTriggerStay(Collider other)
    {
        if(SprawdzamCircle == true)
        {
            if (other.gameObject.CompareTag("Circle"))
            {
                if (JestemPoz == true) other.GetComponent<CheckNeigbours>().ileSasiadowPoz++;
                if (JestemPion == true) other.GetComponent<CheckNeigbours>().ileSasiadowPion++;
                if (JestemUkosLP == true) other.GetComponent<CheckNeigbours>().ileSasiadowUkosLP++;
                if (JestemUkosPL == true) other.GetComponent<CheckNeigbours>().ileSasiadowUkosPL++;
                GameObject puffObj = Instantiate(particleCirlce, transform.position, Quaternion.identity);
                puffObj.SetActive(true);
                Destroy(gameObject);
            }
        }

        if(SprawdzamCross == true)
        {
            if (other.gameObject.CompareTag("Cross"))
            {
                if (JestemPoz == true) other.GetComponent<CheckNeigbours>().ileSasiadowPoz++;
                if (JestemPion == true) other.GetComponent<CheckNeigbours>().ileSasiadowPion++;
                if (JestemUkosLP == true) other.GetComponent<CheckNeigbours>().ileSasiadowUkosLP++;
                if (JestemUkosPL == true) other.GetComponent<CheckNeigbours>().ileSasiadowUkosPL++;
                GameObject puffObj = Instantiate(particleCross, transform.position, Quaternion.identity);
                puffObj.SetActive(true);
                Destroy(gameObject);
            }
        }

    }

}
