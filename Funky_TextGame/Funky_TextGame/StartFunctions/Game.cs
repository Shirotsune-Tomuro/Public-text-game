using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using Funky_TextGame.AreaCollection;
using Funky_TextGame.CharacterList;
using Funky_TextGame.Funky_TextGame.AreaCollection;
using Funky_TextGame.Funky_TextGame.Tools;

namespace Funky_TextGame.StartFunctions
{
    class Game
    {
        //gives all levels access to the game class
        public MainMenu MyMainMenu;
        public About MyAbout;
        public Combat MyCombat;
        public Name_Screen MyNameScreen;
        public Cave1 MyCave1;
        public Cave_2 MyCave_2;
        public Forest_1 MyForest_1;
        public Forest_2 MyForest_2;
        public Village MyVillage;
        public Shop MyShop;
        public Mega_Boss MyMegaBoss;
        public EndCredits MyEndCredits;
        public List<ParentCharacter> MyCharacterList;
        public DefaultPlayer MyDefaultPlayer;
        public DefaultEnemy MyEnemy;
        public ModTools MyModTools;

        public Game()
        {
            MyMainMenu = new MainMenu(this);
            MyAbout = new About(this);
            MyCombat = new Combat(this);
            MyNameScreen = new Name_Screen(this);
            MyCave1 = new Cave1(this);
            MyCave_2 = new Cave_2(this);
            MyForest_1 = new Forest_1(this);
            MyForest_2 = new Forest_2(this);
            MyVillage = new Village(this);
            MyShop = new Shop(this);
            MyMegaBoss = new Mega_Boss(this);
            MyEndCredits = new EndCredits(this);
            MyModTools = new ModTools(this);
            MyCharacterList = new List<ParentCharacter>();
            MyDefaultPlayer = new DefaultPlayer(this);
            MyCharacterList.Add(MyDefaultPlayer);           

        }
        //Spawns an enemy when invoked and puts it at the start of the character list
        public void SpawnCharacters(int eLevel)
        {
            MyCharacterList.Add(MyEnemy = new DefaultEnemy(this, eLevel));
            MyCharacterList.Reverse();
        }

        // which level the game will start on
        public void Start()
        {
            MyMainMenu.Run(default);
        }
    }
}
