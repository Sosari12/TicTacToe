using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBlok : MonoBehaviour
{
    private Animator anim;
    public BlockScript master;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ChangeWall"))
        {
            anim.SetTrigger("Switch");
        }
    }

    void zamiana()
    {
        master.SwitchUP();
    }


}
