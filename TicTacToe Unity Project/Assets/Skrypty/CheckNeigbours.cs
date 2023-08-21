using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckNeigbours : MonoBehaviour
{
    public GameObject[] checkeryPoziomo;
    public GameObject[] checkeryPion;
    public GameObject[] checkeryUkosLP;
    public GameObject[] checkeryUkosPL;

    public Matryca matrix;
    public int mojeMiejsce;
    public int ileSasiadowPoz = 1;
    public int ileSasiadowPion = 1;
    public int ileSasiadowUkosLP = 1;
    public int ileSasiadowUkosPL = 1;

    public bool ImaCircle = false;
    public bool ImaCross = false;

    public GameObject particle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ImaCircle == true)
        {
            if (ileSasiadowPoz == 3) matrix.ktoMaTrzy[mojeMiejsce] = 1;
            if (ileSasiadowPion == 3) matrix.ktoMaTrzy[mojeMiejsce] = 1;
            if (ileSasiadowUkosLP == 3) matrix.ktoMaTrzy[mojeMiejsce] = 1;
            if (ileSasiadowUkosPL == 3) matrix.ktoMaTrzy[mojeMiejsce] = 1;
        }
        if(ImaCross == true)
        {
            if (ileSasiadowPoz == 3) matrix.EnemyktoMaTrzy[mojeMiejsce] = 1;
            if (ileSasiadowPion == 3) matrix.EnemyktoMaTrzy[mojeMiejsce] = 1;
            if (ileSasiadowUkosLP == 3) matrix.EnemyktoMaTrzy[mojeMiejsce] = 1;
            if (ileSasiadowUkosPL == 3) matrix.EnemyktoMaTrzy[mojeMiejsce] = 1;
        }

        /*
        if(matrix.KoniecGry == true)
        {
            GameObject puffObj = Instantiate(particle, transform.position, Quaternion.identity);
            puffObj.SetActive(true);
            Destroy(gameObject);
        }
        */



}

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ChangeWall"))
        {
            GameObject puffObj = Instantiate(particle, transform.position, Quaternion.identity);
            puffObj.SetActive(true);
            Destroy(gameObject);
        }
    }

}
