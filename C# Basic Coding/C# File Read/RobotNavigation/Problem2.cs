using System;
using System.Collections.Generic;
using System.Linq;

//Restaurant Test

//This test will have you implement an function that checks if an available Table exists in a restaurant for various reservations
//This program will randomize 12 Tables with various sizes.  
//The Restaurant has a open and close time, and has a set of timespans defining how long a party will sit at a table

//Reservations will be created and it is your job to write the function that will check if a table is available at the time and for the size of that party

//The Restaurant.BookReservation(reservation) function should be filled in with the logic for checking and assigning a table to the input reservation

//If no tables is available for that reservation. Then a table with table number -1 should be assigned to it

//


namespace Test
{
	class Program
	{
		static void Main(string[] args)
		{
			int maxPartySize = 8; //Tables between 3 and 8 people
			int minPartySize = 3;
			int numberOfTables = 12; //# of Tables
			int totalPossibleReservations = 50;
			Restaurant restaurant = SetupRestaurant(maxPartySize, minPartySize, numberOfTables);
			List<Reservation> reservations = BookReservations(restaurant, minPartySize, maxPartySize, totalPossibleReservations);
			reservations = reservations.OrderBy(x => x.table.tableNumber).ThenBy(x => x.startTime).ToList();
			foreach (var reservation in reservations)
			{
				string table = reservation.table.tableNumber < 1 || reservation.table.tableNumber > 9 ? reservation.table.tableNumber.ToString() : "0" + reservation.table.tableNumber.ToString();
				Console.WriteLine($"Reservation Name: {reservation.name} - Table: {table}, TimeSpan: {reservation.startTime.TimeOfDay}-{reservation.startTime.TimeOfDay + restaurant.reservationDurationsPerPartySize[reservation.partySize]}, Size: {reservation.partySize}");
			}
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
				var table = new Table { maxPartySize = random.Next(minPartySize, maxPartySize + 1), tableNumber = i };
				restaurant.tables.Add(table);
				Console.WriteLine($"Table #{i}. Max Party Size: {table.maxPartySize}");
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
		//It should call restaurant.BookReservation(reservation) possible reservations and only add them to the list if the reservatin was valid and successful
		private static List<Reservation> BookReservations(Restaurant restaurant, int minPartySize, int maxPartySize, int totalPossibleReservations)
		{
			Random random = new Random();
			List<Reservation> reservations = new List<Reservation>();
			for (int i = 0; i < totalPossibleReservations; i++)
			{
				string name = (i + 1) < 10 ? "Rsv0" + (i + 1) : "Rsv" + (i + 1);
				Reservation reservation = new Reservation { name = name, partySize = random.Next(minPartySize, maxPartySize + 1), startTime = new DateTime(2000, 1, 1, random.Next(7, 24), random.Next(0, 60), 0) };
				reservations.Add(reservation);
			}

			//Create new reservation
			foreach (var reservation in reservations)
				//Call restaurant.BookReservation(reservation) to fill up reservation list
				restaurant.BookReservation(reservation);
			//if reservation was successfully booked  reservations.Add(reservation);
			return reservations;
		}
	}

	class Reservation
	{
		public String name;
		public int partySize;
		public DateTime startTime;
		public Table table;
	}

	class Table
	{
		public int tableNumber; //table number
		public int maxPartySize; //Max size on that table
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
			//TODO: Find an available table from the list of tables 
			reservation.table = new Table { tableNumber = -1 }; //Assign a -1 table number if no possible reservations exist  


		}
	}
}