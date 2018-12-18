using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance { get { return instance; } }

    public VRWalkController vrWalkController;
   
    public int points = 0;
    public float timer = 360.0f;
    public bool gameStart;
    public bool gameEnd;

    public GameObject tempParent;
    public Transform guide;

    public GameObject endGameCanvas;
    public Text endGameText;


    GameObject currentTrashItem;


    void Awake()
    {
        //if(instance != null && instance != this)
        //{
        //    Destroy(this.gameObject);
        //}
        //else
        //{
            instance = this;
        //}
    }
    //On Load of the game. Start Countdown timer

    //if trash bin receives a collision
    //check collision tag if bio,non-bio,recycle
    //add, minus points if right or wrong
    //(optional) SFX
    public void Start()
    {
        //read first game instruction
        //...
        //..
        //this.tempParent = tempParent;
        //this.guide = guide;
        //this.vrWalkController = vrWalkController;
        vrWalkController = vrWalkController.GetComponent<VRWalkController>();
        //StartCoroutine(GameFlow());
    }

    

    void Update()
    {
        if (gameStart)
        {
            StartCoroutine(GameFlow());
        }
        //Debug.Log("Waiting for game to start");
    }


    public void SetCurrentTrashItem(GameObject trashItem)
    {
        currentTrashItem = trashItem;
    }

    public Transform GetGuide()
    {
        return guide;
    }

    public GameObject GetTempParent()
    {
        return tempParent;
    }

    public GameObject GetCurrentTrashItem()
    {
        return currentTrashItem;
    }

    public void GameStart()
    {
        gameStart = true;
    }

    public void GamePause()
    {
        gameStart = false;

    }

    public void GameEnd()
    {
        EndGameMessage();
        GamePause();
        gameEnd = true;
    }

    public void EndGameMessage()
    {
        endGameText.text = "Game Over! \n Your points: " + points;
        endGameCanvas.SetActive(true);
    }
  

    IEnumerator GameFlow()
    {
        while(timer > 0)
        {
            timer -= Time.deltaTime;
            Debug.Log(timer);
            yield return new WaitForEndOfFrame();
        }


        Debug.Log("GAME OVER\n Total Points:" + points);
        GameEnd();
    }


    public void clickObject()
    {
        Debug.Log("Carrying the object");
        currentTrashItem.GetComponent<Rigidbody>().useGravity = false;
        currentTrashItem.GetComponent<Rigidbody>().isKinematic = true;
        currentTrashItem.transform.position = guide.transform.position;
        //items.transform.rotation = guide.transform.rotation;
        currentTrashItem.transform.parent = tempParent.transform;
    }

    public void letGoObject()
    {
        Debug.Log("Object released!");
        currentTrashItem.GetComponent<Rigidbody>().useGravity = true;
        currentTrashItem.GetComponent<Rigidbody>().isKinematic = false;
        currentTrashItem.transform.parent = null;
        //items.transform.rotation = guide.transform.rotation;
        currentTrashItem.transform.position = guide.transform.position;
    }
}
