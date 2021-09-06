using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

public partial class Bleeding : Panel
{
	

	public Bleeding()
	{
		StyleSheet.Load( "/ui/Bleeding.scss" );

		Panel healthBack = Add.Panel( "healthBack" );

		Panel healthIconBack = healthBack.Add.Panel( "healthIconBack" );
		healthIconBack.Add.Label( "favorite", "healthIcon" );

		Panel healthBarBack = healthBack.Add.Panel( "healthBarBack" );
		healthBack.Add.Label( "You are bleeding", "HealthText"  );






	}

	
}
