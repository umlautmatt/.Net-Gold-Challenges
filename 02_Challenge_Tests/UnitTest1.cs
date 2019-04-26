using System;
using System.Collections;
using System.Collections.Generic;
using _02_Challenge_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_Challenge_Tests
{
    [TestClass]
    public class ClaimsTests
    {
        [TestMethod]
        public void CheckAddToQueue()
        {
            //arrange
            ClaimRepository claimRepo = new ClaimRepository();
            Claim claim = new Claim(ClaimType.Home, 789, "shed fire", 500m, new DateTime(2019, 4, 1), new DateTime(2019, 4, 3), true);

            //act
            claimRepo.AddToQueue(claim);
            Queue<Claim> queueClaim = claimRepo.GetClaimQueue();

            //assert
            Assert.AreSame(claim, queueClaim);
        }

        [TestMethod]
        public void CheckGoToNextClaim()
        {
            //arrange
            ClaimRepository claimRepo = new ClaimRepository();
            Claim claim = new Claim(ClaimType.Home, 789, "shed fire", 500m, new DateTime(2019, 4, 1), new DateTime(2019, 4, 3), true);
            Claim claimTwo = new Claim(ClaimType.Car, 1100, "drove in river", 1249m, new DateTime(2019, 2, 1), new DateTime(2019, 2, 3), false);

            //act
            claimRepo.AddToQueue(claim);
            claimRepo.AddToQueue(claimTwo);

            var expected = claim;
            var actual = claimRepo.GoToNextClaim();

            //assert
            Assert.AreSame(expected, actual);
        }

        [TestMethod]
        public void CheckPeekNextClaim()
        {
            ClaimRepository claimRepo = new ClaimRepository();
            Claim claim = new Claim(ClaimType.Home, 789, "shed fire", 500m, new DateTime(2019, 4, 1), new DateTime(2019, 4, 3), true);
            Claim claimTwo = new Claim(ClaimType.Car, 1100, "drove in river", 1249m, new DateTime(2019, 2, 1), new DateTime(2019, 2, 3), false);

            claimRepo.AddToQueue(claim);
            claimRepo.AddToQueue(claimTwo);

            var expected = claim;
            var actual = claimRepo.PeekNextClaim();

            Assert.AreSame(expected, actual);
        }
    }
}
