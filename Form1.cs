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
		private int velocity = 7;
		internal int hp = 8;
		internal InputManager inputManager;
		internal EntityManager entityManager;
		internal PlayerEntity pnlPlayer;
		internal UiManager uiManager;
		internal SoundManager soundManager;
		internal int gameLayer = 0;
		internal int charge = 3;
		internal int currentProjectile = 0;
		internal bool hold = false;

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

			if(mainCpt == 200)
			{
				entityManager.CreateEntity<MovingEntitiy>();
				MovingEntitiy movingEntitiy = entityManager.CreateEntity<MovingEntitiy>();
				movingEntitiy.location = new Point(110, 600);
				//movingEntitiy.destroyed = true;
				
			}


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
					if (pnlPlayer.mainPanel.Right <= grpMain.Width)
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

				}
				else
				{
                    pnlPlayer = entityManager.CreateEntity<PlayerEntity>();
                    pnlPlayer.size = new Size(20, 20);
                    pnlPlayer.location = new Point(0, grpMain.Height - pnlPlayer.mainPanel.Height);
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
			}
			if (gameLayer == 0)
			{
				uiManager.StartupAnimation();
			}
			/*entityManager.frmAppMain.grpMain.ResumeLayout(false);
			entityManager.frmAppMain.grpMain.PerformLayout();
			entityManager.frmAppMain.ResumeLayout(false);*/

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
