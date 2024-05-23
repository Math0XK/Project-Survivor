using ProjetVellemanTEST.GameEngine.EntityManager;
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
                    }
                }
            }

            if (collisionX && collisionY) return true;
            else return false;
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
            foreach (BaseEntity entity in entities)
            {
                if(entity is ProjectileEntity projectile)
                {
                    projectile.mainPanel.Top -= 10;
                }
              
            }
        }

        public void destroyEntity()
        {
            List<BaseEntity> copy = new List<BaseEntity>(entities);
            foreach (BaseEntity entity in copy)
            {
                if (entity.destroyed && entity is not ProjectileEntity)
                {
                    frmAppMain.soundManager.PlaySoundEffect(frmAppMain.soundManager.hitSoundEffect);
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
    }
}
