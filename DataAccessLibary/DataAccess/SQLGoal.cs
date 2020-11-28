using MyGoalPlanner.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibary.DataAccess
{
    public class SQLGoal : ISQLGoal
    {
        private readonly ISqlDataAccess _db;

        public SQLGoal(ISqlDataAccess db)
        {
            _db = db;
        }


        public Task<List<Goal>> GetGoals()
        {
            string sql = "select * from dbo.Goal";

            return _db.LoadData<Goal, dynamic>(sql, new { });
        }

        public Task InsertGoal(Goal goal)
        {
            string sql = @"insert into dbo.Goal (Name, Description, TimeStart)
                            values (@Name, @Description, @TimeStart);";

            return _db.SaveData(sql, goal);
        }


        /*
         *  public string Name { get; set; }
            public string Description { get; set; }
            public DateTime TimeStart { get; set; }
            public DateTime TimeEnd { get; set; }
         */
    }
}
