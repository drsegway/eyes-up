
using Sandbox;
using Sandbox.UI.Construct;
using System;
using System.IO;
using System.Threading.Tasks;

//
// You don't need to put things in a namespace, but it doesn't hurt.
// Don't know why we would do this lol - Seg




namespace MinimalExample
{

	
	/// This is the game class. This is an entity that is created serverside when
	/// the game starts, and is replicated to the client. 
	


	public partial class MinimalGame : Sandbox.Game
	{
		public MyHUD MyHUD;
		public MinimalGame()
		{
			if (IsClient) MyHUD = new MyHUD(); //creates new HUD - Seg

			if ( IsServer )
			{
				Log.Info( "My Gamemode Has Created Serverside!" );

				
				
			}

			if ( IsClient )
			{
				Log.Info( "My Gamemode Has Created Clientside!" );
			}
		}
		[Event.Hotload] // this refreshes the HUD every time a change is made. Only singleplayer? - Seg

		public void HotLoadUpdate()
		{

			if ( !IsClient ) return;
			MyHUD?.Delete();
			MyHUD = new MyHUD();

		}

		
		/// A client has joined the server. Makes them a pawn to play with
		
		public override void ClientJoined( Client client )
		{
			base.ClientJoined( client );

			var player = new MinimalPlayer();
			client.Pawn = player;

			player.Respawn();
		}
	}

}
