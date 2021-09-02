using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

public partial class Vitals : Panel
{   
    private Label Health;
    private Panel HealthBar;
    public Vitals()
    {
        StyleSheet.Load("/ui/Vitals.scss");

        Panel healthBack = Add.Panel("healthBack");

        Panel healthBarBack = healthBack.Add.Panel ( "healthBarBack" );
        HealthBar = healthBarBack.Add.Panel ("healthBar");

        Health = healthBarBack.Add.Label("0", "healthText");


    }
    
    public override void Tick()
    {
        var player = Local.Pawn;
            if (player == null) return;

            Health.Text = $"{player.Health.CeilToInt()}";

            

            HealthBar.Style.Dirty();
            HealthBar.Style.Width = Length.Percent(player.Health); // really cool piece of code


        base.Tick();
    }
}

    