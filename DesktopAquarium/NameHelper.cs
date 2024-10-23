using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopAquarium
{
    public class NameHelper
    {
        // names from ChatGPT
        private List<string> names = new List<string>
        {
            "Jacob", "James", "Jared", "Jason", "Jasper", "Jeffrey", "Jennifer", "Jeremy", "Jerry", "Jessica",
            "Jesse", "Joan", "Joanna", "Joe", "Joel", "John", "Johnny", "Jonathan", "Jordan", "Joseph",
            "Joshua", "Joy", "Joyce", "Judy", "Julia", "Julian", "Julie", "Justin", "Jack", "Jackson",
            "Jill", "Janet", "Jasmine", "Javier", "Jade", "Josie", "Jake", "Jaden", "Jamie", "Jaxon",
            "Aaron", "Abigail", "Adam", "Aiden", "Alex", "Alice", "Alicia", "Amber", "Amy", "Andrew",
            "Anna", "Anthony", "Ashley", "Austin", "Albert", "Bella", "Benjamin", "Blake", "Brenda", "Brian",
            "Brooke", "Bruno", "Bailey", "Baxter", "Cameron", "Carlos", "Caroline", "Carter", "Chloe", "Charles",
            "Charlotte", "Chester", "Cleo", "Clara", "Cody", "Connor", "Cooper", "Caleb", "Cynthia", "Daisy",
            "Daniel", "David", "Derek", "Diana", "Diane", "Dylan", "Dakota", "Dexter", "Edward", "Elena",
            "Eli", "Elijah", "Ella", "Emily", "Emma", "Eric", "Ethan", "Evelyn", "Eva", "Finn",
            "Fiona", "Faith", "Felix", "Freddie", "Gabriel", "Gavin", "George", "Georgia", "Greg", "Grace",
            "Ginger", "Hannah", "Harold", "Harper", "Hazel", "Henry", "Holly", "Hunter", "Ian", "Irene",
            "Isaac", "Isabella", "Isabelle", "Ivy", "Jackie", "Katherine", "Kathryn", "Keith", "Kelly", "Kevin",
            "Kyle", "Kira", "Kingston", "Liam", "Laura", "Leah", "Logan", "Linda", "Lucy", "Luke",
            "Luna", "Leo", "Madison", "Maggie", "Marcus", "Mason", "Matthew", "Max", "Maxwell", "Milo",
            "Molly", "Nate", "Nathan", "Nicholas", "Nicole", "Nina", "Noah", "Olivia", "Oscar", "Owen",
            "Oliver", "Pamela", "Patrick", "Paul", "Penelope", "Piper", "Phoebe", "Quinn", "Quincy", "Rachel",
            "Raymond", "Rebecca", "Riley", "Rocky", "Roger", "Rosie", "Ruby", "Ryan", "Sadie", "Sam",
            "Samantha", "Samuel", "Sarah", "Scott", "Sebastian", "Sophie", "Spencer", "Stella", "Stephanie", "Steven",
            "Sunny", "Sydney", "Teddy", "Thomas", "Timothy", "Toby", "Tyler", "Victoria", "Violet", "Walter",
            "Wendy", "Will", "William", "Willow", "Winston", "Wyatt", "Xander", "Yara", "Yvonne", "Zachary",
            "Zane", "Zoey", "Zoe"
        };

        public string GetRandomName()
        {
            var r = new Random(DateTime.Now.GetHashCode());
            var index = r.Next(0, names.Count);

            return names[index];
        }

    }
}
