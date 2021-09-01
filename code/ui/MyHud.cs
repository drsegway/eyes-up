using Sandbox;
using Sandbox.UI;


    public partial class HUD : HudEntity<RootPanel>
    {
        public MyHUD()
        {
            if(!IsClient) return;

            RootPanel.AddChild<Vitals>();


        }


    }