using downloadSystem;
using downloadSystem.DataHandler;
using downloadSystem.Models;
using static System.Net.Mime.MediaTypeNames;


namespace DownloadSystem
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            /*  Menu start  */

            Console.WriteLine("Download System started!");
            Console.WriteLine("Menu - Please, select one of the following API'S:");
            Console.WriteLine("1. Zoom API");
            Console.WriteLine("2. Ring Central API");

            Console.Write("Enter your choice (1-2): ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("You selected Zoom API ");
                        //apiObj = new graphAuth();
                        break;
                    case 2:
                        Console.WriteLine("You selected Ring Central API");
                        //apiObj = new googleAuth();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 7.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }

           /* End */
           

            var filePath = "//Mac/Home/Downloads/Test.MP4";

            using (var context = new AppDbContext())
            {
                var videoRecording = new Recording();

                videoRecording.FileName = Path.GetFileName(filePath);

                // Read the video file into a byte array
                videoRecording.VideoData = File.ReadAllBytes(filePath);

                var videoUploader = new VideoUploader();
                videoUploader.UploadVideoToDatabase(context, videoRecording);




                //Find video using Id
                int userNumber;

                while (true)
                {
                    Console.WriteLine("Enter an integer:");

                    string userInput = Console.ReadLine();

                    if (int.TryParse(userInput, out userNumber))
                    {
                        Console.WriteLine($"You entered an integer: {userNumber}");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer.");
                    }
                }


                videoUploader.PlayVideoFromDatabase(userNumber);
            }




            


            /*
            using (var context = new AppDbContext())
            {
                // Add new person
                var person = new Person { Name = "John Doe", Age = 30 };
                context.MyDbSet.Add(person);
                context.SaveChanges();

                Console.WriteLine("Person added:");

                // Display all people
                var people = context.MyDbSet.ToList();
                foreach (var p in people)
                {
                    Console.WriteLine($"Id: {p.Id}, Name: {p.Name}, Age: {p.Age}");
                }

                // Update the person's age
                var personToUpdate = context.MyDbSet.First();
                personToUpdate.Age = 31;
                context.SaveChanges();

                Console.WriteLine("\nPerson updated:");

                // Display all people after update
                var updatedPeople = context.MyDbSet.ToList();
                foreach (var p in updatedPeople)
                {
                    Console.WriteLine($"Id: {p.Id}, Name: {p.Name}, Age: {p.Age}");
                }

                // Remove the person
                context.MyDbSet.Remove(personToUpdate);
                context.SaveChanges();

                Console.WriteLine("\nPerson removed:");

                // Display all people after removal
                var remainingPeople = context.MyDbSet.ToList();
                foreach (var p in remainingPeople)
                {
                    Console.WriteLine($"Id: {p.Id}, Name: {p.Name}, Age: {p.Age}");
                }
            }
            */
        }




    }
}
