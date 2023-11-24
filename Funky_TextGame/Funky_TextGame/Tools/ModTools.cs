using Funky_TextGame.AreaCollection;
using Funky_TextGame.StartFunctions;
using Microsoft.VisualBasic;
using System;
using System.Threading.Tasks;
using static System.Console;


namespace Funky_TextGame.Funky_TextGame.Tools
{
    class ModTools
    {
        protected Game myGame;        
        bool CmdActive = false;
        bool CheatsEnabled = false;
        public int GenNum;

            
        public ModTools(Game Game)
        {
            myGame = Game;            
        }

        public void CmdLine()
        {
            CmdActive = true;
            

            while (CmdActive == true)
            {
                Clear();
                WriteLine("\n\nCommand line activated : Type [Help] for available commands \n");
                CursorVisible = true;
                Write(">> " );
                string command = ReadLine();

                if (command == "Kill")
                {
                    if (CheatsEnabled == true)
                    {
                        if (myGame.MyEnemy != null)
                        {
                            myGame.MyEnemy.CurrentHealth = 0;
                        }
                    }
                    else
                    {
                        WriteLine("You don not have permission for this");
                        Utilities.KeyEntry();
                    }
                }                
                else if (command == "Help")
                {
                    WriteLine(@"Available Commands :

[Skills] - Provides a description of player skills
[Main Menu] - Returns you to the main menu. Warning, progress will not be saved
[Quit] - Quits the game. Warning, progress will not be saved
[Exit] - Leaves the menu and returns the player to what they were doing
[Kill] (Cheat) - If Cheats are enabled, forcefully kills opponent
[Make it Rain] (Cheat) - If Cheats are enabled,  gives the player 9999 Gold");
                    Utilities.KeyEntry();
                }
                else if (command == "Skills")
                {
                    WriteLine(@"[Slash] - A basic attack
[Charging Blow] - A level 5 attack dealing 250% damage to the enemy. However, you will suffer some damage too
[Blazing Strike] - A level 10 attack consuming 50 Mana to deal 400% damage
[Sorcery : Blood Sacrifice] - A level 25 attack consuming 100 mana and 400 health to deal 1000% damage
[Armor Crush] - Reduces enemy armor by 60%
[Defend] - Increases your armor until its cap
[Heal] - Restores 35% of your maximum HP");
                    Utilities.KeyEntry();
                }
                else if (command == "Main Menu")
                {
                    myGame.MyMainMenu.Run(default);
                }
                else if (command == "Quit")
                {
                    Utilities.ExitConsole();
                }
                else if (command == "Exit")
                {
                    CmdActive = false;
                } 
                else if (command == "Make it Rain")
                {
                    if (CheatsEnabled == true)
                    {
                        WriteLine("9999 Gold added");
                        myGame.MyDefaultPlayer.Gold += 9999;
                        Utilities.KeyEntry();
                    }
                    else
                    {
                        WriteLine("You don not have permission for this");
                        Utilities.KeyEntry();
                    }
                }
                else if (command == "Enable Cheats")
                {
                    WriteLine("CheatsEnabled");
                    Utilities.KeyEntry();
                    CheatsEnabled = true;
                }
                else
                {
                    WriteLine("That is not a Command");
                    Utilities.KeyEntry();
                }
            }
            CursorVisible = false;
        }

        public void GenerateLevel()
        {
            var rand = new Random();
            GenNum = rand.Next(myGame.MyDefaultPlayer.Level - 3, myGame.MyDefaultPlayer.Level + 3);

            if (GenNum <= 0)
            {
                GenNum = 1;
            }
        }

    }
}
