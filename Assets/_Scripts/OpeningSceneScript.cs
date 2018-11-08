using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningSceneScript : MonoBehaviour
{
    bool readRecycle;
    bool readNonBio;
    bool readBio;

    public GameObject startButton;
    public GameObject fadeOut;

    public List<GameObject> categories;

    public void OnClickRecycle()
    {
        readRecycle = true;
        Debug.Log("Done reading recycle");
    }

    public void OnClickNonBio()
    {
        readNonBio = true;
        Debug.Log("Done reading Non Bio");
    }

    public void OnClickBio()
    {
        readBio = true;
        Debug.Log("Done reading Biodegradable");
    }

    public void LoadGameScene()
    {
        StartCoroutine(SceneSwitch());
    }
    private void Update()
    {
        if(readRecycle == true && readNonBio == true && readBio == true)
        {
            Debug.Log("Done reading");
            startButton.SetActive(true);
        }
    }

    IEnumerator SceneSwitch()
    {
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadSceneAsync(2);
    }


}
