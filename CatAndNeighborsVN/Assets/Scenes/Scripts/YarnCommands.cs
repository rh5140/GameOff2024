using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class YarnCommands : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    public GameObject gameObject;
    public GameObject itemInteractionCanva;

	public List<Sprite> loadSprites = new List<Sprite>();
	public List<AudioClip> loadAudio = new List<AudioClip>();

	[Header("Object references"), Tooltip("don't change these unless you know what you're doing")]
	public RectTransform spriteGroup; // used for screenshake
	public Image bgImage, fadeBG, nameplateBG;
	public Image genericSprite; // local prefab, used for instantiating sprites
	public AudioSource genericAudioSource; // local prefab, used for instantiating sounds

    void Awake() {
        dialogueRunner.AddCommandHandler<string>("change_scene", ChangeScene);
        dialogueRunner.AddCommandHandler("item_interaction", Interact);
		dialogueRunner.AddCommandHandler<string>("Scene", DoSceneChange);


        itemInteractionCanva.SetActive(false);
    }

	/// <summary>changes background image</summary>
	public void DoSceneChange(string spriteName) {
		bgImage.sprite = FetchAsset<Sprite>( spriteName );
	}

    private void ChangeScene(string sceneName) {
        Debug.Log("loading scene");
        SceneManager.LoadScene(sceneName);
        gameObject.SetActive(true);
    }

    private void Interact() {
        Debug.Log("Activate item interaction canva");
        itemInteractionCanva.SetActive(true);
    }

    // utility function to find an asset, whether it's in \Resources\
	// or manually loaded via an array
	T FetchAsset<T>( string assetName ) where T : UnityEngine.Object {
		// first, check to see if it's a manully loaded asset, with
		// manual array checks... it's messy but I can't think of a
		// better way to do this
		if ( typeof(T) == typeof(Sprite) ) {
			foreach ( var spr in loadSprites ) {
				if (spr.name == assetName) {
					return spr as T;
				}
			}
		} 
		else if ( typeof(T) == typeof(AudioClip) ) {
			foreach ( var ac in loadAudio ) {
				if ( ac.name == assetName ) {
					return ac as T;
				}
			}
		}

		// by default, we load all Resources assets into the asset
		// arrays already, but if you don't want that, then uncomment
		// this, etc. if ( useResourcesFolders ) {var newAsset =
		// Resources.Load<T>(assetName); if ( newAsset != null )
		// {return newAsset;
		//  }
		// }

		Debug.LogErrorFormat(this, "VN Manager can't find asset [{0}]... maybe it is misspelled, or isn't imported as {1}?", assetName, typeof(T).ToString() );
		return null; // didn't find any matching asset
	}
}
