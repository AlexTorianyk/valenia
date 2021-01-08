using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using Dapper;

namespace Valenia.Visas
{
    public static class Queries
    {
        public static Task<IEnumerable<ReadModels.VisaDetails>> Query(this DbConnection connection,
            QueryModels.GetVisaDetails query)
            => connection.QueryAsync<ReadModels.VisaDetails>(
                "SELECT \"VisaId\", \"Goal_Value\" goal, Type, \"ExpectedProcessingTime_Value\" expectedprocessingtime" +
                "FROM \"Visa\" WHERE \"VisaId\"=@VisaId", new
                {
                    query.VisaId
                });

        public static Task<IEnumerable<ReadModels.VisaGoal>> Query(this DbConnection connection,
            QueryModels.GetVisaGoalsByType query)
            => connection.QueryAsync<ReadModels.VisaGoal>(
                "SELECT \"VisaId\", \"Goal_Value\" goal" +
                "FROM \"Visa\" WHERE \"Type\"=@Type LIMIT @PageSize OFFSET @Offset", new
                {
                    query.Type,
                    query.PageSize, 
                    Offset = Offset(query.Page, query.PageSize)
                });

        public static Task<IEnumerable<ReadModels.RequirementsDetails>> Query(this DbConnection connection,
            QueryModels.GetVisaRequirements query)
        {
            return connection.QueryAsync<ReadModels.RequirementsDetails>(
                @"SELECT VisaId, ExpectedProcessingTime_Value expectedprocessingtime, 
                    FROM Visa, Requirement
                    WHERE VisaId = @VisaId", new
                {
                    query.VisaId
                });
        }

        private static int Offset(int page, int pageSize) => page * pageSize;
    }
}
