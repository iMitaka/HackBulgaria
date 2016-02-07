using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Data;
using TicketSystem.Models;
using System.Security.Cryptography;
using System.Globalization;

namespace TicketSystem.ConsoleApp
{
    public class TicketSystemMain
    {
        private static TicketSystemDbContext data = new TicketSystemDbContext();

        public static void Main()
        {           
            Console.WriteLine("1.City wise");
            Console.WriteLine("2.Train wise");
            Console.WriteLine("3.Schedule wise");
            Console.WriteLine("4.Tickets");
            var mainMenuKey = Console.ReadKey();
            if (mainMenuKey.Key == ConsoleKey.D1)
            {
            CityMenu:
                Console.Clear();
                Console.WriteLine("City wise:");
                Console.WriteLine();
                Console.WriteLine("1.Get all cities");
                Console.WriteLine("2.Add a city");
                Console.WriteLine("3.Delete a city");
                Console.WriteLine();
                Console.WriteLine("0.Back To Main Menu");
                var cityMenuKey = Console.ReadKey();
                Console.WriteLine();
                if (cityMenuKey.Key == ConsoleKey.D1)
                {
                    Console.Clear();
                    Console.WriteLine("List all cities:");
                    Console.WriteLine();
                    var cities = data.Cities.ToList();
                    foreach (var city in cities)
                    {
                        Console.WriteLine(city.Name);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    goto CityMenu;
                }
                else if (cityMenuKey.Key == ConsoleKey.D2)
                {
                    Console.Clear();
                    Console.WriteLine("Add a city:");
                    Console.WriteLine();
                    Console.Write("Enter City Name: ");
                    string cityName = Console.ReadLine();
                    if (!data.Cities.Any(c => c.Name == cityName))
                    {
                        var city = new City() { Name = cityName };
                        data.Cities.Add(city);
                        data.SaveChanges();
                        Console.WriteLine("City {0} has been successfully added!", cityName);
                    }
                    else
                    {
                        Console.WriteLine("The City with Name - {0} already exist!", cityName);
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    goto CityMenu;
                }
                else if (cityMenuKey.Key == ConsoleKey.D3)
                {
                    Console.Clear();
                    Console.WriteLine("Delete a city:");
                    Console.WriteLine();
                    Console.Write("Enter City Name: ");
                    string cityName = Console.ReadLine();
                    if (data.Cities.Any(c => c.Name == cityName))
                    {
                        var city = data.Cities.Where(c => c.Name == cityName).FirstOrDefault();
                        data.Cities.Remove(city);
                        data.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("The City with Name - {0} not exist!", cityName);
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    goto CityMenu;
                }
                else if (cityMenuKey.Key == ConsoleKey.D0)
                {
                    Console.Clear();
                    Main();
                }
                else
                {
                    goto CityMenu;
                }
            }
            else if (mainMenuKey.Key == ConsoleKey.D2)
            {
            TrainMenu:
                Console.Clear();
                Console.WriteLine("Train wise:");
                Console.WriteLine();
                Console.WriteLine("1.Get a list of trains");
                Console.WriteLine("2.Add a train");
                Console.WriteLine("3.Edit a train");
                Console.WriteLine("4.Delete a train");
                Console.WriteLine();
                Console.WriteLine("0.Back To Main Menu.");
                var trainMenuKey = Console.ReadKey();
                if (trainMenuKey.Key == ConsoleKey.D1)
                {
                    Console.Clear();
                    Console.WriteLine("List of trains:");
                    Console.WriteLine();
                    var trains = data.Trains.ToList();
                    foreach (var train in trains)
                    {
                        Console.WriteLine("Train ID:{0}, Seats:{1}, First Class Seats:{2}, Brief description:{3}", train.Id, train.Seats.Count, train.Seats.Where(t => t.Class == SeatClasses.FirstClass).Count(), train.BriefDescription);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    goto TrainMenu;
                }
                else if (trainMenuKey.Key == ConsoleKey.D2)
                {
                    Console.Clear();
                    Console.WriteLine("Add a train:");
                    Console.WriteLine();
                    var train = new Train();
                    Console.Write("Number of seats: ");
                    int seatNumber = int.Parse(Console.ReadLine());
                    if (seatNumber > 0)
                    {
                        for (int i = 1; i <= seatNumber; i++)
                        {
                            var seat = new Seat();
                            seat.Class = SeatClasses.SecondClass;
                            seat.isToken = false;
                            seat.Number = i;
                            train.Seats.Add(seat);
                        }
                        Console.Write("Enter Seat Numbers of First Class type seats (if not leave null): ");
                        string numbers = Console.ReadLine();
                        string[] seatNumbers = numbers.Split(' ');
                        if (seatNumbers.Length > 0 && seatNumbers[0] != "")
                        {
                            for (int i = 0; i < seatNumbers.Length; i++)
                            {
                                if (seatNumber < 1 && seatNumber > train.Seats.Count)
                                {
                                    Console.WriteLine("The Seat with Number {0} not exits!", seatNumber);
                                }
                                else
                                {
                                    train.Seats.ElementAt(int.Parse(seatNumbers[i]) - 1).Class = SeatClasses.FirstClass;
                                }
                            }
                        }
                    }
                    
                    Console.WriteLine("Enter Brief description:");
                    string description = Console.ReadLine();
                    train.BriefDescription = description;
                    data.Trains.Add(train);
                    data.SaveChanges();
                    Console.WriteLine();
                    Console.WriteLine("Train ID:{0}, Seats:{1}, First Class Seats:{2} Brief description:{3}, has been successfully added!", train.Id, train.Seats.Count, train.Seats.Where(t => t.Class == SeatClasses.FirstClass).Count(), train.BriefDescription);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    goto TrainMenu;
                }
                else if (trainMenuKey.Key == ConsoleKey.D3)
                {
                    Console.Clear();
                    Console.WriteLine("Edit a train:");
                    Console.WriteLine();
                    Console.Write("Enter Train ID: ");
                    int id = int.Parse(Console.ReadLine());
                    if (data.Trains.Any(t => t.Id == id))
                    {
                        var train = data.Trains.Where(t => t.Id == id).FirstOrDefault();
                        Console.Write("Number of seats: ");
                        int seatNumber = int.Parse(Console.ReadLine());
                        if (train.Seats.Count != seatNumber && seatNumber != 0)
                        {
                            foreach (var seat in train.Seats)
                            {
                                data.Seats.Remove(seat);
                            }
                            train.Seats.Clear();
                            for (int i = 1; i <= seatNumber; i++)
                            {
                                var seat = new Seat();
                                seat.Class = SeatClasses.SecondClass;
                                seat.isToken = false;
                                seat.Number = i;
                                train.Seats.Add(seat);
                            }
                            Console.Write("Enter Seat Numbers of First Class type seats (id not leave null): ");
                            string numbers = Console.ReadLine();
                            string[] seatNumbers = numbers.Split(' ');
                            if (seatNumbers.Length > 0 && seatNumbers[0] != "")
                            {
                                for (int i = 0; i < seatNumbers.Length; i++)
                                {
                                    if (seatNumber < 1 && seatNumber > train.Seats.Count)
                                    {
                                        Console.WriteLine("The Seat with Number {0} not exits!", seatNumber);
                                    }
                                    else
                                    {
                                        train.Seats.ElementAt(int.Parse(seatNumbers[i]) - 1).Class = SeatClasses.FirstClass;
                                    }
                                }
                            }
                        }
                        
                        Console.WriteLine("Enter Brief description:");
                        string description = Console.ReadLine();
                        train.BriefDescription = description;
                        data.SaveChanges();
                        Console.WriteLine();
                        Console.WriteLine("Train ID:{0}, Seats:{1}, First Class Seats:{2} Brief description:{3}, has been successfully edited!", train.Id, train.Seats.Count, train.Seats.Where(t => t.Class == SeatClasses.FirstClass).Count(), train.BriefDescription);
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    goto TrainMenu;
                }
                else if (trainMenuKey.Key == ConsoleKey.D4)
                {
                    Console.Clear();
                    Console.WriteLine("Delete a train:");
                    Console.WriteLine();
                    Console.Write("Enter Train ID: ");
                    int id = int.Parse(Console.ReadLine());
                    if (data.Trains.Any(t => t.Id == id))
                    {
                        var train = data.Trains.Where(t => t.Id == id).FirstOrDefault();

                        for (int i = 0; i < train.Seats.Count; i++)
                        {
                            data.Seats.Remove(train.Seats.ElementAt(i));
                            i--;
                        }

                        train.Seats.Clear();
                        data.Trains.Remove(train);
                        data.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("Train with ID {0} not exist!", id);
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    goto TrainMenu;
                }
                else if (trainMenuKey.Key == ConsoleKey.D0)
                {
                    Console.Clear();
                    Main();
                }
                else
                {
                    goto TrainMenu;
                }
            }
            else if (mainMenuKey.Key == ConsoleKey.D3)
            {
            ScheduleMenu:
                Console.Clear();
                Console.WriteLine("Schedule wise:");
                Console.WriteLine();
                Console.WriteLine("1.Display the full schedule");
                Console.WriteLine("2.Add a trip");
                Console.WriteLine("3.Edit an existing trip");
                Console.WriteLine("4.Get all trips from city A to city B");
                Console.WriteLine();
                Console.WriteLine("0.Back To Main Munu");
                var scheduleMenuKey = Console.ReadKey();
                if (scheduleMenuKey.Key == ConsoleKey.D1)
                {
                    Console.Clear();
                    Console.WriteLine("Display the full schedule:");
                    Console.WriteLine();
                    int count = 1;
                    var scheduleList = data.Schedules.ToList();
                    foreach (var schedule in scheduleList)
                    {
                        Console.WriteLine(count + ") TripID:{0} From:{1} - To:{2}, Time travel: {3}, TrainID:{4}, Ticket Price:{5:C2}", schedule.Id, schedule.StartingCity.Name, schedule.EndCity.Name, schedule.TimeOfTravel, schedule.Train.Id, schedule.TicketPrice);
                        Console.WriteLine("-> Train: ID:{0}, Free Seats:{1} (First Class:{2})", schedule.Train.Id, schedule.Train.Seats.Where(s => s.isToken == false).Count(), schedule.Train.Seats.Where(s => s.isToken == false && s.Class == SeatClasses.FirstClass).Count());
                        Console.WriteLine();
                        count++;
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    goto ScheduleMenu;
                }
                else if (scheduleMenuKey.Key == ConsoleKey.D2)
                {
                    Console.Clear();
                    Console.WriteLine("Add a trip:");
                    Console.WriteLine();
                    Console.Write("Enter Name of Starting City: ");
                    string startCityName = Console.ReadLine();
                    if (!data.Cities.Any(c => c.Name == startCityName))
                    {
                        Console.WriteLine("City with Name {0} not exist!", startCityName);
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        goto ScheduleMenu;
                    }
                    var startCity = data.Cities.Where(c => c.Name == startCityName).FirstOrDefault();
                    Console.Write("Enter Name of End City: ");
                    string endCityName = Console.ReadLine();
                    if (!data.Cities.Any(c => c.Name == endCityName))
                    {
                        Console.WriteLine("City with Name {0} not exist!", endCityName);
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        goto ScheduleMenu;
                    }
                    var endCity = data.Cities.Where(c => c.Name == endCityName).FirstOrDefault();
                    Console.Write("Enter Train ID: ");
                    int trainId = int.Parse(Console.ReadLine());
                    if (!data.Trains.Any(t => t.Id == trainId))
                    {
                        Console.WriteLine("Train with ID {0} not exist!", trainId);
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        goto ScheduleMenu;
                    }
                    var train = data.Trains.Where(t => t.Id == trainId).FirstOrDefault();
                    Console.Write("Enter Time Of Travel (Format: \"yyyy-MM-dd hh:mm\"): ");
                    string date = Console.ReadLine();
                    DateTime dt = DateTime.ParseExact(date, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
                    Console.Write("Enter Ticket Price: ");
                    decimal price = decimal.Parse(Console.ReadLine());

                    var schedule = new Schedule();
                    schedule.StartingCity = startCity;
                    schedule.EndCity = endCity;
                    schedule.Train = train;
                    schedule.TimeOfTravel = dt;
                    schedule.TicketPrice = price;
                    data.Schedules.Add(schedule);
                    data.SaveChanges();
                    Console.WriteLine();
                    Console.WriteLine("Schedule Created:");
                    Console.WriteLine("TripID:{0} From:{1} - To:{2}, Time travel: {3}, TrainID:{4}, Ticket Price:{5:C2}", schedule.Id, schedule.StartingCity.Name, schedule.EndCity.Name, schedule.TimeOfTravel, schedule.Train.Id, schedule.TicketPrice);
                    Console.WriteLine("-> Train: ID:{0}, Free Seats:{1} (First Class:{2})", schedule.Train.Id, schedule.Train.Seats.Where(s => s.isToken == false).Count(), schedule.Train.Seats.Where(s => s.isToken == false && s.Class == SeatClasses.FirstClass).Count());
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    goto ScheduleMenu;
                }
                else if (scheduleMenuKey.Key == ConsoleKey.D3)
                {
                    Console.Clear();
                    Console.WriteLine("Edit an existing trip:");
                    Console.WriteLine();
                    Console.Write("Trip ID: ");
                    int tripId = int.Parse(Console.ReadLine());
                    if (data.Schedules.Any(s => s.Id == tripId))
                    {
                        var schedule = data.Schedules.Where(s => s.Id == tripId).FirstOrDefault();
                        Console.WriteLine("Trip For Edit:");
                        Console.WriteLine("From:{1} - To:{2}, Time travel: {3}, TrainID:{4}, Ticket Price:{5:C2}", schedule.Id, schedule.StartingCity.Name, schedule.EndCity.Name, schedule.TimeOfTravel, schedule.Train.Id, schedule.TicketPrice);
                        Console.WriteLine("-> Train: ID:{0}, Free Seats:{1} (First Class:{2})", schedule.Train.Id, schedule.Train.Seats.Where(s => s.isToken == false).Count(), schedule.Train.Seats.Where(s => s.isToken == false && s.Class == SeatClasses.FirstClass).Count());
                        Console.WriteLine();
                        Console.Write("Enter Name of Starting City: ");
                        string startCityName = Console.ReadLine();
                        if (!data.Cities.Any(c => c.Name == startCityName))
                        {
                            Console.WriteLine("City with Name {0} not exist!", startCityName);
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            goto ScheduleMenu;
                        }
                        var startCity = data.Cities.Where(c => c.Name == startCityName).FirstOrDefault();
                        Console.Write("Enter Name of End City: ");
                        string endCityName = Console.ReadLine();
                        if (!data.Cities.Any(c => c.Name == endCityName))
                        {
                            Console.WriteLine("City with Name {0} not exist!", endCityName);
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            goto ScheduleMenu;
                        }
                        var endCity = data.Cities.Where(c => c.Name == endCityName).FirstOrDefault();
                        Console.Write("Enter Train ID: ");
                        int trainId = int.Parse(Console.ReadLine());
                        if (!data.Trains.Any(t => t.Id == trainId))
                        {
                            Console.WriteLine("Train with ID {0} not exist!", trainId);
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            goto ScheduleMenu;
                        }
                        var train = data.Trains.Where(t => t.Id == trainId).FirstOrDefault();
                        Console.Write("Enter Time Of Travel (Format: \"yyyy-MM-dd hh:mm\"): ");
                        string date = Console.ReadLine();
                        DateTime dt = DateTime.ParseExact(date, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
                        Console.Write("Enter Ticket Price: ");
                        decimal price = decimal.Parse(Console.ReadLine());
                        schedule.StartingCity = startCity;
                        schedule.EndCity = endCity;
                        schedule.Train = train;
                        schedule.TimeOfTravel = dt;
                        schedule.TicketPrice = price;
                        data.SaveChanges();
                        Console.WriteLine();
                        Console.WriteLine("Schedule Edited:");
                        Console.WriteLine("From:{1} - To:{2}, Time travel: {3}, TrainID:{4}, Ticket Price:{5:C2}", schedule.Id, schedule.StartingCity.Name, schedule.EndCity.Name, schedule.TimeOfTravel, schedule.Train.Id, schedule.TicketPrice);
                        Console.WriteLine("-> Train: ID:{0}, Free Seats:{1} (First Class:{2})", schedule.Train.Id, schedule.Train.Seats.Where(s => s.isToken == false).Count(), schedule.Train.Seats.Where(s => s.isToken == false && s.Class == SeatClasses.FirstClass).Count());
                    }
                    else
                    {
                        Console.WriteLine("There is no Trip with ID:{0}", tripId);
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    goto ScheduleMenu;
                }
                else if (scheduleMenuKey.Key == ConsoleKey.D4)
                {
                    Console.Clear();
                    Console.WriteLine("Get all trips from city A to city B:");
                    Console.WriteLine();
                    Console.Write("Enter start City Name: ");
                    string startCityName = Console.ReadLine();
                    Console.Write("Enter end City Name: ");
                    string endCityName = Console.ReadLine();
                    if (data.Schedules.Any(s => s.StartingCity.Name == startCityName && s.EndCity.Name == endCityName))
                    {
                        var trips = data.Schedules.Where(s => s.StartingCity.Name == startCityName && s.EndCity.Name == endCityName).ToList();
                        int count = 1;
                        Console.WriteLine();
                        foreach (var schedule in trips)
                        {
                            Console.WriteLine(count + ") TripID:{0} From:{1} - To:{2}, Time travel: {3}, TrainID:{4}, Ticket Price:{5:C2}", schedule.Id, schedule.StartingCity.Name, schedule.EndCity.Name, schedule.TimeOfTravel, schedule.Train.Id, schedule.TicketPrice);
                            Console.WriteLine("-> Train: ID:{0}, Free Seats:{1} (First Class:{2})", schedule.Train.Id, schedule.Train.Seats.Where(s => s.isToken == false).Count(), schedule.Train.Seats.Where(s => s.isToken == false && s.Class == SeatClasses.FirstClass).Count());
                            Console.WriteLine();
                            count++;
                        }
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Trip From:{0} - To:{1} not exist!", startCityName, endCityName);
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    goto ScheduleMenu;
                }
                else if (scheduleMenuKey.Key == ConsoleKey.D0)
                {
                    Console.Clear();
                    Main();
                }
                else
                {
                    goto ScheduleMenu;
                }
            }
            else if (mainMenuKey.Key == ConsoleKey.D4)
            {
            TicketMenu:
                Console.Clear();
                Console.WriteLine("Tickets:");
                Console.WriteLine();
                Console.WriteLine("1.Buy Ticket");
                Console.WriteLine("2.Show My Tickets");
                Console.WriteLine();
                Console.WriteLine("0.Back To Main Menu");
                var ticketMenuKey = Console.ReadKey();
                if (ticketMenuKey.Key == ConsoleKey.D1)
                {
                    Console.Clear();
                    Console.WriteLine("Buy Ticket:");
                    Console.WriteLine();
                    Console.Write("Enter Trip ID: ");
                    int tripId = int.Parse(Console.ReadLine());
                    if (data.Schedules.Any(s => s.Id == tripId))
                    {
                        var user = data.Users.Where(u => u.Id == 1).FirstOrDefault();

                        var schedule = data.Schedules.Where(t => t.Id == tripId).FirstOrDefault();
                        Console.WriteLine("TripID:{0} From:{1} - To:{2}, Time travel: {3}, TrainID:{4}, Ticket Price:{5:C2}", schedule.Id, schedule.StartingCity.Name, schedule.EndCity.Name, schedule.TimeOfTravel, schedule.Train.Id, schedule.TicketPrice);
                        Console.WriteLine("-> Train: ID:{0}, Free Seats:{1} (First Class:{2})", schedule.Train.Id, schedule.Train.Seats.Where(s => s.isToken == false).Count(), schedule.Train.Seats.Where(s => s.isToken == false && s.Class == SeatClasses.FirstClass).Count());
                        Console.WriteLine();
                        var ticket = new Ticket();
                        ticket.OriginalPrice = schedule.TicketPrice;
                    SelectNumber:
                        Console.Write("Enter Number Of Seat You Want: ");
                        int numberSeat = int.Parse(Console.ReadLine());
                        if (schedule.Train.Seats.Any(s => s.Number == numberSeat && s.isToken == false))
                        {
                            var seat = schedule.Train.Seats.Where(s => s.Number == numberSeat && s.isToken == false).FirstOrDefault();
                            seat.isToken = true;
                            ticket.SeatNumber = numberSeat;
                            decimal discount = 0;
                            if (user.DiscountCard != null)
                            {
                                discount = (ticket.OriginalPrice / 100m) * user.DiscountCard.DiscountAmount;
                            }
                            ticket.PriceSold = ticket.OriginalPrice - discount;
                            ticket.UserSoldTo = user;
                            ticket.TripDateAndTime = schedule.TimeOfTravel;
                            ticket.Schedule = schedule;
                            data.Tickets.Add(ticket);
                            data.SaveChanges();
                        }
                        else
                        {
                            Console.WriteLine("The Seat is Token or invalid number!");
                            goto SelectNumber;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Trip with ID:{0} not exits!", tripId);
                    }
                    Console.WriteLine("Press nay key to continue...");
                    Console.ReadKey();
                    goto TicketMenu;
                }
                else if (ticketMenuKey.Key == ConsoleKey.D2)
                {
                    Console.Clear();
                    var user = data.Users.Where(u => u.Id == 1).FirstOrDefault();
                    Console.WriteLine();
                    foreach (var ticket in user.Tickets)
                    {
                        Console.WriteLine("Seat Number:{0}, Original Price:{1:C2}, Sold Price:{2:C3}", ticket.SeatNumber, ticket.OriginalPrice, ticket.PriceSold);
                    }
                    Console.WriteLine("Press nay key to continue...");
                    Console.ReadKey();
                    goto TicketMenu;
                }
                else if (ticketMenuKey.Key == ConsoleKey.D0)
                {
                    Console.Clear();
                    Main();
                }
                else
                {
                    goto TicketMenu;
                }
            }
            else
            {
                Console.Clear();
                Main();
            }
        }
    }
}
