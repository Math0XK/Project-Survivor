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
		//Some stuff to help while coding
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


		private int velocity = 10;						//Movement speed of the player
		internal int hp = 8;							//Health of the player
		internal int score = 0;							//Score of the player
		internal int[] highScore = [0, 0, 0, 0, 0];		//Highscore of each levels
        internal int gameLayer = 0;						//Indicator of what screen is displayed
        internal int charge = 3;						//Maximum projectile capacity
        internal int currentProjectile = 0;				//Memorize how many projectiles are displayed
        internal int currentEntity = 0;					//Memorize how many entity are displayed 
        internal int digitalChannels;					//Stock the binary value of the digital channels of the K8055
        internal int data1, data2;						//Stock the value of each analog input
        internal int[] Vbtn = [0, 0, 0, 0, 0];			//Stock the value of each digital inputs after the mask

        internal string pseudo;							//Save the name of the player

		//Initiate my classes 
		internal InputManager inputManager;
		internal EntityManager entityManager;
		internal PlayerEntity pnlPlayer;
		internal UiManager uiManager;
		internal SoundManager soundManager;
		internal SaveManager saveManager;
		internal Fctvm110 Fctvm110;

		//Create a random seed
		internal Random random = new Random();

		//Save the status of some buttons
        internal bool hold = false;
		internal bool hold2 = false;
		internal bool e_hold = false;

		//True when the game is paused
		internal bool paused = false;

		//True when K8055 is detected on launch
		internal bool cardMode = false;
		

		public frmAppMain()
		{
			InitializeComponent();
			grpMain.Size = Size;						//Givve grpMain the size of the window

			//Initiate my classes 
			inputManager = new InputManager();
			entityManager = new EntityManager(this);
			uiManager = new UiManager(this);
			soundManager = new SoundManager(this);
            saveManager = new SaveManager(this);
			pnlPlayer = new PlayerEntity();
			Fctvm110 = new Fctvm110();

			//Search if K8055 is detected. If yes, connect to it and clear all outputs
			if (Fctvm110.SearchDevices() != 0)
			{				
				Fctvm110.ClearAllAnalog();
				data1 = Fctvm110.ReadAnalogChannel(1);
				Fctvm110.OutputAnalogChannel(2, data1);
                Fctvm110.ClearAllDigital();
				cardMode = true;
			}

			//Bind some useful events
			if (gameLayer == 0)
			{
				if (cardMode)
				{
					Fctvm110.isAnyButtonsDown += Fctvm110_isAnyButtonsDown;		//Events that occurs when any buttons of the K8055 is pressed
				}
				inputManager.isAnyKeyDown += anyKeyDown;						//Events that occurs when any buttons of the keyboard is pressed
				uiManager.CreateUiComponents<StartupUi>();						//Create the startup Ui
			}
            soundManager.isSystemVolumeChanged += SoundManager_isSystemVolumeChanged;  //Event that occurs when the system volume value has changed
			soundManager.PlayMusicLoop(soundManager.startupTheme);				//Play the menu theme
			
		}

		//Force the music to change volume by pausing and resuming the music quickly
		//And send the actual value to the analog output 2
        internal void SoundManager_isSystemVolumeChanged()
        {
			if (cardMode)
			{
				Fctvm110.OutputAnalogChannel(2, data1);
			}
            uiManager.frmAppMain.soundManager.pauseMusicLoop();
            uiManager.frmAppMain.soundManager.resumeMusicLoop();
        }

		//If any buttons has been pressed, clear the startup Ui, display
		//The Main Menu Ui and unbind useless events
        private void Fctvm110_isAnyButtonsDown(int value)
        {
            if (gameLayer == 0)
            {
                uiManager.ClearUi<StartupUi>();
                gameLayer = 1;
                uiManager.CreateUiComponents<MenuUi>();
				Fctvm110.isAnyButtonsDown -= Fctvm110_isAnyButtonsDown;
                inputManager.isAnyKeyDown -= anyKeyDown;
            }
        }

		//Same here 
        internal void anyKeyDown(Keys keys)
		{
			if (gameLayer == 0)
			{
				uiManager.ClearUi<StartupUi>();
				gameLayer = 1;
				uiManager.CreateUiComponents<MenuUi>();
                Fctvm110.isAnyButtonsDown -= Fctvm110_isAnyButtonsDown;
                inputManager.isAnyKeyDown -= anyKeyDown;
			}
			
		}

		//gameUpdate is a events that occurs on each ticks of the game clock. The clock is set on 1 ms
		//Due to limited performance of windows forms, a lot more than 1 ms are passing between each ticks
		private void gameUpdate(object sender, EventArgs e)
		{
            if(gameLayer != 999 && cardMode)
			{
				//Check if any buttons is pressed
                Fctvm110.isAnyButtonsPressed();
				//If digital input 1 is high, focus the next element focusable in the tabindex
                if (Fctvm110.ReadDigitalChannel(1) && !hold)
                {
                    this.Select(true, true);
                    hold = true;
                }
                else if (!Fctvm110.ReadDigitalChannel(1) && hold) hold = false;
            }
			//Check if the system volume value has changed
            soundManager.SystemVolumeChange();

            if (cardMode)
			{
				//Read the value of each analog inputs and stock them
                Fctvm110.ReadAllAnalog(ref data1, ref data2);
				//Change the system volume with the valur of analog input 1
                soundManager.systemVolume = data1 / 255f;
			}
			//Gamelayer = 999 means that the game goes on
			if (gameLayer == 999)
			{
				if (pnlPlayer.playerEnabled)
				{
					if (cardMode)
					{
						//Get the binary value of each digital inputs in once
						digitalChannels = Fctvm110.ReadAllDigital();
						//Mask the value and stock the state of each digital inputs
						for (int i = 0; i < 5; i++)
						{
							Vbtn[i] = digitalChannels % 2;
							digitalChannels /= 2;
						}
					}
					//Move the player with Z/Q/S/D, arrows or K8055 digital inputs 1 -> 4
                    if (pnlPlayer.mainPanel.Top >= (grpMain.Height) * 3 / 4)
					{
						if (inputManager.isKeyPressed(Keys.Z) || inputManager.isKeyPressed(Keys.Up) || Vbtn[2] == 1) pnlPlayer.mainPanel.Top -= velocity;
					}
					if (pnlPlayer.mainPanel.Bottom <= grpMain.Height - 7)
					{
						if (inputManager.isKeyPressed(Keys.S) || inputManager.isKeyPressed(Keys.Down) || Vbtn[3] == 1) pnlPlayer.mainPanel.Top += velocity;
					}
					if (pnlPlayer.mainPanel.Right <= grpMain.Width - 7)
					{
						if (inputManager.isKeyPressed(Keys.D) || inputManager.isKeyPressed(Keys.Right) || Vbtn[0] == 1) pnlPlayer.mainPanel.Left += velocity;
					}
					if (pnlPlayer.mainPanel.Left >= 7)
					{
						if (inputManager.isKeyPressed(Keys.Q) || inputManager.isKeyPressed(Keys.Left) || Vbtn[1] == 1) pnlPlayer.mainPanel.Left -= velocity;
					}
					//Throw a projectile when space or K8055's digital input 5 is pressed
					if ((inputManager.isKeyPressed(Keys.Space) || Vbtn[4] == 1) && !hold && currentProjectile < charge)
					{
						currentProjectile++;
						hold = true;
						entityManager.CreateEntity<ProjectileEntity>();
					}
					else if (!inputManager.isKeyPressed(Keys.Space) && Vbtn[4] == 0 && hold) hold = false;
					//Pause the game when escape is pressed
					//Then bind a special event to unpause the game
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
				//When the game start, create the player
				else
				{
                    pnlPlayer = entityManager.CreateEntity<PlayerEntity>();
                    pnlPlayer.size = new Size(20, 20);
                    pnlPlayer.location = new Point(grpMain.Width / 2 - pnlPlayer.mainPanel.Width / 2, (grpMain.Height) * 3 / 4 + pnlPlayer.mainPanel.Height);
                }
				//Move each entity
				entityManager.moveEntity();
				//Destroy entities that have to be destroyed
				entityManager.destroyEntity();
				//Check for collision between entities and player
				entityManager.collision();
				//Check for collision between entities and projectiles
				entityManager.destruction();
				//Update Ui that have to be updated
                uiManager.UpdateUi();
				//Count each ticks
                mainCpt++;
				//Make entities spawn with random position
				//Choose random types of entities
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
				//End the game when the player is dead
				if (hp <= 0)
				{
					uiManager.CreateUiComponents<EndGameUi>();
				}
				
            }
			//Animate the startup Ui
			if (gameLayer == 0)
			{
				uiManager.StartupAnimation();
			}
			//Performs clicks with K8055's digital input 2
			if(gameLayer != 0 && gameLayer < 999)
			{
				if (cardMode)
				{
					if (Fctvm110.ReadDigitalChannel(2)) Vbtn[1] = 1;
					else Vbtn[1] = 0;
					if (Vbtn[1] == 1 && !hold2)
					{
						hold2 = true;
						List<Button> copy = new List<Button>(uiManager.buttons);
						foreach (Button button in copy)
						{
							if (button.Focused)
							{
								button.PerformClick();
							}
						}
					}
					else if (hold && Vbtn[1] == 0) hold2 = false;
				}
			}
		}
		//Event that occurs when escape is pressed when the game is paused
        private void InputManager_isEscapeDown(Keys key)
        {
            e_hold = true;
            paused = false;
            uiManager.ClearUi<PauseMenuUi>();
			inputManager.isEscapeDown -= InputManager_isEscapeDown;
        }
		//Event that occurs when any keys are up
        private void onKeyUp(object sender, KeyEventArgs e)
		{
			inputManager.onKeyUp(e.KeyCode);
		}
		//Event that occurs when any keys are down
		private void onKeyDown(object sender, KeyEventArgs e)
		{
			inputManager.onKeyDown(e.KeyCode);
		}


	}
}
