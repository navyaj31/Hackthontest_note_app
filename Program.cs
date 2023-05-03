using System.Collections.Generic;
using System.Reflection;
using System.Xml;

namespace NotesAssignment
{
    class notes
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

    }
    class notesdetails
    {
        List<notes> list;
        public int notesId = 1;

        public notesdetails()
        {
            list = new List<notes>();
            /*{
                new notes { Id = notesId++, Title = "songs", Description = "the songs of various movies", Date="12/05/2001" },
                new notes { Id = notesId++, Title = "Movies", Description = "List of various movies" }
            };*/
        }



        public void Addnotes()
        {
            int id = notesId++;
            Console.WriteLine("Enter notes title: ");
            string title = Console.ReadLine();
            Console.WriteLine("Enter the description of the notes:  ");
            string description = Console.ReadLine();
            DateTime date = DateTime.Now;
            list.Add(new notes() { Id = id, Title = title, Description = description, Date= date});
            Console.WriteLine("Notes is successfully created");

        }


        public notes Getnotes(int id)

        {
            foreach (notes n in list)
            {
                if (n.Id == id)
                    return n;
            }
            return null;
        }
        public List<notes> GetAllnotes()
        {
            return list;
        }

        public bool Deletenotes(int id)
        {
            foreach (notes n in list)
            {
                if (n.Id == id)
                {
                    list.Remove(n);
                    return true;
                }

            }
            return false;
        }
        public void updatenotes(int id)
        {
            foreach (notes n in list)
            {
                if (n.Id == id)
                {
                    Console.WriteLine("Enter the updated title:");
                     n.Title = Console.ReadLine();
                    Console.WriteLine("Enter the updated description:");
                    n.Description = Console.ReadLine();
                    n.Date = DateTime.Now;


                    Console.WriteLine("Notes Details Updated Successfully");
                }

            }

        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            notesdetails details = new notesdetails();
      
            while (true)
            {
                Console.WriteLine("1. Create notes");
                Console.WriteLine("2. Get notes  By Id");
                Console.WriteLine("3. Get All notes");
                Console.WriteLine("4. Delete notes By Id");
                Console.WriteLine("5. Update notes By Id");
                Console.WriteLine("Enter Your choice: ");
                int choice = 0;
                try
                {
                    choice = Convert.ToInt16(Console.ReadLine());

                }
                catch(FormatException)
                {
                    Console.WriteLine("Enter integer values");
                }
               
                
                switch (choice)
                {
                    case 1:
                        {
                            details.Addnotes();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Enter notes id:");
                            int id = 0;
                            try
                            {
                                id = Convert.ToInt16(Console.ReadLine());
                            }
                            catch(FormatException)
                            {
                                Console.WriteLine("Enter only interger values");
                            }
                            notes? n = details.Getnotes(id);
                            if (n == null)
                            {
                                Console.WriteLine("notes not exists");
                            }
                            else
                            {
                                Console.WriteLine($"notes Details of id-{n.Id}:");
                                Console.WriteLine($"Title:{n.Title}\tdescription:{n.Description}\tdate:{n.Date}");
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("ID\t Title\t\t Description\t\t Date");
                            foreach (var n in details.GetAllnotes())
                            {
                                Console.WriteLine($"{n.Id}\t{n.Title}\t\t{n.Description}\t\t{n.Date}");

                            }
                            Console.WriteLine();
                            Console.Write("Total Notes : ");
                            Console.Write(details.notesId);
                            Console.WriteLine();
                            break;
                        }
                    case 4:
                        {

                            Console.WriteLine("Enter Notes Id");
                            int id = 0;
                            try
                            {
                                id = Convert.ToInt16(Console.ReadLine());
                            }
                            catch(FormatException)
                            {
                                Console.WriteLine("Enter only interger values");
                            }
                            if (details.Deletenotes(id))
                            {
                                Console.WriteLine("Notes Deleted Successfully");
                            }
                            else
                            {
                                Console.WriteLine("Notes not exist");
                            }
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Enter notes Id");
                            int id = 0;
                            try
                            {
                                id = Convert.ToInt16(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Enter only interger values");
                            }
                            details.updatenotes(id);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid Choice");
                            break;
                        }



                }
               
               
            } 

        }
    }
}