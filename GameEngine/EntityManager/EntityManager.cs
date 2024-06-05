using ProjetVellemanTEST.GameEngine.EntityManager;
using ProjetVellemanTEST.GameEngine.K8055DManager;
using ProjetVellemanTEST.GameEngine.UiManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetVellemanTEST
{
    internal class EntityManager
    {
        public frmAppMain frmAppMain {get; private set;}
        public EntityManager(frmAppMain frmAppMain) 
        { 
            this.frmAppMain = frmAppMain;
        }
        internal int K8055Diff;     //Stock the difficulty multiplicator of the K8055

        List<BaseEntity> entities = new List<BaseEntity>();     //Stock entities in a list

        //Method called to create any types of entity
        internal T CreateEntity<T>() where T : BaseEntity, new()
        {
            T entity = new T();
            entities.Add(entity);
            entity.onCreate(this);
            return entity;
        }

        //Collision system
        public bool collision()
        {
            bool collisionX = false;
            bool collisionY = false;

            foreach (BaseEntity entity in entities)
            {
                if (entity is not PlayerEntity && entity is not ProjectileEntity)
                {
                    if (entity.mainPanel.Visible)
                    {
                        for (int i = 0; i < frmAppMain.pnlPlayer.mainPanel.Height; i++)
                        {
                            for (int j = 0; j < entity.mainPanel.Height; j++)
                            {
                                if (frmAppMain.pnlPlayer.mainPanel.Top + i == entity.mainPanel.Top + j)
                                {
                                    collisionX = true;
                                    break;
                                }
                            }
                        }
                        for (int i = 0; i < frmAppMain.pnlPlayer.mainPanel.Width; i++)
                        {
                            for (int j = 0; j < entity.mainPanel.Width; j++)
                            {
                                if (frmAppMain.pnlPlayer.mainPanel.Left + i == entity.mainPanel.Left + j)
                                {
                                    collisionY = true;
                                    break;
                                }
                            }
                        }
                        if (!collisionX || !collisionY)
                        {
                            collisionX = false;
                            collisionY = false;
                        }
                        else
                        {
                            entity.destroyed = true;                            //Entity can be destroyed
                            frmAppMain.score -= entity.points;                  //Remove points from score
                            if(frmAppMain.score <= 0 )frmAppMain.score = 0;     //Avoid the score to go negative
                            if (frmAppMain.cardMode)
                            {
                                Fctvm110.ClearDigitalChannel(frmAppMain.hp);    //Turn off digital output to match the health of the player
                                Fctvm110.OutputAnalogChannel(1, (int)(((float)frmAppMain.score / 20000f) * 255f));  //Display the score on the analog output 1
                            }
                            frmAppMain.hp--;                                    //Decrement 1 HP
                            
                            frmAppMain.soundManager.PlaySoundEffect(frmAppMain.soundManager.hurtSoundEffect);   //Play a funny sound effect
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        //Projectile's collision system
        public bool destruction()
        {
            bool collisionX = false;
            bool collisionY = false;
            foreach (BaseEntity obj in entities)
            {
                if(obj is ProjectileEntity projectile)
                {
                    foreach (BaseEntity entity in entities)
                    {
                        if (entity is not PlayerEntity && entity is not ProjectileEntity)
                        {
                            for (int i = 0; i < projectile.mainPanel.Height; i++)
                            {
                                for (int j = 0; j < entity.mainPanel.Height; j++)
                                {
                                    if (projectile.mainPanel.Top + i == entity.mainPanel.Top + j)
                                    {
                                        collisionX = true;
                                        break;
                                    }
                                }
                            }
                            for (int i = 0; i < projectile.mainPanel.Width; i++)
                            {
                                for (int j = 0; j < entity.mainPanel.Width; j++)
                                {
                                    if (projectile.mainPanel.Left + i == entity.mainPanel.Left + j)
                                    {
                                        collisionY = true;
                                        break;
                                    }
                                }
                            }
                            if (!collisionX || !collisionY)
                            {
                                collisionX = false;
                                collisionY = false;
                            }
                            else
                            {
                                entity.destroyed = true;            //Allow entity to be destroyed
                                projectile.destroyed = true;        //Allow projectile to be destroyed
                                if (frmAppMain.cardMode)
                                {
                                    frmAppMain.score += entity.points * K8055Diff; //Add points to score multiplicated by the difficulty multiplicator
                                }
                                else frmAppMain.score += entity.points;            //Add points to score
                                Fctvm110.OutputAnalogChannel(1, (int)(((float)frmAppMain.score / 20000f) * 255f));      //Display the score to analog output 1
                                frmAppMain.soundManager.PlaySoundEffect(frmAppMain.soundManager.hitSoundEffect);        //Play a funny sound effect
                                return true;
                            }
                        }
                    }
                }
                
            }
            return false;
        }

        //Move entities en give them different pattern for each
        //Types of entities
        public void moveEntity()
        {
            if (frmAppMain.cardMode)
            {
                K8055Diff = (int)(1f + ((float)frmAppMain.data2 / 255f * 4f));
            }
            else K8055Diff = 1;
            foreach (BaseEntity entity in entities)
            {
                if(entity is ProjectileEntity projectile)
                {
                    projectile.mainPanel.Top -= 10;
                }
                if(entity is MovingEntitiy movingEntitiy)
                {
                    movingEntitiy.mainPanel.Top += 1 * frmAppMain.uiManager.mode * K8055Diff;
                }
                if(entity is MovingEntityDiagonal movingEntityDiagonal)
                {
                    if(movingEntityDiagonal.moveRL > 25)
                    {
                        movingEntityDiagonal.mainPanel.Top += 1 * frmAppMain.uiManager.mode * K8055Diff;
                        movingEntityDiagonal.mainPanel.Left += 1 * frmAppMain.uiManager.mode;
                    }
                    else if(movingEntityDiagonal.moveRL <= 25)
                    {
                        movingEntityDiagonal.mainPanel.Top += 1 * frmAppMain.uiManager.mode * K8055Diff;
                        movingEntityDiagonal.mainPanel.Left -= 1 * frmAppMain.uiManager.mode;
                    }
                }
                if(entity is MovingEntityPattern01 pattern01)
                {
                    float move;
                    pattern01.mainPanel.Top += 1 * frmAppMain.uiManager.mode * K8055Diff;
                    move = (float)Math.Sin(frmAppMain.mainCpt/50)*10;
                    if(pattern01.moveRL > 25)
                    {
                        pattern01.mainPanel.Left -= (int)move;
                    }
                    else if(pattern01.moveRL <= 25)
                    {
                        pattern01.mainPanel.Left += (int)move;
                    }
                }
                if(entity is MovingEntityTinyVersion movingEntityTiny)
                {
                    movingEntityTiny.mainPanel.Top += 2 * frmAppMain.uiManager.mode * K8055Diff;
                }
                if(entity is MovingEntityPattern01TinyVersion pattern01TinyVersion)
                {
                    float move;
                    pattern01TinyVersion.mainPanel.Top += 2 * frmAppMain.uiManager.mode * K8055Diff;
                    move = (float)Math.Sin(frmAppMain.mainCpt / 50) * 10;
                    if(pattern01TinyVersion.moveRL > 25)
                    {
                        pattern01TinyVersion.mainPanel.Left += (int)(move * 3 / 2);
                    }
                    else if(pattern01TinyVersion.moveRL <= 25)
                    {
                        pattern01TinyVersion.mainPanel.Left -= (int)(move * 3 / 2);
                    }
                }
              
            }
        }
        
        //Destroy entity if it has to be destroyed
        public void destroyEntity()
        {
            List<BaseEntity> copy = new List<BaseEntity>(entities);
            foreach (BaseEntity entity in copy)
            {
                if ((entity.destroyed || entity.mainPanel.Top>frmAppMain.grpMain.Bottom) && entity is not ProjectileEntity)
                {
                    entities.Remove(entity);
                    entity.onDestroy(this);
                }
                if(entity is ProjectileEntity projectile)
                {
                    if(projectile.mainPanel.Bottom < frmAppMain.grpMain.Top || projectile.destroyed)
                    {
                        entities.Remove(projectile);
                        projectile.onDestroy(this);
                    }
                }
            }
        }
        //Remove all entity
        public void clearAllEntity()
        {
            List<BaseEntity> copy = new List<BaseEntity>(entities);
            foreach(BaseEntity entity in copy)
            {
                entities.Remove(entity);
                entity.onDestroy(this);
            }
        }
    }
}
