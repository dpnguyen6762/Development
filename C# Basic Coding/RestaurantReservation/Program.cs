using System;
using System.Collections.Generic;
using System.Linq;


namespace RestaurantReservation
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int maxPartySize = 8; //Tables between 3 and 8 people
			int minPartySize = 3;
			int numberOfTables = 12; //# of Tablesz
			int totalPossibleReservations = 50;
			Restaurant restaurant = SetupRestaurant(maxPartySize, minPartySize, numberOfTables);
			List<Reservation> reservations = BookReservations(restaurant, minPartySize, maxPartySize, totalPossibleReservations);
			//reservations = reservations.OrderBy(x => x.Table.TableNumber).ThenBy(x => x.StartTime).ToList();
			reservations = reservations.OrderBy(x => x.StartTime).ThenBy(x => x.Table.TableNumber).ToList();
			foreach (var reservation in reservations)
			{
				string table = reservation.Table.TableNumber < 1 || reservation.Table.TableNumber > 9 ? reservation.Table.TableNumber.ToString() : "0" + reservation.Table.TableNumber.ToString();
				Console.WriteLine($"Reservation Name: {reservation.Name} - Table: {table}, TimeSpan: {reservation.StartTime.TimeOfDay}-{reservation.StartTime.TimeOfDay + restaurant.reservationDurationsPerPartySize[reservation.PartySize]}, Size: {reservation.PartySize}");
			}

			// Keep the console window open in debug mode.
			Console.WriteLine("Press any key to exit.");
			System.Console.ReadKey();

		}

		private static Restaurant SetupRestaurant(int maxPartySize, int minPartySize, int numberOfTables)
		{
			Random random = new Random();
			Restaurant restaurant = new Restaurant();
			restaurant.tables = new List<Table>();
			restaurant.openTime = new DateTime(2000, 1, 1, 10, 0, 0); //Open Time 10 am
			restaurant.closeTime = new DateTime(2000, 1, 1, 22, 0, 0); //Close Time 10 pm
			restaurant.reservationDurationsPerPartySize = new Dictionary<int, TimeSpan>();
			//Creates tables in system with random sizes
			for (int i = 1; i <= numberOfTables; i++)
			{
				var table = new Table { MaxPartySize = random.Next(minPartySize, maxPartySize + 1), TableNumber = i};
				restaurant.tables.Add(table);
				Console.WriteLine($"Table #{i}. Max Party Size: {table.MaxPartySize}");
			}

			Console.WriteLine("");
			//Sets duration of each party by size
			for (int i = minPartySize; i <= maxPartySize; i++)
			{
				int minutesOfParty = 20 + (i * 5);
				restaurant.reservationDurationsPerPartySize.Add(i, new TimeSpan(0, minutesOfParty, 0));
				Console.WriteLine($"Table Size: {i}. Duration of Party: {minutesOfParty} Minutes");
			}

			Console.WriteLine("");
			Console.WriteLine("-------------------------------------------------------");
			Console.WriteLine("");
			return restaurant;
		}

		// Write a Restaurant Booking System
		// You are encouraged to refactor exisiting code, create other classes, write helper methods etc
		// You also need to make sure that the implementation works correctly
		//The BookReservations function should fill in your reservation list
		//It should call restaurant.BookReservation(reservation) possible reservations
		//and only add them to the list if the reservatin was valid and successful
		private static List<Reservation> BookReservations(Restaurant restaurant, int minPartySize, int maxPartySize, int totalPossibleReservations)
		{
			Random random = new Random();
			List<Reservation> reservations = new List<Reservation>();
			for (int i = 0; i < totalPossibleReservations; i++)
			{
				string name = (i + 1) < 10 ? "Rsv0" + (i + 1) : "Rsv" + (i + 1);
				Reservation reservation = new Reservation { Name = name, PartySize = random.Next(minPartySize, maxPartySize + 1), StartTime = new DateTime(2000, 1, 1, random.Next(7, 24), random.Next(0, 60), 0) };
				reservations.Add(reservation);
			}

			reservations = reservations.OrderBy(x => x.StartTime).ToList();

			//Create new reservation
			for (int j = 0; j < reservations.Count; j++)
			{
				Reservation reservation = reservations[j];
				//Call restaurant.BookReservation(reservation) to fill up reservation list
				restaurant.BookReservation(reservation);
			}
			//if reservation was successfully booked  reservations.Add(reservation);
			return reservations;
		}


	}

	class Reservation
	{
		public string Name { get; set; }
		public int PartySize { get; set; }
		public DateTime StartTime { get; set; } = new DateTime(2000, 1, 1, 10, 0, 0);
		internal Table Table { get; set; }
	}

	class Table  
	{
		public int TableNumber { get; set; }
		public int MaxPartySize { get; set; }
		public DateTime TableBookingEndTime { get; set; } = new DateTime(2000, 1, 1, 10, 0, 0);
	}

	class Restaurant
	{
		public List<Table> tables;
		public DateTime openTime;
		public DateTime closeTime;
		public Dictionary<int, TimeSpan> reservationDurationsPerPartySize;
		// Assigns a Table to the Reservation if it could be booked,otherwise assigns null
		// Booking rules: 
		// 1) Reservation could be made only when the Restaurant is open.
		// 2) Only one Reservation can be seatted a Table at any time.
		// 3) Reservation can be seatted only at a Table of the same or a bigger size.
		// 4) Reservation should stay on the same Table for the whole Duration.
		// 5) Reservation Duration is determined by PartySize.
		public void BookReservation(Reservation reservation)
		{
			var isRestaurantOpen = HelperMethods.IsRestaurantOperatingHours(this, reservation);

			var AssignedTable = isRestaurantOpen ? HelperMethods.GetTable(this, reservation) : 0;
			
			//TODO: Find an available table from the list of tables 
			//reservation.table = new Table { tableNumber = -1 }; //Assign a -1 table number if no possible reservations exist  
			reservation.Table = new Table { TableNumber = AssignedTable > 0 ? AssignedTable : -1}; 
		}
	}
	class HelperMethods
	{
		public static bool IsRestaurantOperatingHours(Restaurant restaurant, Reservation reservation)
		{
			var startTime = restaurant.openTime.TimeOfDay.Hours;
			var closeTime = restaurant.closeTime.TimeOfDay.Hours;
			var currentReservationTime = reservation.StartTime.Hour;

			if ( currentReservationTime >= startTime && currentReservationTime < closeTime)
			{
				return true;
			}

			return false;
		}

		public static int GetTable(Restaurant restaurant, Reservation reservation)
		{
			var BookedTable       = 0;

			var AssignedTables = restaurant.tables.Where(b => b.MaxPartySize >= reservation.PartySize && b.TableBookingEndTime < reservation.StartTime)
														.Select(b => b.TableNumber).ToList();
			
			foreach (var AssignedTable in AssignedTables)
			{
				foreach (Table table in restaurant.tables)
				{					
					if (table.TableNumber == AssignedTable)
					{
						if (restaurant.closeTime < table.TableBookingEndTime)
						{
							continue;
						}
						else 
						{ 
							int DurationInMinutes = (int)(restaurant.reservationDurationsPerPartySize[reservation.PartySize].Minutes);
							table.TableBookingEndTime = reservation.StartTime.AddMinutes(DurationInMinutes);

							return AssignedTable;							
						}

					}
				}

			}

			return BookedTable;
		}


	}


}
 