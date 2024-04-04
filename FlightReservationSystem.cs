using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System;
using System.Linq;

class FlightReservationSystem
{
    private List<Flight> flights;

    public FlightReservationSystem()
    {
        this.flights = new List<Flight>();
        InitializeFlights();
    }

    private void InitializeFlights()
    {
        AddFlight("AA123", "Nova York", 100);
        AddFlight("BB456", "Los Angeles", 150);
        AddFlight("CC789", "Chicago", 120);
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
        Contract.Requires(index >= 0 && index < flights.Count);

        return flights[index];
    }

    public int GetNumberOfFlights()
    {
        return flights.Count;
    }

    public void CancelReservation(int flightIndex, string passengerName)
    {
        Contract.Requires(flightIndex >= 0 && flightIndex < flights.Count);
        Contract.Requires(!string.IsNullOrEmpty(passengerName));

        Flight flight = flights[flightIndex];
        flight.CancelSeat(passengerName);
    }

    public void AddFlight(string flightNumber, string destination, int capacity)
    {
        Contract.Requires(!string.IsNullOrEmpty(flightNumber));
        Contract.Requires(!string.IsNullOrEmpty(destination));
        Contract.Requires(capacity > 0);

        if (!flights.Any(f => f.FlightNumber == flightNumber))
        {
            Flight newFlight = new Flight(flightNumber, destination, capacity);
            flights.Add(newFlight);
            Console.WriteLine("Novo voo adicionado com sucesso: " + flightNumber + " para " + destination + ".");
        }
        else
        {
            Console.WriteLine("O número do voo já está em uso. Por favor, escolha outro número.");
        }
    }


public void ViewFlightDetails(int flightIndex)
    {
        Contract.Requires(flightIndex >= 0 && flightIndex < flights.Count);

        Flight flight = flights[flightIndex];
        flight.DisplayDetails();
    }

    public void ViewPassengers(int flightIndex)
    {
        Contract.Requires(flightIndex >= 0 && flightIndex < flights.Count);

        Flight flight = flights[flightIndex];
        Console.WriteLine("Lista de Passageiros para o Voo " + flight.FlightNumber + ":");
        Console.WriteLine(string.Join(", ", flight.Passengers));
    }
}
