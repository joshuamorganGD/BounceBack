using UnityEngine;
using System.Collections;

public class OrthographicCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Camera.main.orthographicSize = 50 * Screen.height / Screen.width * 0.5f;
	}

	void Resize() {

		float targetAspect = 16.0f / 9.0f;

		float windowAspect = (float)Screen.width / Screen.height;

		float scaleHeight = targetAspect / windowAspect;

		Camera c = this.GetComponent<Camera>();

		if (scaleHeight < 1.0f) {

			Rect rect = c.rect;
			rect.width = 1.0f;
			rect.height = scaleHeight;
			rect.x = 0;
			rect.y = (1.0f - scaleHeight) / 2.0f;

			c.rect = rect;
		}

		else 
		{
			float scaleWidth = 1.0f / scaleHeight;

			Rect rect = c.rect;
			rect.width = scaleWidth;
			rect.height = 1.0f;
			rect.x = (1.0f - scaleWidth) / 2.0f;
			rect.y = 0;	

			c.rect = rect;
		}

	}
}
