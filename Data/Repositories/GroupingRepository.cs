using Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace Data.Repositories
{
    /// <summary>
    /// GroupingRepository class
    /// </summary>
    /// <seealso cref="Data.BaseRepository" />
    /// <seealso cref="Data.Repositories.IGroupingRepository" />
    public class GroupingRepository : BaseRepository, IGroupingRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupingRepository"/> class.
        /// </summary>
        /// <param name="factory">The factory.</param>
        public GroupingRepository(IConnectionFactory factory) : base(factory)
        {
        }

        /// <summary>
        /// Gets the grouping.
        /// </summary>
        /// <returns>List of GroupingModel</returns>
        public async Task<IList<GroupingModel>> GetGrouping()
        {
            return await WithConnection(async c =>
            {
                var result = await c.QueryAsync<GroupingModel>(sql: "call spGetGrouping()", commandType: CommandType.Text, param: null).ConfigureAwait(false);
                return result.AsList();
            }).ConfigureAwait(false);
        }
    }
}
