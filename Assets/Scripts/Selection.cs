using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Selection : MonoBehaviour {

    public GameObject btnPredator;
    public GameObject btnPlayer;
    public GameObject mouse;
    private Vector3 mousePos;
    public LayerMask predator;
    public LayerMask player;
    public LayerMask play;
    public GameObject predatorObj;
    public GameObject playerObj;
    private int countPreda;
    private int countPlayer;
    private bool predatorClick;
    private bool playerClick;
    private bool playClick;

    void FixedUpdate()
    {
        predatorClick = Physics2D.OverlapBox(mouse.transform.position, mouse.GetComponent<BoxCollider2D>().size, 0, predator);
        playerClick = Physics2D.OverlapBox(mouse.transform.position, mouse.GetComponent<BoxCollider2D>().size, 0, player);
        playClick = Physics2D.OverlapBox(mouse.transform.position, mouse.GetComponent<BoxCollider2D>().size, 0, play);
    }

	void Start () {
        // T-rex transform = (-10.4f, -5.05f, -2);
        // charizard transform = (-8.37f, -4.42f, -2);
        // swalot transform = (-7.67f, -4.66f, -2);
    }

    void Update () {
        mouse.transform.position = new Vector3(GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition).x,
            GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition).y,
            GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition).z);
        if (Input.GetMouseButtonDown(0))
        {
            if (predatorClick && countPreda <= 2)
            {
                countPreda += 1;
            }
            else if (playerClick && countPreda <= 2)
            {
                countPlayer += 1;
            }
            if (predatorClick && countPreda == 3)
            {
                countPreda = 0;
            }
            else if (playerClick && countPlayer == 3)
            {
                countPlayer = 0;
            }  
            if (playClick)
            {
                SceneManager.LoadScene(2);
            }
        }
        if (countPlayer == 0)
        {
            playerObj.GetComponent<Animator>().SetBool("peach", false);
            playerObj.GetComponent<Animator>().SetBool("miner", true);
        }
        else if (countPlayer == 1)
        {
            playerObj.GetComponent<Animator>().SetBool("miner", false);
            playerObj.GetComponent<Animator>().SetBool("goku", true);
        }
        else if (countPlayer == 2)
        {
            playerObj.GetComponent<Animator>().SetBool("goku", false);
            playerObj.GetComponent<Animator>().SetBool("peach", true);
        }
        if (countPreda == 0)
        {
            predatorObj.GetComponent<Animator>().SetBool("charizard", false);
            predatorObj.GetComponent<Animator>().SetBool("rex", true);
        }
        else if (countPreda == 1)
        {
            predatorObj.GetComponent<Animator>().SetBool("rex", false);
            predatorObj.GetComponent<Animator>().SetBool("swalot", true);
        }
        else if (countPreda == 2)
        {
            predatorObj.GetComponent<Animator>().SetBool("swalot", false);
            predatorObj.GetComponent<Animator>().SetBool("charizard", true);
        }
    }
}
