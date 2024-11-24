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
    public GameObject neighborSelectionCanva;

	public List<Sprite> loadSprites = new List<Sprite>();
	public List<AudioClip> loadAudio = new List<AudioClip>();

	Vector3 left = new Vector3(-300, 0, 0);
	Vector3 right = new Vector3(300, 0, 0);

	[Header("Object references"), Tooltip("don't change these unless you know what you're doing")]
	public RectTransform spriteGroup; // used for screenshake
	public Image bgImage, fadeBG, nameplateBG;
	public GameObject catImage, fashionDesignerImage, vampireNurseImage, pitifulRobotImage; // local prefab, used for instantiating sprites
	public AudioSource genericAudioSource; // local prefab, used for instantiating sounds

    void Awake() {
        dialogueRunner.AddCommandHandler<string>("change_scene", ChangeScene);
        dialogueRunner.AddCommandHandler("item_interaction", Interact);
        dialogueRunner.AddCommandHandler("hide_item", HideInteract);
        dialogueRunner.AddCommandHandler("neighbor_selection", Selection);
		dialogueRunner.AddCommandHandler<string>("Scene", DoSceneChange);
		dialogueRunner.AddCommandHandler<string, string, string, string>("Characters", LoadCharacters);
		dialogueRunner.AddCommandHandler<string, string, string, string>("ResetPos", ResetPosition);

        itemInteractionCanva.SetActive(false);
        neighborSelectionCanva.SetActive(false);
		
		catImage.GetComponent<Image>().sprite = FetchAsset<Sprite>("cat");
		fashionDesignerImage.GetComponent<Image>().sprite = FetchAsset<Sprite>("fashionDesigner");
		vampireNurseImage.GetComponent<Image>().sprite = FetchAsset<Sprite>("vampireNurse");
		pitifulRobotImage.GetComponent<Image>().sprite = FetchAsset<Sprite>("pitifulRobot");
    }

	/// <summary>changes background image</summary>
	public void DoSceneChange(string spriteName) {
		bgImage.sprite = FetchAsset<Sprite>( spriteName );
	}

	public void LoadCharacters(string cat = "no", string fashionDesigner = "no", string vampireNurse = "no", string pitifulRobot = "no") {
		if (cat != "no") {
			catImage.SetActive(true);
			if (cat == "left") {
				catImage.transform.position = catImage.transform.position + left;
				Debug.Log("POSITION " + catImage.transform.position);
			}
			if (cat == "right") {
				catImage.transform.position = catImage.transform.position + right;
			}
		} else {
			catImage.SetActive(false);
		}

		if (fashionDesigner != "no") {
			fashionDesignerImage.SetActive(true);
			if (fashionDesigner == "left") {
				fashionDesignerImage.transform.position = fashionDesignerImage.transform.position + left;
			}
			if (fashionDesigner == "right") {
				fashionDesignerImage.transform.position = fashionDesignerImage.transform.position + right;
			}
		} else {
			fashionDesignerImage.SetActive(false);
		}

		if (vampireNurse != "no") {
			vampireNurseImage.SetActive(true);
			if (vampireNurse == "left") {
				vampireNurseImage.transform.position = vampireNurseImage.transform.position + left;
			}
			if (vampireNurse == "right") {
				vampireNurseImage.transform.position = vampireNurseImage.transform.position + right;
			}
		} else {
			vampireNurseImage.SetActive(false);
		}

		if (pitifulRobot != "no") {
			pitifulRobotImage.SetActive(true);
			if (pitifulRobot == "left") {
				pitifulRobotImage.transform.position = pitifulRobotImage.transform.position + left;
			}
			if (pitifulRobot == "right") {
				pitifulRobotImage.transform.position = pitifulRobotImage.transform.position + right;
			}
		} else {
			pitifulRobotImage.SetActive(false);
		}
	}
	
	public void ResetPosition(string cat = "no", string fashionDesigner = "no", string vampireNurse = "no", string pitifulRobot = "no") {
		if (cat != "no") {
			if (cat == "left") {
				catImage.transform.position = catImage.transform.position - left;
			}
			if (cat == "right") {
				catImage.transform.position = catImage.transform.position - right;
			}
		} 

		if (fashionDesigner != "no") {
			if (fashionDesigner == "left") {
				fashionDesignerImage.transform.position = fashionDesignerImage.transform.position - left;
			}
			if (fashionDesigner == "right") {
				fashionDesignerImage.transform.position = fashionDesignerImage.transform.position - right;
			}
		}

		if (vampireNurse != "no") {
			if (vampireNurse == "left") {
				vampireNurseImage.transform.position = vampireNurseImage.transform.position - left;
			}
			if (vampireNurse == "right") {
				vampireNurseImage.transform.position = vampireNurseImage.transform.position - right;
			}
			
		}

		if (pitifulRobot != "no") {
			if (pitifulRobot == "left") {
				pitifulRobotImage.transform.position = pitifulRobotImage.transform.position - left;
			}
			if (pitifulRobot == "right") {
				pitifulRobotImage.transform.position = pitifulRobotImage.transform.position - right;
			}
		}
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

	private void HideInteract() {
        Debug.Log("Hide item interaction canva");
        itemInteractionCanva.SetActive(false);
    }

    private void Selection() {
        Debug.Log("Activate neighbor selection canva");
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
}
