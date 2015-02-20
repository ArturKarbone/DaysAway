using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaysAway.DataModel
{
    public class CommitmentInMemoryRepository : DaysAway.Repositories.ICommitmentRepository
    {
        static List<Commitment> Commitments = new List<Commitment>
            {
                new Commitment
                {
                    Id = 1,
                    Title = "100 Push ups",
                    DueDate = DateTime.Now.AddDays(30)
                },
                new Commitment()
                {
                    Id  = 2, 
                    Title = "Mobile LOB expert",
                    DueDate = DateTime.Now.AddDays(50)
                }
            };

        public async Task<List<Commitment>> GetAll()
        {
            return await Task.Run<List<Commitment>>(() => Commitments);
        }

        public async Task<Commitment> Get(int key)
        {
            return await Task.Run(() => Commitments.First(x => x.Id == key));
        }

        public async Task<Commitment> InsertUpdate(Commitment commitment)
        {
            return await Task.Run(async () =>
            {
                if (commitment.Id == 0)
                {
                    commitment.Id = Commitments.Count + 1;
                    Commitments.Add(commitment);
                    return commitment;
                }
                else
                {

                    var existingCommitment = await Get(commitment.Id);

                    Commitments.RemoveAt(commitment.Id - 1);

                    existingCommitment.Title = commitment.Title;
                    existingCommitment.DueDate = commitment.DueDate;

                    Commitments.Insert(existingCommitment.Id - 1, existingCommitment);

                    return existingCommitment;
                }
            });
        }
    }
}
