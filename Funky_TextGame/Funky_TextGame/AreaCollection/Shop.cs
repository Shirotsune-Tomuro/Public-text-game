using Funky_TextGame.AreaCollection;
using Funky_TextGame.StartFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funky_TextGame.Funky_TextGame.AreaCollection
{
    internal class Shop : Area
    {
        public Shop(Game Game) : base(Game)
        {
            Name = "Shop";
            Description = "A place to purchase upgrades";
        }

        override protected void Start()
        {
            Utilities.Delay(@"You approach the caravn and are approached by a ""Kobold"" merchant");
            Utilities.KeyEntry();

            string prompt = "What would you like to do?";
            string prompt2 = "";
            string[] options = { "Purchase something", "Leave" };
            Menu mainMenu = new Menu(prompt, options, prompt2);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    {
                        Shopping();
                    }
                    break;
                case 1:
                    {
                        myGame.MyForest_2.Run();
                    }
                    break;
            }
        }

        private void Shopping()
        {
            string prompt = "\"Welcome to GobGob's shop, what would Human like to buy?\"";
            string prompt2 = "";
            string[] options = { "Mana Stimulant (+100% Mana) : 200 Gold", "Champions Armor (Max Armor +50) : 5000 Gold", "Champions sword (Damage +50%) : 7500 Gold" };
            Menu mainMenu = new Menu(prompt, options, prompt2);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    {
                        if (myGame.MyDefaultPlayer.Gold == 200)
                        {
                            myGame.MyDefaultPlayer.Mana += 100;
                            Utilities.Delay("This sale pleases GobGob Human");
                        }
                        else
                        {
                            Utilities.Delay("You can't afford that");
                        }
                        Utilities.KeyEntry();
                        myGame.MyShop.Run();
                    }
                    break;
                case 1:
                    {
                        if (myGame.MyDefaultPlayer.Gold == 5000)
                        {
                            myGame.MyDefaultPlayer.MaxArmor += 50;
                            Utilities.Delay("This sale pleases GobGob Human");
                        }
                        else
                        {
                            Utilities.Delay("You can't afford that");
                        }
                        Utilities.KeyEntry();
                        myGame.MyShop.Run();
                    }
                    break;
                case 2:
                    {
                        if (myGame.MyDefaultPlayer.Gold == 7500)
                        {
                            myGame.MyDefaultPlayer.StrengthStat += (myGame.MyDefaultPlayer.StrengthStat * 150) / 100;
                            Utilities.Delay("This sale pleases GobGob Human");
                        }
                        else
                        {
                            Utilities.Delay("You can't afford that");
                        }
                        Utilities.KeyEntry();
                        myGame.MyShop.Run();
                    }
                    break;
            }
        }
    }
}
