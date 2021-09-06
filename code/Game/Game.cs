using Sandbox;
using System.Linq;
using System;
using System.Threading;

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
		if (!IsClient) return;
		MyHUD?.Delete();
		MyHUD = new MyHUD();

	}

	public override void ClientJoined(Client client)
	{
		base.ClientJoined(client);

		// Create a pawn and assign it to the client.
		var player = new MyPlayer();
		client.Pawn = player;

		player.Respawn();
	}


	[ServerCmd("killeveryone")]
	public static void KillEveryone()
	{
		foreach (Player player in All.OfType<Player>())
		{
			player.TakeDamage(DamageInfo.Generic(100f));
		}


	}

	















}
