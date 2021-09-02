
using Sandbox;
using Sandbox.UI.Construct;
using System;
using System.IO;
using System.Threading.Tasks;

//
// You don't need to put things in a namespace, but it doesn't hurt.
//




namespace MinimalExample
{

	

	
	public partial class MinimalGame : Sandbox.Game
	{
		
		public MyHUD MyHUD;
		public MinimalGame()
		{
			

			if ( IsServer )
			{
				Log.Info( "My Gamemode Has Created Serverside!" );

			
				
			}

			if ( IsClient )
			{
				Log.Info( "My Gamemode Has Created Clientside!" );
				MyHUD = new MyHUD(); //creates new HUD
			}
		}
		

		
		public override void ClientJoined( Client client )
		{
			base.ClientJoined( client );

			var player = new MinimalPlayer();
			client.Pawn = player;

			player.Respawn();
		}

		
			
	}

	

}
