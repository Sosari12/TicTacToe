using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{

    public int mojeMiejsce;
    public int mojaWartosc;
    public GameObject noPlace;
    public GameObject YesPlace;
    public Animator GenericBlok;
    public Material DarkMetal;
    public Material RedGlow;
    public AudioClip[] roboRattle;
    private AudioSource source;

    void Start()
    {
        source = this.GetComponent<AudioSource>();
    }

    public void SwitchUP()
    {
        //source.clip = 
        //source.Play();

        if (mojaWartosc >= 0 && mojaWartosc < 3)
        {

            GenericBlok.SetBool("Locking", false);
            GenericBlok.SetBool("Unlocking", true);
            //GenericBlok.gameObject.GetComponentInChildren<SkinnedMeshRenderer>()

            /*
            if (YesPlace.activeSelf)
            {
                //jest aktywne
            }
            else
            {
                YesPlace.SetActive(true);
                noPlace.SetActive(false);
            }
            */
        }

        if (mojaWartosc == 3)
        {
            if(GenericBlok.GetBool("Locking") == true)
            {
                GenericBlok.SetTrigger("Swirl");
            }
            GenericBlok.SetBool("Locking", true);
            GenericBlok.SetBool("Unlocking", false);
           // GenericBlok.gameObject.GetComponent<SkinnedMeshRenderer>().materials[1] = RedGlow;

            /*
            if (noPlace.activeSelf)
            {
                //jest aktywne
            }
            else
            {
                noPlace.SetActive(true);
                YesPlace.SetActive(false);

            }
            */
        }
    }


}
