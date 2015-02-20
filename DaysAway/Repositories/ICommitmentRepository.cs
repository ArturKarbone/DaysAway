using System;
namespace DaysAway.Repositories
{
    public interface ICommitmentRepository
    {
        global::System.Threading.Tasks.Task<global::DaysAway.DataModel.Commitment> Get(int key);
        global::System.Threading.Tasks.Task<global::System.Collections.Generic.List<global::DaysAway.DataModel.Commitment>> GetAll();
        global::System.Threading.Tasks.Task<global::DaysAway.DataModel.Commitment> InsertUpdate(global::DaysAway.DataModel.Commitment commitment);
    }
}
