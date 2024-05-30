using ProjetVellemanTEST.GameEngine.EntityManager;
using ProjetVellemanTEST.GameEngine.SoundManager;
using ProjetVellemanTEST.GameEngine.UiManager;
using ProjetVellemanTEST.GameEngine.SaveManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetVellemanTEST.GameEngine.K8055DManager;

namespace ProjetVellemanTEST
{

	public partial class frmAppMain : Form
	{
		/*
		 * StartupUi -> gamelayer = 1
		 * MenuUi -> gamelayer = 2
		 * NewGameUi -> gamelayer = 3
		 * SavedGameUi -> gamelayer = 4
		 * SettingsUi -> gamelayer = 5
		 * CreditsUi -> gamelayer = 6
		 * ChooseDifficultyUi -> gamelayer = 7
		 * Game -> gamelayer = 999
		 */


		internal int mainCpt = 0;
		internal bool game = false;
		private int velocity = 10;
		internal int hp = 8;
		internal int score = 0;
		internal int[] highScore = [0, 0, 0, 0, 0];
		internal int endGameCpt = 100;
		internal string pseudo;
		internal InputManager inputManager;
		internal EntityManager entityManager;
		internal PlayerEntity pnlPlayer;
		internal UiManager uiManager;
		internal SoundManager soundManager;
		internal SaveManager saveManager;
		internal Fctvm110 Fctvm110;
		internal int gameLayer = 0;
		internal int charge = 3;
		internal int currentProjectile = 0;
		internal int currentEntity = 0;
		internal int actualCount = 0;
		int digitalChannels;
		internal Random random = new Random();
		internal bool hold = false;
		internal bool hold2 = false;
		internal bool e_hold = false;
		internal bool paused = false;
		internal int data1, data2;
		internal int[] Vbtn = [0, 0, 0, 0, 0];

		public frmAppMain()
		{
			InitializeComponent();
			grpMain.Size = Size;
			inputManager = new InputManager();
			entityManager = new EntityManager(this);
			uiManager = new UiManager(this);
			soundManager = new SoundManager(this);
            saveManager = new SaveManager(this);
			pnlPlayer = new PlayerEntity();
			Fctvm110 = new Fctvm110();
			if (Fctvm110.SearchDevices() != 0)
			{
				Console.WriteLine("card found");
				Console.WriteLine(Fctvm110.ReadAllDigital());
			}
			if (gameLayer == 0)
			{
                Fctvm110.isAnyButtonsDown += Fctvm110_isAnyButtonsDown;
				inputManager.isAnyKeyDown += anyKeyDown;
				uiManager.CreateUiComponents<StartupUi>();
			}
            soundManager.isSystemVolumeChanged += SoundManager_isSystemVolumeChanged;
			soundManager.PlayMusicLoop(soundManager.startupTheme);
			
		}

        private void SoundManager_isSystemVolumeChanged()
        {
			Console.Write("value changed");
			Fctvm110.OutputAnalogChannel(2, data2);
            uiManager.frmAppMain.soundManager.pauseMusicLoop();
            uiManager.frmAppMain.soundManager.resumeMusicLoop();
        }

        private void Fctvm110_isAnyButtonsDown(int value)
        {
            Console.WriteLine("card event");
            if (gameLayer == 0)
            {
                uiManager.ClearUi<StartupUi>();
                Console.WriteLine("test");
                gameLayer = 1;
                uiManager.CreateUiComponents<MenuUi>();
				Fctvm110.isAnyButtonsDown -= Fctvm110_isAnyButtonsDown;
                inputManager.isAnyKeyDown -= anyKeyDown;
            }
        }

        internal void anyKeyDown(Keys keys)
		{
			if (gameLayer == 0)
			{
				uiManager.ClearUi<StartupUi>();
				Console.WriteLine("test");
				gameLayer = 1;
				uiManager.CreateUiComponents<MenuUi>();
                Fctvm110.isAnyButtonsDown -= Fctvm110_isAnyButtonsDown;
                inputManager.isAnyKeyDown -= anyKeyDown;
			}
			
		}

		private void gameUpdate(object sender, EventArgs e)
		{
			soundManager.SystemVolumeChange();
            if(gameLayer != 999)
			{
				data1 = Fctvm110.ReadAnalogChannel(1);
				Console.WriteLine(soundManager.systemVolume);
                Fctvm110.isAnyButtonsPressed();
                if (Fctvm110.ReadDigitalChannel(1) && !hold)
                {
                    this.Select(true, true);
                    hold = true;
                }
                else if (!Fctvm110.ReadDigitalChannel(1) && hold) hold = false;
            }
			soundManager.systemVolume = (float)data1 / 255;
			if (gameLayer == 999)
			{
				Fctvm110.ReadAllAnalog(ref data1, ref data2);
				Console.WriteLine(data1);
				if (pnlPlayer.playerEnabled)
				{
                    digitalChannels = Fctvm110.ReadAllDigital();
                    for (int i = 0; i < 5; i++)
                    {
                        Vbtn[i] = digitalChannels % 2;
                        digitalChannels /= 2;
                        //Console.WriteLine(Vbtn[i]);
                    }
                    if (pnlPlayer.mainPanel.Top >= (grpMain.Height) * 3 / 4)
					{
						if (inputManager.isKeyPressed(Keys.Z) || inputManager.isKeyPressed(Keys.Up) || Vbtn[2] == 1) pnlPlayer.mainPanel.Top -= velocity;
					}
					if (pnlPlayer.mainPanel.Bottom <= grpMain.Height - 7)
					{
						if (inputManager.isKeyPressed(Keys.S) || Vbtn[3] == 1) pnlPlayer.mainPanel.Top += velocity;
					}
					if (pnlPlayer.mainPanel.Right <= grpMain.Width - 7)
					{
						if (inputManager.isKeyPressed(Keys.D) || Vbtn[0] == 1) pnlPlayer.mainPanel.Left += velocity;
					}
					if (pnlPlayer.mainPanel.Left >= 7)
					{
						if (inputManager.isKeyPressed(Keys.Q) || Vbtn[1] == 1) pnlPlayer.mainPanel.Left -= velocity;
					}
					if ((inputManager.isKeyPressed(Keys.Space) || Vbtn[4] == 1) && !hold && currentProjectile < charge)
					{
						currentProjectile++;
						hold = true;
						entityManager.CreateEntity<ProjectileEntity>();
						Console.WriteLine("Porjectile");
						Console.WriteLine(currentProjectile.ToString());
					}
					else if (!inputManager.isKeyPressed(Keys.Space) && Vbtn[4] == 0 && hold) hold = false;
					if(inputManager.isKeyPressed(Keys.Escape) && !e_hold && !paused)
					{
						e_hold = true;
						paused = true;
						uiManager.CreateUiComponents<PauseMenuUi>();
                        inputManager.isEscapeDown += InputManager_isEscapeDown;
					}
					else if(!inputManager.isKeyPressed(Keys.Escape) && e_hold)
					{
						e_hold = false;
					}

				}
				else
				{
                    pnlPlayer = entityManager.CreateEntity<PlayerEntity>();
                    pnlPlayer.size = new Size(20, 20);
                    pnlPlayer.location = new Point(grpMain.Width / 2 - pnlPlayer.mainPanel.Width / 2, (grpMain.Height) * 3 / 4 + pnlPlayer.mainPanel.Height);
                }

				entityManager.moveEntity();
				entityManager.destroyEntity();
				if (entityManager.collision())
				{
					Console.WriteLine("Collision");
				}
				if (entityManager.destruction())
				{
					Console.WriteLine("destruction");
				}
                uiManager.UpdateUi();
                
                /*if (mainCpt == actualCount)
                {
                    actualCount = mainCpt;
					digitalChannels = Fctvm110.ReadAllDigital();
					for (int i = 0; i <5; i++)
					{
						Vbtn[i] = digitalChannels % 2;
						digitalChannels /= 2;
						Console.WriteLine(Vbtn[i]);
					}
                }*/
                mainCpt++;
                if (currentEntity < uiManager.mode + 3)
				{
					int chooseEntity = random.Next(1, uiManager.mode+1);
					int position = random.Next(0, grpMain.Width - 50);
					switch(chooseEntity)
					{
						case 1: MovingEntitiy movingEntitiy = entityManager.CreateEntity<MovingEntitiy>();
							movingEntitiy.location = new Point(position, -50);
							currentEntity++;
							break;
						case 2: MovingEntityDiagonal movingEntityDiagonal = entityManager.CreateEntity<MovingEntityDiagonal>();
							movingEntityDiagonal.location = new Point(position, -50);
							currentEntity++;
							break;
						case 3:MovingEntityPattern01 pattern01 = entityManager.CreateEntity<MovingEntityPattern01>();
							pattern01.location = new Point(position, -40);
							currentEntity++;
							break;
						case 4:MovingEntityTinyVersion movingEntityTiny = entityManager.CreateEntity<MovingEntityTinyVersion>();
							movingEntityTiny.location = new Point(position, -25);
							currentEntity++;
							break;
						case 5:MovingEntityPattern01TinyVersion pattern01TinyVersion = entityManager.CreateEntity<MovingEntityPattern01TinyVersion>();
							pattern01TinyVersion.location = new Point(position, -25);
							currentEntity++;
							break;
					}
				}
				if (hp <= 0)
				{
					uiManager.CreateUiComponents<EndGameUi>();
				}
				
            }
			if (gameLayer == 0)
			{
				uiManager.StartupAnimation();
			}
			if(gameLayer != 0 && gameLayer < 999)
			{
				if (Fctvm110.ReadDigitalChannel(2)) Vbtn[1] = 1;
				else Vbtn[1] = 0;
				if (Vbtn[1] == 1 && !hold2)
				{
					hold2 = true;
					List<Button> copy = new List<Button>(uiManager.buttons);
					foreach(Button button in copy)
					{
						if (button.Focused)
						{
							button.PerformClick();
						}
					}
				}
				else if(hold && Vbtn[1] == 0) hold2 = false;
			}
		}

        private void InputManager_isEscapeDown(Keys key)
        {
            e_hold = true;
            paused = false;
            uiManager.ClearUi<PauseMenuUi>();
			inputManager.isEscapeDown -= InputManager_isEscapeDown;
        }

        private void onKeyUp(object sender, KeyEventArgs e)
		{
			inputManager.onKeyUp(e.KeyCode);
		}

		private void onKeyDown(object sender, KeyEventArgs e)
		{
			inputManager.onKeyDown(e.KeyCode);
		}


	}
}
