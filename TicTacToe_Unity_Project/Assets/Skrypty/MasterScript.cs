using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MasterScript : MonoBehaviour
{

    public int GraczPoints = 0;
    public GameObject changeWallAsset;
    public Transform placeWall;
    public bool nextRoundReady = false;
    public Matryca gameControl;
    public Animator scoreBoard;
    public Animator cameraAnim;
    public Animator canvasAnim;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cameraAnim.SetBool("Exit", true);
            canvasAnim.SetBool("Black", true);
            Invoke("LoadLevelGame", 3.0f);
        }


        if (nextRoundReady == true)
        {
            gameControl.procesResetuGry();
            nextRoundReady = false;
        }
    }

    public void GraczZdobylPunkt()
    {
        if (scoreBoard.GetBool("Start") == true) scoreBoard.SetTrigger("Point");
        else scoreBoard.SetBool("Start", true);

        GraczPoints++;
        scoreBoard.GetComponent<Event_ScoreBoard>().GraczPoints = GraczPoints;
        Debug.Log("DODAJE PUNKT!!!!!!!!!!!!!!!!!!!!!");

        GameObject WallObj = Instantiate(changeWallAsset, placeWall.position, Quaternion.identity);
        WallObj.SetActive(true);
        //zniszcz wszystkie cross and circles

    }


    public void EnemyZdobylPunkt()
    {
        GameObject WallObj = Instantiate(changeWallAsset, placeWall.position, Quaternion.identity);
        WallObj.SetActive(true);
        //zniszcz wszystkie cross and circles

    }


    void LoadLevelGame()
    {
        SceneManager.LoadScene(0);
    }

}
