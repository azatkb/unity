using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

///Developed by Indie Studio
///https://www.assetstore.unity3d.com/en/#!/publisher/9268
///www.indiestd.com
///info@indiestd.com

namespace IndieStudio.DrawingAndColoring.Logic
{
	[DisallowMultipleComponent]
	public class ShapesCanvas : MonoBehaviour {

		public static ShapesCanvas instance;

		/// <summary>
		/// The shapes container.
		/// </summary>
		public Transform shapesContainer;

		/// <summary>
		/// The shape order.
		/// </summary>
		public static Text shapeOrder;

		// Use this for initialization
		void Awake () {
			if (instance == null) {
				instance = this;
				DontDestroyOnLoad (gameObject);

				SetShapeOrderReference();

				//Instantiate the shapes
				InstantiateShapes ();
			} else {
				//Set up the render camera of the Canvas
				Canvas canvas = instance.GetComponent<Canvas> ();
				if (canvas.worldCamera == null) {
					canvas.worldCamera = Camera.main;
				}

				SetShapeOrderReference();

				Destroy (gameObject);
			}
		}

		/// <summary>
		/// Set the shape order reference.
		/// </summary>
		private static void SetShapeOrderReference(){
			//if(shapeOrder == null){
			//	shapeOrder = GameObject.Find("ShapeOrder").GetComponent<Text>();
			//}
		}

		/// <summary>
		/// Instantiate the shapes.
		/// </summary>
		public void InstantiateShapes(){
			
		
        }

        public void InitElephant(){

            RectTransform rectTransform;

            GameObject shape = Instantiate(ShapesManager.instance.shapes[4].gamePrefab, Vector3.zero, Quaternion.identity) as GameObject;
            shape.name = ShapesManager.instance.shapes[4].gamePrefab.name;
     
            shape.transform.SetParent(shapesContainer);
            rectTransform = shape.GetComponent<RectTransform>();
                                                                
            rectTransform.anchoredPosition3D = Vector3.zero;
            shape.transform.localScale = Vector3.one;
            shape.SetActive(true);
            ShapesManager.instance.shapes[4].gamePrefab = shape.gameObject;

        }

        public void InitFox()
        {

            RectTransform rectTransform;

            GameObject shape = Instantiate(ShapesManager.instance.shapes[5].gamePrefab, Vector3.zero, Quaternion.identity) as GameObject;
            shape.name = ShapesManager.instance.shapes[5].gamePrefab.name;

            shape.transform.SetParent(shapesContainer);
            rectTransform = shape.GetComponent<RectTransform>();

            rectTransform.anchoredPosition3D = Vector3.zero;
            shape.transform.localScale = Vector3.one;
            shape.SetActive(true);
            ShapesManager.instance.shapes[5].gamePrefab = shape.gameObject;

        }

        /// <summary>
		/// Clean the shapes.
		/// </summary>
		public void CleanShapes()
        {

            for (int i = 0; i < ShapesManager.instance.shapes.Count; i++)
            {
                //Clean the history for the current shape
                Area.shapesDrawingContents[i].GetComponent<History>().CleanPool();

                //Remove all the childern in drawContents
                foreach (Transform child in Area.shapesDrawingContents[i].transform)
                {
                    Destroy(child.gameObject);
                }

                Transform shapeParts = ShapesManager.instance.shapes[i].gamePrefab.transform.Find("Parts");
                if (shapeParts != null)
                {
                    foreach (Transform part in shapeParts)
                    {
                        part.GetComponent<SpriteRenderer>().color = Color.white;
                        Area.shapesDrawingContents[i].shapePartsColors[part.name] = Color.white;
                        part.GetComponent<ShapePart>().ApplyInitialSortingOrder();
                        part.GetComponent<ShapePart>().ApplyInitialColor();
                        Area.shapesDrawingContents[i].shapePartsSortingOrder[part.name] = part.GetComponent<ShapePart>().initialSortingOrder;
                    }
                }

                Area.shapesDrawingContents[i].currentSortingOrder = 0;
                Area.shapesDrawingContents[i].lastPartSortingOrder = 0;
            }

            foreach (Transform child in shapesContainer)
            {
                //GameObject.Destroy(child.gameObject);

                child.gameObject.SetActive(false);
            }
        }
    }
}
