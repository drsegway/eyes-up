using Sandbox;
using System.Linq;

public partial class EyesUp : Sandbox.Game
{

	public MyHUD MyHUD;
    public EyesUp()
    {
		if ( IsClient ) MyHUD = new MyHUD();
    }

	[Event.Hotload]
	public void HotLoadUpdate()
	{
		if ( !IsClient ) return;
		MyHUD?.Delete();
		MyHUD = new MyHUD();

	}

	public override void ClientJoined( Client client )
	{
		base.ClientJoined( client );

		// Create a pawn and assign it to the client.
		var player = new MyPlayer();
		client.Pawn = player;

		player.Respawn();
	}
	[ServerCmd("killeveryone")]
	public static void KillEveryone()
	{
		foreach(Player player in All.OfType<Player>())
		{
			player.TakeDamage( DamageInfo.Generic( 100f ) );
		}


	}

	[ServerCmd("sethealth")]

	public static void SetHealth(int health)
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

		if (tr.Entity is Player victim && victim.IsValid())
		{
			victim.TakeDamage( DamageInfo.Generic( damage ) );
			Log.Info( $"{caller.GetClientOwner().Name} damaged {victim.GetClientOwner().Name} for {damage} hit points" );
		}

		foreach (Player player in All.OfType<Player>())
		{
			
		}
	}

	[ServerCmd("testentspawn")]

	public static void TestEntSpawn()
	{
		var caller = ConsoleSystem.Caller.Pawn;
		if ( caller == null ) return;

		new HealthUsable()
		{
			Position = caller.Position + caller.Rotation.Forward * 50
		};


	}

	

	
}
