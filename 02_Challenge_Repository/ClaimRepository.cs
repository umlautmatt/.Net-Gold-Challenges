using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Challenge_Repository
{
    public class ClaimRepository
    {
        private Queue<Claim> _claimQueue = new Queue<Claim>();

        public void AddToQueue(Claim claim)
        {
            _claimQueue.Enqueue(claim);
        }

        public Claim GoToNextClaim()
        {
            Claim nextClaim = _claimQueue.Dequeue();
            return nextClaim;
        }

        public Claim PeekNextClaim()
        {
            return _claimQueue.Peek();
        }

        public Queue<Claim> GetClaimQueue()
        {
            return _claimQueue;
        }

        //public int GetClaimQueueCount()
        //{
        //    int queueClaimCount = _claimQueue.Count;
        //    return queueClaimCount;
        //}
    }
}
