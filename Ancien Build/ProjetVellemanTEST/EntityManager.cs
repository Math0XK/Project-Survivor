using System;
using System.Collections.Generic;
using System.Linq;
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
            foreach(BaseEntity entity in entities)
            {
                if(entity is T entit)
                {
                    entit.mainPanel.Dispose();
                }
                
            }
            
        }

        public bool collision(Panel Player)
        {
            bool collisionX = false;
            bool collisionY = false;

            foreach (BaseEntity entity in entities)
            {
                Panel panel = entity.mainPanel;
                if(panel.Visible)
                {
                    for (int i = 0; i < Player.Height; i++)
                    {
                        for (int j = 0; j < panel.Height; j++)
                        {
                            if (Player.Top + i == panel.Top + j)
                            {
                                collisionX = true;
                                break;
                            }
                        }
                    }
                    for (int i = 0; i < Player.Width; i++)
                    {
                        for (int j = 0; j < panel.Width; j++)
                        {
                            if (Player.Left + i == panel.Left + j)
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
                
            if (collisionX && collisionY) return true;
            else return false;
        }

        public void moveEntity()
        {
            bool isMoving = true;
            foreach (BaseEntity entity in entities)
            {
                if (entity is MovingEntity movingEntity)
                {
                    if (movingEntity.endPos.Y > movingEntity.mainPanel.Location.Y) movingEntity.mainPanel.Top += 1;
                }
                if (entity is MovingEntityLeftDiagonal movingEntityLeftDiagonal)
                {
                    if (movingEntityLeftDiagonal.endPos.Y > movingEntityLeftDiagonal.mainPanel.Location.Y) movingEntityLeftDiagonal.mainPanel.Top += 1;
                    else isMoving = false;
                    if (isMoving && movingEntityLeftDiagonal.endPos.X > 0)
                    {
                        movingEntityLeftDiagonal.mainPanel.Left -= 1;
                        movingEntityLeftDiagonal.endPos.X -= 1;
                    }
                }
                if (entity is MovingEntityRightDiagonal movingEntityRightDiagonal)
                {
                    if (movingEntityRightDiagonal.endPos.Y > movingEntityRightDiagonal.mainPanel.Location.Y) movingEntityRightDiagonal.mainPanel.Top += 1;
                    else isMoving = false;
                    if (isMoving && movingEntityRightDiagonal.endPos.X > 0)
                    {
                        movingEntityRightDiagonal.mainPanel.Left += 1;
                        movingEntityRightDiagonal.endPos.X -= 1;
                    }
                }
                if (entity is MovingEntityPattern01 movingEntityPattern01)
                {
                    if (movingEntityPattern01.endPos.Y > movingEntityPattern01.mainPanel.Location.Y) movingEntityPattern01.mainPanel.Top += 1;
                    else isMoving = false;
                    if (movingEntityPattern01.cpt1 > 0)
                    {
                        movingEntityPattern01.mainPanel.Left -= (int)Math.Ceiling((500f - ((float)movingEntityPattern01.cpt1) * 10f) / 100f);
                        movingEntityPattern01.cpt1 -= 1;
                    }
                    else if (movingEntityPattern01.cpt2 > 0)
                    {
                        movingEntityPattern01.mainPanel.Left += (int)Math.Ceiling((500f - ((float)movingEntityPattern01.cpt2) * 10f) / 100f);
                        movingEntityPattern01.cpt2 -= 1;
                    }
                    else if (movingEntityPattern01.cpt1 == 0)
                    {
                        movingEntityPattern01.cpt1 = movingEntityPattern01.setup;
                        movingEntityPattern01.cpt2 = movingEntityPattern01.setup;
                    }

                }
            }
        }
    }
}
