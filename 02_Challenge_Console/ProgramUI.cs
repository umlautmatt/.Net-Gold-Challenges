using _02_Challenge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Challenge_Console
{
    public class ProgramUI
    {
        private ClaimRepository _claimRepo = new ClaimRepository();

        int _response;
        internal void Run()
        {
			while(_response != 4)
            {
                PrintMenu();
                SeedList();
                switch (_response)
                {
                    case 1:
                        SeeAllClaims();
                        break;
                    case 2:
                        TakeCareOfNextClaim();
                        break;
                    case 3:
                        EnterNewClaim();
                        break;
                    case 4:
                        Console.WriteLine("Have a nice day!");
                        break;
                    default:
                        Console.WriteLine("Please enter a correct value.");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }

        }
        private void PrintMenu()
        {
            Console.WriteLine("What would you like to do?\n\t" +
                "1. See All Claims\n\t" +
                "2. Take Care Of Next Claim\n\t" +
                "3. Enter New Claim\n\t" +
                "4. Exit Program");
            _response = int.Parse(Console.ReadLine());
        }
        private void SeeAllClaims()
        {
            Queue<Claim> queue = _claimRepo.GetClaimQueue();
			
			foreach(Claim c in queue)
            {
                Console.WriteLine($"Claim Type: {c.CType}\n\t" +
					$"Claim ID: {c.ClaimID}\n\t" + 
					$"Description: {c.Description}\n\t" +
                    $"Claim Amount: {c.ClaimAmount}\n\t" +
                    $"Date of Incident: {c.DateOfIncident}\n\t" +
                    $"Date of Claim: {c.DateOfClaim}\n\t" +
                    $"Claim made within 30 days(valid)? {c.IsValid}\n\t");
            }
        }
		private void TakeCareOfNextClaim()
        {
            Claim peekClaim = _claimRepo.PeekNextClaim();

            //Here are the details for the next claim to be handled:
            Console.WriteLine($"Claim Type: {peekClaim.CType}\n" +
                    $"Claim ID: {peekClaim.ClaimID}\n" +
                    $"Description: {peekClaim.Description}\n" +
                    $"Claim Amount: {peekClaim.ClaimAmount}\n" +
                    $"Date of Incident: {peekClaim.DateOfIncident}\n" +
                    $"Date of Claim: {peekClaim.DateOfClaim}\n" +
                    $"Claim made within 30 days(valid)? {peekClaim.IsValid}");

            Console.WriteLine("Do you want to deal with this claim now (y/n)?");
            string yesOrNo = Console.ReadLine().ToLower();
           
            switch (yesOrNo)
            {
                case "y":
                case "yes":
                    Claim nextClaim = _claimRepo.GoToNextClaim();
                    Console.WriteLine($"Claim Type: {nextClaim.CType}\n" +
                    $"Claim ID: {nextClaim.ClaimID}\n" +
                    $"Description: {nextClaim.Description}\n" +
                    $"Claim Amount: {nextClaim.ClaimAmount}\n" +
                    $"Date of Incident: {nextClaim.DateOfIncident}\n" +
                    $"Date of Claim: {nextClaim.DateOfClaim}\n" +
                    $"Claim made within 30 days(valid)? {nextClaim.IsValid}");
                    break;
                case "n":
                case "no":
                    PrintMenu();
                    break;
            }
        }

		private void EnterNewClaim()
        {
            Console.WriteLine("What will the claim type be?" +
                "1. Car" +
                "2. Home" +
                "3. Theft");
            int input = int.Parse(Console.ReadLine());
            ClaimType cType = (ClaimType)input;

            Console.WriteLine("What will be the claim ID number for this claim: ");
            int claimId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter a description of the new claim: (Ex: Wreck on I-70");
            string description = Console.ReadLine();

            Console.WriteLine("Amount of damage(decimal amount): ");
            string damageAsString = Console.ReadLine();
            int claimAmount = int.Parse(damageAsString);

            Console.WriteLine("Date of Incident: ");
            string incidentDate = Console.ReadLine();
            DateTime dateOfIncident = DateTime.Parse(incidentDate);

            Console.WriteLine("Date of Claim: ");
            string claimDate = Console.ReadLine();
            DateTime dateOfClaim = DateTime.Parse(claimDate);

            Console.WriteLine("Is this claim valid (made within 30 days of incident)? y/n");
            string isValidString = Console.ReadLine().ToLower();
            bool isValid = false;
            switch (isValidString)
            {
                case "y":
                case "yes":
                    isValid = true;
                    break;
                case "n":
                case "no":
                    isValid = false;
                    break;
            }

            Claim newClaim = new Claim(cType, claimId, description, claimAmount, dateOfIncident, dateOfClaim, isValid);
  
			_claimRepo.AddToQueue(newClaim);
        }

		private void SeedList()
        {
            _claimRepo.AddToQueue(new Claim(ClaimType.Car, 2314, "wreck on 21st street", 1200m, new DateTime(2019, 4, 27), new DateTime(2019, 4, 28), true));
            _claimRepo.AddToQueue(new Claim(ClaimType.Home, 1443, "pantry fire", 1400m, new DateTime(2019, 3, 27), new DateTime(2019, 3, 28), true));
            _claimRepo.AddToQueue(new Claim(ClaimType.Car, 1411, "drove in to river", 2400m, new DateTime(2018, 3, 15), new DateTime(2018, 4, 28), false));
            _claimRepo.AddToQueue(new Claim(ClaimType.Theft, 1133, "vcr was stolen", 1800m, new DateTime(2019, 2, 10), new DateTime(2019, 3, 01), true));
            _claimRepo.AddToQueue(new Claim(ClaimType.Home, 1134, "broken water pipe", 12000m, new DateTime(2019, 4, 1), new DateTime(2019, 4, 2), true));
        }
    }
}
