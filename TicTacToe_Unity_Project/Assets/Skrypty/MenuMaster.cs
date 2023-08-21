using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMaster : MonoBehaviour
{
    public Animator menuAnim;
    public Animator cameraAnim;
    public bool jestemReady;
    public int x = 0;
    public int sceneANumber = 1;
    public Animator canvasAnim;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if(jestemReady == true)
        {

            //Ustaw Allow
            if(menuAnim.GetBool("Allow") == false)menuAnim.SetBool("Allow", true);


            //Przerzlacz 0 do 1
            if (Input.GetKeyDown(KeyCode.W))
            {
                if(x == 1)
                {
                    menuAnim.SetBool("Start", true);
                    menuAnim.SetBool("Exit", false);
                    x = 0;
                }
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                if (x == 0)
                {
                    menuAnim.SetBool("Start", false);
                    menuAnim.SetBool("Exit", true);
                    x = 1;
                }
            }

            //Wybierz
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (x == 0)
                {
                    cameraAnim.SetBool("Exit", true);
                    menuAnim.SetTrigger("Select");
                    canvasAnim.SetBool("Black", true);
                    Invoke("LoadLevelGame", 3.0f);
                    Debug.Log("sceneBuildIndex to load: " + sceneANumber);
                }
                if (x == 1)
                {
                    Debug.Log("Exit App");
                    Application.Quit();
                }
            }

        }
        else
        {




        }
    }

    void LoadLevelGame()
    {
        SceneManager.LoadScene(sceneANumber);
    }


}
