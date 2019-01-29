using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpeningSceneScript : MonoBehaviour
{
    bool readRecycle;
    bool readNonBio;
    bool readBio;

    public GameObject startButton;
    public GameObject fadeOut;

    public GameObject _bioContext;
    public GameObject _nonBioContext;
    public GameObject _recyclableContext;


    public Text _title;

    public List<GameObject> categories;

    //code reuse Onclicks
    //make less reference 


    public void OnClickRecycle()
    {
        _title.text = " What is Recyclable Waste?";
        _recyclableContext.SetActive(true);
        readRecycle = true;
    }

    public void OnClickNonBio()
    {
        _title.text = " What is Non-Biodegradable Waste?";
        _nonBioContext.SetActive(true);
        readNonBio = true;
        //Debug.Log("Done reading Non Bio");
    }

    public void OnClickBio()
    {
        _title.text = " What is Biodegradable Waste?";
        _bioContext.SetActive(true);
        readBio = true;
        //Debug.Log("Done reading Biodegradable");
    }

    public void LoadGameScene()
    {
        StartCoroutine(SceneSwitch());
    }

    public void OpenCategories()
    {
        _title.text = "3 Types of Wastes";

        for (int i = 0; i < categories.Count; i++)
        {
            categories[i].SetActive(true);
        }

        if (readRecycle == true && readNonBio == true && readBio == true)
        {
            startButton.SetActive(true);
        }
    }

    public void CloseCategories()
    {
        for(int i = 0; i < categories.Count; i++)
        {
            categories[i].SetActive(false);
        }
    }


    IEnumerator SceneSwitch()
    {
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadSceneAsync(2);
    }


}
