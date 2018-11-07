using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningSceneScript : MonoBehaviour
{
    public GameObject _interfaceToAnim;

    public List<Animation> _listAnimations;
    private Animation _playAnimation;

    private void Start()
    {
        _listAnimations = new List<Animation>();
        _playAnimation = _interfaceToAnim.GetComponent<Animation>();
    }

    public void PlayOnClick()
    {
        //foreach()
        _playAnimation.Play();
    }
	
}
