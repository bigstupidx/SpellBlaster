using UnityEngine;
using System.Collections;

public class SelectionManager : MonoBehaviour {


	//TODO: Refactor to Game Settings class
	public enum Idioma {
		en_US, es_MX
	};

	public enum Dificultad {
		Facil, Medio, Dificil
	};

	public enum Musica {
		Si, No
	};

	public enum Efectos {
		Si, No
	};




	public enum Selected
	{
		Yes, No
	};


	public enum Hovering
	{
		Yes, No
	};



	public enum SelectionType
	{
		Stay, MoveNextPage, MovePreviousPage, LoadsGame

	}

	SelectablePage[] selectablePages;
	public SelectableItem[] selectableItems;

	void Start () {

		selectablePages = GetComponentsInChildren<SelectablePage>();
		selectableItems = GetComponentsInChildren<SelectableItem>();


		ManageSelectedPages();


	}
	
	// Update is called once per frame
	void Update () {


		ListenTouchMouse();

	}

	void ListenTouchMouse()
	{

	   Vector3 temp = Input.mousePosition;
	   temp.z = Mathf.Abs(Camera.main.transform.position.z); // Set this to be the distance you want the object to be placed in front of the camera.
	   Vector3 destination = Camera.main.ScreenToWorldPoint(temp);

		Vector3 direction =  destination - Camera.main.transform.position;

	   Debug.DrawRay(Camera.main.transform.position, direction, Color.blue);
	   Ray ray = new Ray(Camera.main.transform.position, direction);


	   RaycastHit rhit = new RaycastHit();
	   Physics.Raycast(ray, out rhit);
	   if(rhit.collider)
	   {
		   SelectableItem hoveredOverItem = rhit.collider.gameObject.GetComponent<SelectableItem>();
		   if(hoveredOverItem)
		   {
		   		Debug.Log(rhit.collider.gameObject.name);

		   		hoveredOverItem.HoveringItem();

				foreach(SelectableItem s in selectableItems)
				   {
				   		if( s != hoveredOverItem )s.LeaveHovering();
				   }

				if(Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Return))
				{
					hoveredOverItem.SelectedItem();	

					foreach(SelectableItem s in selectableItems)
					{
						if(s != hoveredOverItem && hoveredOverItem.SelectionGroup == s.SelectionGroup) 
							s.isSelected = Selected.No;
					}

					ManageSelection(hoveredOverItem);

					if(!hoveredOverItem.staySelected) hoveredOverItem.isSelected= Selected.No;
				}
		   }
	   }
	}


	public SelectablePage selectedPage;
	void ManageSelectedPages()
	{
		foreach(SelectablePage sp in selectablePages){
			if(sp.isSelected == Selected.Yes){
				selectedPage = sp;
			}
			if(sp != selectedPage) {
				sp.isSelected = Selected.No;
			}
		}

		if(!selectedPage){
			selectedPage = selectablePages[0];
			selectedPage.isSelected = Selected.Yes;
		}
	}

	void ManageSelection(SelectableItem selectedItem)
	{

		if(selectedItem)
		{
			SelectablePage selectedItemPage = selectedItem.GetComponentInParent<SelectablePage>();

			selectedPage.isSelected = Selected.No;

			switch(selectedItem.selectionType)
			{
				case SelectionManager.SelectionType.MoveNextPage:

					if(selectedItemPage.NextPage)
					selectedItemPage.NextPage.isSelected = Selected.Yes;
				break;

				case SelectionManager.SelectionType.MovePreviousPage:
					if(selectedItemPage.PreviousPage)
					selectedItemPage.PreviousPage.isSelected = Selected.Yes;
				break;

				case SelectionManager.SelectionType.LoadsGame:

					UnityEngine.SceneManagement.SceneManager.LoadScene(1);
					
				break;


				default:
					selectedPage.isSelected = Selected.Yes;
				break;
			}

			ManageSelectedPages();
		}
		

	}

}
