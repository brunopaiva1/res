using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

class Flight
{
    private string flightNumber;
    private string destination;
    private int capacity;
    private List<string> passengers;

    public Flight(string flightNumber, string destination, int capacity)
    {
        Contract.Requires(!string.IsNullOrEmpty(flightNumber));
        Contract.Requires(!string.IsNullOrEmpty(destination));
        Contract.Requires(capacity > 0);

        this.flightNumber = flightNumber;
        this.destination = destination;
        this.capacity = capacity;
        this.passengers = new List<string>();
    }

    public string FlightNumber
    {
        get { return flightNumber; }
    }

    public string Destination
    {
        get { return destination; }
    }

    public int Capacity
    {
        get { return capacity; }
    }

    public List<string> Passengers
    {
        get { return passengers; }
    }

    public int AvailableSeats()
    {
        return capacity - passengers.Count;
    }

    public bool IsSeatAvailable()
    {
        return AvailableSeats() > 0;
    }

    public bool HasPassenger(string passengerName)
    {
        return passengers.Contains(passengerName);
    }

    public bool BookSeat(string passengerName)
    {
        Contract.Requires(!string.IsNullOrEmpty(passengerName));

        if (IsSeatAvailable())
        {
            passengers.Add(passengerName);
            Console.WriteLine("Reserva confirmada para " + passengerName + " no voo " + flightNumber + ".");
            Contract.Ensures(passengers.Count == Contract.OldValue(passengers.Count) + 1);
            return true;
        }
        else
        {
            Console.WriteLine("Desculpe, não há assentos disponíveis no voo " + flightNumber + ".");
            return false;
        }
    }

    public void CancelSeat(string passengerName)
    {
        Contract.Requires(!string.IsNullOrEmpty(passengerName));

        if (HasPassenger(passengerName))
        {
            passengers.Remove(passengerName);
            Console.WriteLine("Reserva cancelada para " + passengerName + " no voo " + flightNumber + ".");
            Contract.Ensures(passengers.Count == Contract.OldValue(passengers.Count) - 1);
        }
        else
        {
            Console.WriteLine("Passageiro " + passengerName + " não encontrado no voo " + flightNumber + ".");
        }
    }
    public void DisplayDetails()
    {
        Console.WriteLine("Detalhes do Voo " + flightNumber + ":");
        Console.WriteLine("Destino: " + destination);
        Console.WriteLine("Assentos disponíveis: " + AvailableSeats());
        Console.WriteLine("Lista de Passageiros: " + string.Join(", ", passengers));
    }
}
