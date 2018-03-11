using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSprite : MonoBehaviour {

	public Sprite soundSprite;
	public Sprite muteSprite;

	private Image currentSprite;

	void Start () {
		currentSprite = GetComponent<Image>();
	}

	public void ToggleSprite () {
		if (currentSprite.sprite == soundSprite)
			currentSprite.sprite = muteSprite;
		else {
			currentSprite.sprite = soundSprite;
		}
	}
}
