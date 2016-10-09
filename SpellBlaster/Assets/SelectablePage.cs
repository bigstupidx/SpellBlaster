using UnityEngine;
using System.Collections;

public class SelectablePage : MonoBehaviour {


	public Transform selectedPagePosition;



	public SelectionManager.Selected isSelected;

	public SelectablePage NextPage;
	public SelectablePage PreviousPage;



	public float selectSpeed= 3.0f;


	Vector3 originalPosition;
	// Use this for initialization
	void Start () {

		originalPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {

		ListenSelected();

	}


	void ListenSelected()
	{
		
		if(isSelected == SelectionManager.Selected.Yes)
		{
			transform.position = Vector3.MoveTowards(transform.position, selectedPagePosition.position, selectSpeed * Time.deltaTime);

		}
		else{
			transform.position = Vector3.MoveTowards(transform.position, originalPosition, selectSpeed * Time.deltaTime);

		}
	}


	public void SelectPage()
	{
		isSelected  = SelectionManager.Selected.Yes;
	}

	public void DeSelectPage()
	{
		isSelected = SelectionManager.Selected.No;
	}


}
