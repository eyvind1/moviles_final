using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generatedynamic : MonoBehaviour {

	// Use this for initialization
	public GameObject prefebs,generate;
	// Use this for initialization
	void Start () {
		InstantiateGameObjects();
	}
	void InstantiateGameObjects(){
		//transform.position=new Vector3(0,0,transform.position.z);
		generate = Instantiate(prefebs, transform.position, transform.rotation);
		generate.transform.Translate(new Vector3 (0,0,1*Time.deltaTime));
		StartCoroutine("Wait3Sec");
	}
	public IEnumerator Wait3Sec(){
		yield return new WaitForSeconds (3f);
		InstantiateGameObjects();
	}
	// Update is called once per frame
	void Update () {
		//InstantiateGameObjects();
		/*if(Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray,out hit))
			{
				Debug.Log(hit.transform.name);
				if(hit.transform.name == "Cube")
				{

				}	
			}
		}*/
	}
}
