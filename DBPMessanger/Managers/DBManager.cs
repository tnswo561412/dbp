using DBPMessanger.Config;
using DBPMessanger.infos;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;



namespace DBPMessanger.Managers
{
    public class DBManager
    {
        // TODO
        // 잘못된 쿼리를 받았을 때 오류 처리

        public static DBManager Instance = new DBManager();
        private DBManager() { }

        public void Insert<T>(T entity) where T : class
        {
            using var context = new AppDBContext();
            context.Set<T>().Add(entity);  // 엔티티 추가
            context.SaveChanges();
        }

        public void Update<T>(T entity) where T : class
        {
            using var context = new AppDBContext();
            context.Set<T>().Update(entity); // 엔티티 업데이트
            context.SaveChanges();
        }

        public void Delete<T>(T entity) where T : class
        {
            using var context = new AppDBContext();
            context.Set<T>().Remove(entity); // 엔티티 삭제
            context.SaveChanges();
        }

        public List<T>? Query<T>(Func<IQueryable<T>, IQueryable<T>>? filter = null) where T : class
        {
            using var context = new AppDBContext();
            IQueryable<T> q = context.Set<T>();

            if (filter != null)
                q = filter(q);

            return q.ToList();
        }
    }
}
