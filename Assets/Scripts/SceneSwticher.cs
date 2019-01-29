﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwticher : MonoBehaviour {

	public GameObject FadeOut;
	// public GameObject gameObject;
	public int sceneIndex;

	// Use this for initialization
	void Start () {

		FadeOut.SetActive (false);
		
	}

	IEnumerator SceneSwitch () {

		FadeOut.SetActive (true);
		yield return new WaitForSeconds(3);
		// DontDestroyOnLoad(transform.gameObject);
		SceneManager.LoadSceneAsync(sceneIndex);
	}

	public void SceneSwitchButton () {

		StartCoroutine (SceneSwitch ());
	}
}
