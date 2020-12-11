using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
	public float speed = 3.0f;

	private bool canControl = false;
	private string networkID;
	private Vector3 inputVector;
	private float h;

	private void Start()
	{
		if (canControl)
			InvokeRepeating("UpdateInput", 1, 1.0f / 60.0f);
	}

	private void Update()
	{
		if (canControl)
		{
			inputVector = Vector3.zero;
			h = Input.GetAxisRaw("Horizontal");
			inputVector.x += h * Time.deltaTime * speed;
		}
	}
	public void SetNetID(string id)
	{
		networkID = id;
	}
	public void SetControl(bool control)
	{
		canControl = control;
	}
	public void UpdateInput()
	{
		GameClient.Instance.SendInput(inputVector);
	}
}
