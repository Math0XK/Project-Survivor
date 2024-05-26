using ProjetVellemanTEST.GameEngine.EntityManager;
using ProjetVellemanTEST.GameEngine.SoundManager;
using ProjetVellemanTEST.GameEngine.UiManager;
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
		internal int endGameCpt = 0;
        internal string pseudo;
        internal InputManager inputManager;
		internal EntityManager entityManager;
		internal PlayerEntity pnlPlayer;
		internal UiManager uiManager;
		internal SoundManager soundManager;
		internal int gameLayer = 0;
		internal int charge = 3;
		internal int currentProjectile = 0;
		internal int currentEntity = 0;
		internal Random random = new Random();
		internal bool hold = false;
		internal bool e_hold = false;
		internal bool paused = false;

		public frmAppMain()
		{
			InitializeComponent();
			grpMain.Size = Size;
			//pnlPlayer.Visible = false;
			inputManager = new InputManager();
			entityManager = new EntityManager(this);
			uiManager = new UiManager(this);
			soundManager = new SoundManager(this);
			pnlPlayer = new PlayerEntity();
			if (gameLayer == 0)
			{
				inputManager.isAnyKeyDown += anyKeyDown;
				uiManager.CreateUiComponents<StartupUi>();
			}
			soundManager.PlayMusicLoop(soundManager.startupTheme);
			/*entityManager.CreateEntity<StaticEntity>();
			pnlPlayer = entityManager.CreateEntity<PlayerEntity>();
			pnlPlayer.size = new Size(20, 20);
			pnlPlayer.location = new Point(0, grpMain.Height - pnlPlayer.mainPanel.Height);*/
			//soundManager.StopSound();
		}

		internal void anyKeyDown(Keys keys)
		{
			//écrire mon code ici
			if (gameLayer == 0)
			{
				uiManager.ClearUi<StartupUi>();
				Console.WriteLine("test");
				gameLayer = 1;
				uiManager.CreateUiComponents<MenuUi>();
				inputManager.isAnyKeyDown -= anyKeyDown;
			}
			
		}

		private void gameUpdate(object sender, EventArgs e)
		{
			/*entityManager.frmAppMain.grpMain.SuspendLayout();
			entityManager.frmAppMain.SuspendLayout();*/
			/*if(mainCpt == 100)
			{
				entityManager.destroyAllEntityGroup<StaticEntity>();
			}*/


			if (gameLayer == 999)
			{
				if (pnlPlayer.playerEnabled)
				{
					if (pnlPlayer.mainPanel.Top >= (grpMain.Height) * 3 / 4)
					{
						if (inputManager.isKeyPressed(Keys.Z)) pnlPlayer.mainPanel.Top -= velocity;
					}
					if (pnlPlayer.mainPanel.Bottom <= grpMain.Height - 7)
					{
						if (inputManager.isKeyPressed(Keys.S)) pnlPlayer.mainPanel.Top += velocity;
					}
					if (pnlPlayer.mainPanel.Right <= grpMain.Width - 7)
					{
						if (inputManager.isKeyPressed(Keys.D)) pnlPlayer.mainPanel.Left += velocity;
					}
					if (pnlPlayer.mainPanel.Left >= 7)
					{
						if (inputManager.isKeyPressed(Keys.Q)) pnlPlayer.mainPanel.Left -= velocity;
					}
					if (inputManager.isKeyPressed(Keys.Space) && !hold && currentProjectile < charge)
					{
						currentProjectile++;
						hold = true;
						entityManager.CreateEntity<ProjectileEntity>();
						Console.WriteLine("Porjectile");
						Console.WriteLine(currentProjectile.ToString());
					}
					else if(!inputManager.isKeyPressed(Keys.Space) && hold) hold = false;
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

			}
			if (gameLayer == 0)
			{
				uiManager.StartupAnimation();
			}
			/*entityManager.frmAppMain.grpMain.ResumeLayout(false);
			entityManager.frmAppMain.grpMain.PerformLayout();
			entityManager.frmAppMain.ResumeLayout(false);*/
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
