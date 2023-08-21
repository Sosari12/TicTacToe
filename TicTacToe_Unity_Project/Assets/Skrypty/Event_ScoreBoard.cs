using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_ScoreBoard : MonoBehaviour
{
    public int GraczPoints;
    public GameObject[] numbers;

    void ChangeNumber()
    {
        if (GraczPoints > 0 && GraczPoints <= 10)
        {
            if (GraczPoints > 0) numbers[GraczPoints - 1].SetActive(true);
            if (GraczPoints > 1) numbers[GraczPoints - 2].SetActive(false);
        }
    }

}
