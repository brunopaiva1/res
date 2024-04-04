using System.Collections.Generic;
using System;

class FlightReservationSystem
{
    private List<Flight> flights;

    public FlightReservationSystem()
    {
        this.flights = new List<Flight>();
        flights.Add(new Flight("AA123", "Nova York", 100));
        flights.Add(new Flight("BB456", "Los Angeles", 150));
        flights.Add(new Flight("CC789", "Chicago", 120));
    }

    public void DisplayFlights()
    {
        Console.WriteLine("Voos disponíveis:");
        for (int i = 0; i < flights.Count; i++)
        {
            Flight flight = flights[i];
            Console.WriteLine((i + 1) + ". Voo " + flight.FlightNumber + ": Destino - " + flight.Destination +
                              ", Assentos disponíveis - " + flight.AvailableSeats());
        }
    }

    public Flight GetFlight(int index)
    {
        return flights[index];
    }

    public int GetNumberOfFlights()
    {
        return flights.Count;
    }

    public void CancelReservation(int flightIndex, string passengerName)
    {
        if (flightIndex >= 0 && flightIndex < flights.Count)
        {
            Flight flight = flights[flightIndex];
            flight.CancelSeat(passengerName);
        }
        else
        {
            Console.WriteLine("Voo selecionado inválido.");
        }
    }
}