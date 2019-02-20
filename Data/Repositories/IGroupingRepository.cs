using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    /// <summary>
    /// IGroupingRepository interface
    /// </summary>
    public interface IGroupingRepository
    {
        Task<IList<GroupingModel>> GetGrouping();
    }
}
