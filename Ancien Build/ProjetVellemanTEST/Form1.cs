using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        long mainCpt = 0;
        private bool game = false;
        private int velocity = 7;
        internal InputManager inputManager;
        internal EntityManager entityManager;

        public frmAppMain()
        {
            InitializeComponent();
            //pnlPlayer.Visible = false;
            inputManager = new InputManager();
            entityManager = new EntityManager(this);
            game = true;


        }




        private void gameUpdate(object sender, EventArgs e)
        {
            /*if(mainCpt == 1)
            {
                MovingEntity movingEntity = entityManager.CreateEntity<MovingEntity>();
                movingEntity.mainPanel.Top = 100;
                movingEntity.mainPanel.Left = 100;
                movingEntity.mainPanel.BackColor = Color.Red;
                movingEntity.endPos = new Point(500, 400);
                MovingEntityLeftDiagonal movingEntityLeftDiagonal = entityManager.CreateEntity<MovingEntityLeftDiagonal>();
                movingEntityLeftDiagonal.mainPanel.Top = 100;
                movingEntityLeftDiagonal.mainPanel.Left = 700;
                movingEntityLeftDiagonal.endPos = new Point(900, 300);
                MovingEntityPattern01 movingEntityPattern01 = entityManager.CreateEntity<MovingEntityPattern01>();
                movingEntityPattern01.mainPanel.Top = 100;
                movingEntityPattern01.mainPanel.Left = 300;
                movingEntityPattern01.endPos = new Point(0, 500);
                movingEntityPattern01.setup = 100;

            }*/


            /*if (mainCpt == 100)
            {
                MovingEntity movingEntity = entityManager.CreateEntity<MovingEntity>();
                movingEntity.mainPanel.Top = 100;
                movingEntity.mainPanel.Left = 100;
                movingEntity.mainPanel.BackColor = Color.Red;
                movingEntity.endPos = new Point(500, 400);
                entityManager.destroyAllEntityGroup<MovingEntityLeftDiagonal>();
            }
            if (mainCpt == 500)
            {
                MovingEntityPattern01 movingEntityPattern01 = entityManager.CreateEntity<MovingEntityPattern01>();
                movingEntityPattern01.mainPanel.Top = 100;
                movingEntityPattern01.mainPanel.Left = 600;
                movingEntityPattern01.endPos = new Point(0, 500);
                movingEntityPattern01.setup = 120;

            }*/



            if (game)
            {
                if (pnlPlayer.Visible)
                {
                    if (pnlPlayer.Top >= 9)
                    {
                        if (inputManager.isKeyPressed(Keys.Z)) pnlPlayer.Top -= velocity;
                    }
                    if (pnlPlayer.Bottom <= grpMain.Height - 5)
                    {
                        if (inputManager.isKeyPressed(Keys.S)) pnlPlayer.Top += velocity;
                    }
                    if (pnlPlayer.Right <= grpMain.Width - 7)
                    {
                        if (inputManager.isKeyPressed(Keys.D)) pnlPlayer.Left += velocity;
                    }
                    if (pnlPlayer.Left >= 7)
                    {
                        if (inputManager.isKeyPressed(Keys.Q)) pnlPlayer.Left -= velocity;
                    }
                }
                
                if (entityManager.collision(pnlPlayer)) lblHit.BackColor = Color.Red;
                else lblHit.BackColor = Color.Green;
                entityManager.moveEntity();
                mainCpt++;
            }
            
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
