using System.Collections.Generic;

namespace SP101K.Repo
{

    public interface userRepo<TEntity>
    {
        IEnumerable<TEntity> Users();
        TEntity getUser(int id);
        void addUser(TEntity entity);
        void updateUser(TEntity dbEntity, TEntity entity);
        void deleteUser(TEntity entity);
    }

}
