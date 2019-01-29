using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance { get { return instance; } }

    public VRWalkController vrWalkController;
    public GameObject _fadeOut;

    public float _mainTimer;
    public int points = 0;
    public bool gameStart;
    public bool gameEnd;

    public GameObject tempParent;
    public Transform guide;

    public Text _countdownText;
    public Text _scoreText;
    public GameObject endGameCanvas;
    public Text endGameText;

    public AudioSource correct;
    public AudioSource wrong;


    private float timer;
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
        _fadeOut.SetActive(false);
        _countdownText.text = "Read the text first";
        _scoreText.text = " ";
       vrWalkController = vrWalkController.GetComponent<VRWalkController>();
        correct = correct.GetComponent<AudioSource>();
        wrong = wrong.GetComponent<AudioSource>();
        //StartCoroutine(GameFlow());
    }

    

    //void Update()
    //{
    //    if (gameStart)
    //    {
    //        StartCoroutine(GameFlow());
    //    }
    //    Debug.Log("Waiting for game to start");
    //}

    //IEnumerator GameFlow()
    //{
    //    while (!gameStart)
    //    {
    //        timer -= Time.deltaTime;
    //        Debug.Log(timer);
    //        yield return new WaitForEndOfFrame();
    //    }


    //    Debug.Log("GAME OVER\n Total Points:" + points);
    //    GameEnd();
    //}


    #region CountdownTimer
    public void StartCountdown()
    {
        GameStart();
        timer = _mainTimer;
        _countdownText.text = "Time: " + timer.ToString();
        InvokeRepeating("Countdown", 1.0f, 1.0f);
    }

    void Countdown()
    {
        if (--timer == 0.0f)
        {
            //add toString for text coundown
            CancelInvoke("Countdown");
            GameEnd();
        }

        //Update toString for text coundown
        else
        {
            _countdownText.text = "Time: " + timer.ToString();
            _scoreText.text = "Score: " + points.ToString();
        }
    }
    #endregion

    #region Data Reference
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

    #endregion

    #region GameFlow Helper
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
        _countdownText.text = "Times Up!";
        endGameText.text = "Game Over! \n Your points: " + points;
        endGameCanvas.SetActive(true);
    }
  

    
    #endregion

    #region Player controls
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
    #endregion
}
