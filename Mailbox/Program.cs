using System;
using System.IO;

namespace Mailbox
{    class Program {
        private const int WIDTH = 50;
        private const int HEIGHT = 10;

        static void Main(string[] args) {
            //Main does not need to be unit tested.
            using var dataLoader = new DataLoader(File.Open("Mailboxes.json", FileMode.OpenOrCreate, FileAccess.ReadWrite));

            Mailboxes boxes = new Mailboxes(dataLoader.Load() ?? new Mailbox[WIDTH, HEIGHT]);

            while (true) {
                int selection;
                do {
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("1. Add a new mail box.");
                    Console.WriteLine("2. List existing owners.");
                    Console.WriteLine("3. Save changes.");
                    Console.WriteLine("4. Show mail box details.");
                    Console.WriteLine("5. Quit.");

                    if(!int.TryParse(Console.ReadLine(), out selection)) {
                        Console.WriteLine("Make a valid selection!\n");
                        selection = 0;
                    }
                } while (selection == 0);

                switch (selection) {
                    case 1:
                        Console.WriteLine("Enter the first name");
                        string firstName = Console.ReadLine();
                        Console.WriteLine("Enter the last name");
                        string lastName = Console.ReadLine();
                        Console.WriteLine("What size?");
                        if(!Enum.TryParse(Console.ReadLine(), out Sizes size)) {
                            size = Sizes.Small;
                        }

                        if(AddNewMailbox(boxes, firstName, lastName, size) is Mailbox mailbox) {
                            boxes.mMailBoxesArray[mailbox.mLocation.Item1, mailbox.mLocation.Item2] = mailbox;
                            Console.WriteLine("New mail box added.");
                        } else {
                            Console.WriteLine("No available location.");
                        }
                        break;
                    case 2:
                        Console.WriteLine(GetOwnersDisplay(boxes));
                        break;
                    case 3:
                        dataLoader.Save(boxes.mMailBoxesArray);
                        Console.WriteLine("Saved.");
                        break;
                    case 4:
                        Console.WriteLine("Enter mail box number as x,y.");
                        string mailBoxNumber = Console.ReadLine();
                        string[] boxNumberParts = mailBoxNumber?.Split(',');
                        if(boxNumberParts?.Length == 2 && int.TryParse(boxNumberParts[0], out int x) && int.TryParse(boxNumberParts[1], out int y)) {
                            Console.WriteLine(GetMailboxDetails(boxes, x, y));
                        } else {
                            Console.WriteLine("Invalid mail box number.");
                        }
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Make a valid selection!\n");
                        break;

                }
            }
        }

        public static string GetOwnersDisplay(Mailboxes mailboxes) {
            string result = "";
            foreach (Mailbox mailbox in mailboxes.mMailBoxesArray) {
                if(mailbox is null) {
                    continue;
                }
                if(!result.Contains(mailbox.mOwner.toString())) {
                    result += mailbox.mOwner.toString() + "\n";
                }
            }
            return result;
        }

        public static string GetMailboxDetails(Mailboxes mailboxes, int xPosition, int yPosition) {
            try {
                return mailboxes.mMailBoxesArray[xPosition, yPosition].toString();
            } catch (NullReferenceException)
            {
                return "Mailbox is not used.";
            }
        }

        public static Mailbox AddNewMailbox(Mailboxes mailboxes, string firstName, string lastName, Sizes mailBoxSize) {
            Person mailBoxOwner = new Person(firstName, lastName);
            (int, int) mailBoxLocation = mailboxes.FindValidLocation(mailBoxOwner);
            if (mailBoxLocation.Equals((-1, -1))) {
                return null;
            }
            return new Mailbox(mailBoxSize, mailBoxLocation, mailBoxOwner);
        }
    }
}
