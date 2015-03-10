using UnityEngine;
using System.Collections;

public class TileHandler : MonoBehaviour {

	public Material player1VMaterial;
	public Material player1HMaterial;
	public Material player2VMaterial;
	public Material player2HMaterial;
	public bool isRedVertical;
	public int color;
	public int id;
	public int verticality;

	void Start () 
	{
		color = 0;
	}
	
	void Update () 
	{
	
	}

	void OnMouseDown() 
	{
		if (color == 0)
		{
			GameObject b = GameObject.Find ("Board");
			BoardInit bI = b.GetComponent ("BoardInit") as BoardInit;
			if(isRedVertical)
			{
				if (bI.currentPlayer) 
				{
					gameObject.GetComponent<Renderer> ().material = player1VMaterial;
					bI.currentPlayer = false;
					color = 1;
					verticality = 1;
				} 

				else 
				{
					gameObject.GetComponent<Renderer> ().material = player2HMaterial;
					bI.currentPlayer = true;
					color = 2;
					verticality = 2;
				}
			}

			else
			{
				if (bI.currentPlayer) 
				{
					gameObject.GetComponent<Renderer> ().material = player1HMaterial;
					bI.currentPlayer = false;
					color = 1;
					verticality = 2;
				} 
					
				else 
				{
					gameObject.GetComponent<Renderer> ().material = player2VMaterial;
					bI.currentPlayer = true;
					color = 2;
					verticality = 1;
				}
			}
		}
	}
}
