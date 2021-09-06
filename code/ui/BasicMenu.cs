using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System.Collections.Generic;

public partial class BasicMenu : Panel
{
	private bool IsOpen = false;
	private TimeSince LastOpen;
	private List<(Panel, Panel)> Pages = new();
	private int ActivePage = -1;
	private Panel NavigationPanel;

	public BasicMenu()
	{
		StyleSheet.Load( "/ui/BasicMenu.scss" );

		Panel menuPanel = Add.Panel( "menu" );
		NavigationPanel = menuPanel.Add.Panel( "navbar" );

		Panel mainArea = menuPanel.Add.Panel( "mainarea" );

		// Pages

		Panel homePage = mainArea.Add.Panel( "page" );
		homePage.Add.Label( "Home Page" );

		Panel commandsPage = mainArea.Add.Panel( "page" );
		homePage.Add.Label( "Commands Page" );

	}

	public override void Tick()
	{
		base.Tick();

		if(Input.Pressed(InputButton.Menu) && LastOpen >= .1f)
		{
			IsOpen = !IsOpen;
			LastOpen = 0;
		}

		IsOpen = true; 

		SetClass( "open", IsOpen );

		
	}
}
