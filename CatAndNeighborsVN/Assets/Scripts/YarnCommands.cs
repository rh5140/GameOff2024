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
    public GameObject itemInteractionCanva;
    public GameObject neighborSelectionCanva;
	public GameObject livingRoomCanva;

	public List<Sprite> loadSprites = new List<Sprite>();
	public List<AudioClip> loadAudio = new List<AudioClip>();

	Vector3 left = new Vector3(-300, 0, 0);
	Vector3 right = new Vector3(300, 0, 0);

	[Header("Object references"), Tooltip("don't change these unless you know what you're doing")]
	public RectTransform spriteGroup; // used for screenshake
	public Image bgImage, fadeBG, nameplateBG;
	public GameObject catImage, fashionDesignerImage, vampireNurseImage, pitifulRobotImage; // local prefab, used for instantiating sprites
	public AudioSource audioSource; 

    void Awake() {
        dialogueRunner.AddCommandHandler<string>("change_scene", ChangeScene);
        dialogueRunner.AddCommandHandler("item_interaction", Interact);
        dialogueRunner.AddCommandHandler("hide_item", HideInteract);
        dialogueRunner.AddCommandHandler("neighbor_selection", Selection);
		dialogueRunner.AddCommandHandler<string>("Scene", DoSceneChange);
		dialogueRunner.AddCommandHandler<string, bool>("Character", LoadCharacters);
		dialogueRunner.AddCommandHandler("show_living_room", ShowLivingRoom);
		dialogueRunner.AddCommandHandler("hide_living_room", HideLivingRoom);
		dialogueRunner.AddCommandHandler<string>("play_audio", PlayAudioByName);
		dialogueRunner.AddCommandHandler<string>("update_card", UpdateTransitionCard);
		dialogueRunner.AddCommandHandler<string>("commute_to_home", CommuteToHome);
		dialogueRunner.AddCommandHandler("home_from_tart", HomeFromTart);

		itemInteractionCanva.SetActive(false);
        neighborSelectionCanva.SetActive(false);
		catImage.SetActive(false);
		fashionDesignerImage.SetActive(false);
		vampireNurseImage.SetActive(false);
		pitifulRobotImage.SetActive(false);
    }

	/// <summary>changes background image</summary>
	public void DoSceneChange(string spriteName) {
		bgImage.sprite = FetchAsset<Sprite>( spriteName );
	}

    // Method to play an AudioClip based on its name
    public void PlayAudioByName(string audioName)
    {
        // Load the AudioClip from the Resources folder (ensure the path is correct)
        AudioClip clip = Resources.Load<AudioClip>("Audio/" + audioName);

        // Check if the clip was found
        if (clip != null)
        {
            // Play the audio clip
            audioSource.clip = clip;
            audioSource.Play();
        }
        else
        {
            // Handle the case where the clip wasn't found
            Debug.LogWarning("Audio clip not found: " + audioName);
        }
    }

	// To turn on character image: <<Character cat true>>
	// To turn off character image: <<Character FashionDesigner false>>
	// Character's title or name works so you can write <<Character Dorian/vampirenurse true/false>>
	public void LoadCharacters(string character, bool active) {
		if (character.ToLower() == "cat" || 
			character.ToLower() == "selina") {
			if (active) {
				catImage.SetActive(true);
			} else {
				catImage.SetActive(false);
			}
		}
		
		if (character.ToLower() == "fashiondesigner" || 
			character.ToLower() == "marieelle" || 
			character.ToLower() == "marie-elle") {
			if (active) {
				fashionDesignerImage.SetActive(true);
			} else {
				fashionDesignerImage.SetActive(false);
			}
		}

		if (character.ToLower() == "vampirenurse" || 
			character.ToLower() == "dorian" ||
			character.ToLower() == "dorianvayne") {
			if (active) {
				vampireNurseImage.SetActive(true);
			} else {
				vampireNurseImage.SetActive(false);
			}
		}

		if (character.ToLower() == "pitifulrobot" || 
			character.ToLower() == "fern") {
			if (active) {
				pitifulRobotImage.SetActive(true);
			} else {
				pitifulRobotImage.SetActive(false);
			}
		}
	}

    private void ChangeScene(string sceneName) {
        // Debug.Log("loading scene");
		GetComponentInChildren<TransitionFade>().FadeIn();
        StartCoroutine(WaitToChangeScene(1f, sceneName));
        gameObject.SetActive(true);
    }

	private void UpdateTransitionCard(string text)
	{
		GetComponentInChildren<TransitionFade>().UpdateText(text);
	}

	private void CommuteToHome(string text)
	{
		GetComponentInChildren<TransitionFade>().UpdateText(text);
		GetComponentInChildren<TransitionFade>().FadeIn();
	}

	private void HomeFromTart()
	{
		GetComponentInChildren<TransitionFade>().FadeOut();
	}

	private void ShowLivingRoom()
	{
		livingRoomCanva.SetActive(true);
	}
	private void HideLivingRoom()
	{
		livingRoomCanva.SetActive(false);
	}

    private void Interact() {
        // Debug.Log("Activate item interaction canva");
        itemInteractionCanva.SetActive(true);
    }

	private void HideInteract() {
        // Debug.Log("Hide item interaction canva");
        itemInteractionCanva.SetActive(false);
    }

    private void Selection() {
        // Debug.Log("Activate neighbor selection canva");
        neighborSelectionCanva.SetActive(true);
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
		// this, etc. 
		// if ( useResourcesFolders ) {
		// 	var newAsset = Resources.Load<T>(assetName); 
		// 	if ( newAsset != null ) {
		// 		return newAsset;
		//  	}
		// }

		Debug.LogErrorFormat(this, "VN Manager can't find asset [{0}]... maybe it is misspelled, or isn't imported as {1}?", assetName, typeof(T).ToString() );
		return null; // didn't find any matching asset
	}

	IEnumerator WaitToChangeScene(float seconds, string sceneName)
	{
		yield return new WaitForSeconds(seconds);
		SceneManager.LoadScene(sceneName);
	}
}
