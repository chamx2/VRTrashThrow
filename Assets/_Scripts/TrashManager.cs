using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum TrashType
{
    Biodegradable,
    NonBiodegradable,
    Recyclable,
    Others,
    None
}

[System.Serializable]
public enum BinType
{
    Biodegradable,
    NonBiodegradable,
    Recyclable
}


public class TrashManager : MonoBehaviour
{   

    public void CorrectTrash(GameObject trash)
    {
        GameManager.Instance.correct.Play();
        GameManager.Instance.points += 1;
        Destroy(trash);
       // Debug.Log("Current point(s):" + GameManager.Instance.points);
    }

    public void WrongTrash(GameObject trash)
    {
        GameManager.Instance.wrong.Play();
        if(GameManager.Instance.points < 0)
        {
            GameManager.Instance.points -= 1;
        }
        else
        {
            GameManager.Instance.points = 0;
        }
        Destroy(trash);
        //Debug.Log("Current point(s):" + GameManager.Instance.points);
    }

}

