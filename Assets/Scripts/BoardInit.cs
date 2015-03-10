using UnityEngine;
using System.Collections;

public class BoardInit : MonoBehaviour {

	public bool currentPlayer;
	public Material redM;
	public Material blackM;

	void Start () 
	{
		currentPlayer = true;
		Mesh mesh = GetComponent<MeshFilter>().mesh;
		Vector3 gridSize = mesh.bounds.size;
		int w = (int)gridSize.x;
		int h = (int)gridSize.z;
		GameObject seed = GameObject.Find ("Seed");
		GameObject tile = GameObject.Find ("Tile");
		int cpt = 0;
		for (int i=-5; i<w/2+1; i+=2) 
		{
			for(int j=-4;j<h/2;j+=2)
			{
				GameObject clone = Instantiate(seed) as GameObject;
				clone.transform.position = new Vector3 (i, seed.transform.position.y, j);
				cpt ++;
				clone.name = "Seed " + cpt;
				SeedHandler sh = clone.GetComponent("SeedHandler") as SeedHandler;
				sh.id = cpt;
				clone.GetComponent<Renderer> ().material = redM;
			}
		}
		for (int i=-4; i<w/2; i+=2) 
		{
			for(int j=-5;j<h/2+1;j+=2)
			{
				GameObject clone = Instantiate(seed) as GameObject;
				clone.transform.position = new Vector3 (i, seed.transform.position.y, j);
				cpt ++;
				clone.name = "Seed " + cpt;
				SeedHandler sh = clone.GetComponent("SeedHandler") as SeedHandler;
				sh.id = cpt;
				clone.GetComponent<Renderer> ().material = blackM;
			}
		}
		cpt = 0;
		for (int i=-4; i<w/2; i+=2) 
		{
			for(int j=-4;j<h/2;j+=2)
			{
				GameObject clone = Instantiate(tile) as GameObject;
				clone.transform.position = new Vector3 (i, tile.transform.position.y, j);
				cpt ++;
				clone.name = "Tile " + cpt;
				TileHandler handler = clone.GetComponent("TileHandler") as TileHandler;
				handler.isRedVertical = false;
				handler.id = cpt;
			}
		}
		for (int i=-3; i<w/2; i+=2) 
		{
			for(int j=-3;j<h/2;j+=2)
			{
				GameObject clone = Instantiate(tile) as GameObject;
				clone.transform.position = new Vector3 (i, tile.transform.position.y, j);
				cpt ++;
				clone.name = "Tile " + cpt;
				TileHandler handler = clone.GetComponent("TileHandler") as TileHandler;
				handler.isRedVertical = true;
				handler.id = cpt;
			}
		}
	}

	public void Restart()
	{
		for (int i = 1; i<42; i++) 
		{
			string tileName = "Tile " + i;
			Destroy(GameObject.Find(tileName));
		}

		for (int i = 0; i<61; i++) 
		{
			string seedName = "Seed " + i;
			Destroy(GameObject.Find(seedName));
		}

		Start ();
	}

	void Update () 
	{
		
	}
	
}
