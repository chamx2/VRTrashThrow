using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    

    private int points = 0;
    private float timer = 60;

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
        StartCoroutine(GameFlow());
    }
   
    public void CorrectTrash(GameObject trash)
    {
        points += 1 ;
        Destroy(trash);
        Debug.Log("Current point(s):" + points);
    }

    public void WrongTrash(GameObject trash)
    {
        points -= 1;

        Destroy(trash);
        Debug.Log("Current point(s):" + points);
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

    }
}
