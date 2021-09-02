using Sandbox;
using System;
[Library("ent_healthusable")]
public partial class HealthUsable : Prop, IUse
	{
	public override void Spawn()
	{
	
	//spawns the crate, sets the model, and turns on physics.
	
		base.Spawn();

		SetModel( "models/citizen_props/crate01.vmdl_c" );
		SetupPhysicsFromModel( PhysicsMotionType.Static, false );


	//makes the crate glow red.
	
		GlowState = GlowStates.GlowStateOn;
		GlowDistanceStart = 0;
		GlowDistanceEnd = 1000;
		GlowColor = new Color( 1.0f, 0f, 0f, 1.0f );
		GlowActive = true;

	}
	
	// adds 50 health to the entity user, clamps health between 0 and 100.

	public bool OnUse(Entity user)
	{
		if ( user is not Player ply ) return false;
		ply.Health = Math.Clamp(ply.Health +50f, 0f, 100f);
		Delete();

		return false;
	}
	
	// if health is > 100 you can not use the entity.
	
	public bool IsUsable(Entity user)
	{
		return user is Player ply && ply.Health < 100 ;
	}
}
