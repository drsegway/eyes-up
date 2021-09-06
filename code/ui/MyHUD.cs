using Sandbox;
using Sandbox.UI;

public partial class MyHUD : HudEntity<RootPanel>
{
	public MyHUD()
	{
		if ( !IsClient ) return;

		RootPanel.AddChild<BasicMenu>();
		RootPanel.AddChild<Bleeding>();
	}
}
