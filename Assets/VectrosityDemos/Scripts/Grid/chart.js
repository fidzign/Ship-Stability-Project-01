import Vectrosity;

var gridPixels = 50;
var lineMaterial : Material;
var lineWidth = 8.0;
var textureScale = 1.0;

private var gridLine : VectorLine;

function Start () {

    // Make Vector2 array with 2 elements...
	var linePoints = [Vector2(0, Random.Range(0, Screen.height/2)),				// ...one on the left side of the screen somewhere
					  Vector2(Screen.width-1, Random.Range(0, Screen.height))];	// ...and one on the right
	
	// Make a VectorLine object using the above points and material
	var line = new VectorLine("Line", linePoints, lineMaterial, lineWidth);
	
	// Draw the line and set the texture scale
	line.Draw();
	line.SetTextureScale (textureScale);
	gridLine = new VectorLine("Grid", new Vector2[2], null, 1.0);
	MakeGrid();
}

function OnGUI () {
	GUI.Label (Rect(10, 10, 30, 20), gridPixels.ToString());
	gridPixels = GUI.HorizontalSlider (Rect(40, 15, 590, 20), gridPixels, 5, 200);
	if (GUI.changed) {
		MakeGrid();
	}
}

//function MakeGrid () {
//	var gridPoints = new Vector2[((Screen.width/gridPixels + 1) + (Screen.height/gridPixels + 1)) * 2];
//	gridLine.Resize (gridPoints);
//	
//	var index = 0;
//	for (var x = 0; x < Screen.width; x += gridPixels) {
//		gridPoints[index++] = Vector2(x, 0);
//		gridPoints[index++] = Vector2(x, Screen.height-1);
//	}
//	for (var y = 0; y < Screen.height; y += gridPixels) {
//		gridPoints[index++] = Vector2(0, y);
//		gridPoints[index++] = Vector2(Screen.width-1, y);
//	}
//		
//	gridLine.Draw();
//}
function MakeGrid () {
	var gridPoints = new Vector2[((400/gridPixels + 1) + (400/gridPixels + 1)) * 2];
	gridLine.Resize (gridPoints);
	
	var index = 0;
	for (var x = 0; x < 400; x += gridPixels) {
		gridPoints[index++] = Vector2(x, 0);
		gridPoints[index++] = Vector2(x, 400-1);
	}
	for (var y = 0; y < 400; y += gridPixels) {
		gridPoints[index++] = Vector2(0, y);
		gridPoints[index++] = Vector2(400-1, y);
	}
		
	gridLine.Draw();
}