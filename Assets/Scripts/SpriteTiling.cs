using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteTiling : MonoBehaviour {

	SpriteRenderer spriteRenderer;
	public bool TileX;
	public bool TileY;

	void Awake() {

		spriteRenderer = this.GetComponent<SpriteRenderer> ();
		Vector2 spriteSize = new Vector2 (spriteRenderer.bounds.size.x / transform.localScale.x, spriteRenderer.bounds.size.y / transform.localScale.y);
		Debug.Log(gameObject.name + " : " + spriteSize);

		//Start Spitting Out Children
		GameObject childBlueprint = new GameObject();
		childBlueprint.name = gameObject.name + " Tile";
		SpriteRenderer childSpriteRenderer = childBlueprint.AddComponent<SpriteRenderer> ();
		childBlueprint.transform.position = transform.position;
		childSpriteRenderer.sprite = spriteRenderer.sprite;

		GameObject child;

		if (TileX && !TileY) {


			for (int i = 1; i < (int)Mathf.Round (spriteRenderer.bounds.size.x); i++) {

				child = Instantiate (childBlueprint) as GameObject;
				child.transform.position = transform.position - new Vector3 (spriteSize.x * i, 0, 0);
				child.transform.parent = transform;
			}
		}

		if (!TileX && TileY) {

			for (int i = 1;  i < (int)Mathf.Round (spriteRenderer.bounds.size.y); ++i) {

				child = Instantiate (childBlueprint) as GameObject;
				child.transform.position = transform.position - new Vector3 (0, spriteSize.y * i, 0);
				child.transform.parent = transform;
			}
		}


		//Loop Through Width and Height
		if (TileX && TileY) {

			for (int i = 1; i * spriteSize.x < (int)Mathf.Round (spriteRenderer.bounds.size.x); i++) {
				for (int j = 1; j * spriteSize.y < (int)Mathf.Round (spriteRenderer.bounds.size.y); j++) {

					child = Instantiate (childBlueprint) as GameObject;
					child.transform.position = transform.position - new Vector3 (spriteSize.x * i, spriteSize.y * j, 0);
					child.transform.parent = transform;
				}
			}
		}


		Destroy (childBlueprint);

		spriteRenderer.enabled = false;
	}


}
