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
        internal int K8055Diff;

        List<BaseEntity> entities = new List<BaseEntity>();

        internal T CreateEntity<T>() where T : BaseEntity, new()
        {
            T entity = new T();
            entities.Add(entity);
            entity.onCreate(this);
            return entity;
        }

        internal void destroyAllEntityGroup<T>() where T : BaseEntity
        {
            List<BaseEntity> copy = new List<BaseEntity>(entities);
            foreach(BaseEntity entity in copy)
            {
                if(entity is T entit)
                {
                    entities.Remove(entit);
                    entit.onDestroy(this);
                }
                
            }
            
        }

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
                            entity.destroyed = true;
                            Fctvm110.ClearDigitalChannel(frmAppMain.hp);
                            frmAppMain.hp--;
                            frmAppMain.score -= entity.points;
                            if(frmAppMain.score <= 0 )frmAppMain.score = 0;
                            frmAppMain.soundManager.PlaySoundEffect(frmAppMain.soundManager.hurtSoundEffect);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

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
                                entity.destroyed = true;
                                projectile.destroyed = true;
                                if (frmAppMain.cardMode)
                                {
                                    frmAppMain.score += entity.points * K8055Diff;
                                }
                                else frmAppMain.score += entity.points;
                                Fctvm110.OutputAnalogChannel(1, (int)(((float)frmAppMain.score / 9999f) * 255f));
                                frmAppMain.soundManager.PlaySoundEffect(frmAppMain.soundManager.hitSoundEffect);
                                return true;
                            }
                        }
                    }
                }
                
            }
            return false;
        }

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
