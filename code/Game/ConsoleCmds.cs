using Sandbox;
using System.Linq;
using System;
using System.Threading;

public partial class ConsoleCommands : Sandbox.Game
{
	[ServerCmd( "killeveryone" )]
	public static void KillEveryone()
	{
		foreach ( Player player in All.OfType<Player>() )
		{
			player.TakeDamage( DamageInfo.Generic( 100f ) );
		}


	}

	[ServerCmd( "sethealth" )]

	public static void SetHealth( int health )
	{
		var caller = ConsoleSystem.Caller.Pawn;
		if ( caller == null ) return;

		caller.Health = health;

	}

	[ServerCmd( "damagetarget" )]

	public static void DamageTarget( int damage )
	{
		var caller = ConsoleSystem.Caller.Pawn;
		if ( caller == null ) return;



		var tr = Trace.Ray( caller.EyePos, caller.EyePos + caller.EyeRot.Forward * 50000 )
				.UseHitboxes()
				.Ignore( caller )
				.Run();

		if ( tr.Entity is Player victim && victim.IsValid() )
		{
			victim.TakeDamage( DamageInfo.Generic( damage ) );
			Log.Info( $"{caller.GetClientOwner().Name} damaged {victim.GetClientOwner().Name} for {damage} hit points" );
		}

		foreach ( Player player in All.OfType<Player>() )
		{

		}
	}

	[ServerCmd( "testentspawn" )] // spawns a test entity

	public static void TestEntSpawn()
	{
		var caller = ConsoleSystem.Caller.Pawn;
		if ( caller == null ) return;

		new HealthUsable()
		{
			Position = caller.Position + caller.Rotation.Forward * 50
		};


	}

	[ServerCmd( "makemeagamer" )] // tag test

	public static void makeGamer()
	{

		var caller = ConsoleSystem.Caller.Pawn;
		if ( caller == null ) return;


		caller.Tags.Add( "gamer" );
		caller.Tags.Remove( "player" );





	}

	[ServerCmd( "makemeaplayer" )] // tag test

	public static void makePlayer()
	{

		var caller = ConsoleSystem.Caller.Pawn;
		if ( caller == null ) return;


		caller.Tags.Add( "player" );
		caller.Tags.Remove( "gamer" );





	}

	[ServerCmd( "makemetagless" )] // tag test

	public static void makeTagless()
	{

		var caller = ConsoleSystem.Caller.Pawn;
		if ( caller == null ) return;


		caller.Tags.Remove( "player" );
		caller.Tags.Remove( "gamer" );





	}

	[ServerCmd( "checktags" )]
	public static void tagChecker() //tests tags. I'd like to get it to check any tags the player has and print them all out. For now it only checks gamer and player.
	{

		foreach ( var client in Client.All )
		{
			string name = client.Name;
			Entity pawn = client.Pawn;
			bool v = pawn.Tags.Has( "gamer" );
			
			if ( v == true )
			{
				Log.Info( $"{name} has the gamer tag" );
			}
			if (v == false)
			{
				Log.Info( $"{name} does not have the gamer tag" );
			}
			

		}


		foreach (var client in Client.All)
		{
			string name = client.Name;
			Entity pawn = client.Pawn;
			bool x = pawn.Tags.Has( "player" );
			if ( x == true )
			{
				Log.Info( $"{name} has the player tag" );
			}
			if (x == false)
			{
				Log.Info( $"{name} does not have the player tag" );
			}


		}
		


	}





}
