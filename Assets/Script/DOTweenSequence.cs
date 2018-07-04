using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DOTweenSequence : MonoBehaviour {

	
	public DOTweenAnimation[] animes;

	// Use this for initialization
	void Start () {

		Sequence seq = DOTween.Sequence();
		foreach ( var anime in animes ) {
			seq.Append(anime.tween);
		}
		seq.SetLoops(-1);
		seq.Play();
		
	}
	
	
	
}
