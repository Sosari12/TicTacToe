using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallChangerAnim : MonoBehaviour
{
    public MasterScript master;




    void gotowyPoResecie()
    {
        master.nextRoundReady = true;
        Destroy(gameObject);
    }
}
