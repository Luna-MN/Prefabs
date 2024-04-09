using Godot;
using System;


public partial class RaycastMouse : Node3D
{

	public Vector3 ScreenPointToRay(){
		PhysicsDirectSpaceState3D spaceState = GetWorld3D().DirectSpaceState;
		Vector2 mousePos = GetViewport().GetMousePosition();
		Camera3D cam = GetTree().Root.GetCamera3D();
		var rayO = cam.ProjectRayOrigin(mousePos);
		var rayE = rayO + cam.ProjectRayNormal(mousePos) * 2000;
		var query = PhysicsRayQueryParameters3D.Create(rayO, rayE);
		query.CollideWithAreas = true;
		Godot.Collections.Dictionary rayA = spaceState.IntersectRay(query);
		if(rayA != null)
			return (Vector3)rayA["position"];
		return new Vector3(0,0,0); 
	}
}
