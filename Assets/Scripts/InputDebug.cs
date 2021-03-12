using UnityEngine;

public class InputDebug : MonoBehaviour
{
	public StructureManager structureManager;

    private void Start()
    {
        structureManager = GetComponent<StructureManager>();
    }

    private void Update()
	{
		if(Input.GetKeyDown(KeyCode.K))
        {
            System.Random rand = new System.Random();
            
            structureManager.PlaceStructure(new Vector3Int(rand.Next(0, 100), 10, rand.Next(0, 100)));
        }
	}
}