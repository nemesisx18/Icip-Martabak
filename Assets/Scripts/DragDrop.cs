using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
	private Vector3 screenPoint; //posisi object pada screen
	private Vector3 offset; //selisih posisi obj dengan mouse
	private float firstY; //pos vertikal awal, mengembalikan pos semula
	private float firstX;

	public SpriteRenderer spriteRenderer;
	public Sprite[] spriteTB;

    void Start()
    {
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    //input touch 
    //ketika menyetuh gameobject
    void OnMouseDown()
	{
		firstY = transform.position.y;
		firstX = transform.position.x;
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

		spriteRenderer.sprite = spriteTB[0];
	}

	//ketika memindah gameobject
	void OnMouseDrag()
	{
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		transform.position = curPosition;
	}

    //setelah menyentuh gameobject *bisa pindah atau tidak
    private void OnMouseUp()
    {
        ResetItem();
    }

    public void ResetItem()
    {
		transform.position = new Vector3(firstX, firstY, transform.position.z);
		spriteRenderer.sprite = spriteTB[1];
	}
}
