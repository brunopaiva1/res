using System;

class MainClass
{
    public static void Main(string[] args)
    {
        FlightReservationSystem reservationSystem = new FlightReservationSystem();

        while (true)
        {
            Console.WriteLine("\nBem-vindo ao Sistema de Reserva de Passagens Aéreas");
            reservationSystem.DisplayFlights();

            Console.WriteLine("\nEscolha uma opção:");
            Console.WriteLine("1. Reservar um voo");
            Console.WriteLine("2. Cancelar reserva");
            Console.WriteLine("3. Adicionar novo voo");
            Console.WriteLine("4. Visualizar detalhes de um voo");
            Console.WriteLine("5. Visualizar lista de passageiros de um voo");
            Console.WriteLine("6. Sair");

            Console.Write("Opção: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ReserveFlight(reservationSystem);
                    break;
                case "2":
                    CancelReservation(reservationSystem);
                    break;
                case "3":
                    AddNewFlight(reservationSystem);
                    break;
                case "4":
                    ViewFlightDetails(reservationSystem);
                    break;
                case "5":
                    ViewPassengers(reservationSystem);
                    break;
                case "6":
                    Console.WriteLine("Saindo...");
                    return;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }

    public static void ReserveFlight(FlightReservationSystem reservationSystem)
    {
        Console.WriteLine("\nReservar um voo:");
        reservationSystem.DisplayFlights();
        Console.Write("\nEscolha um voo: ");
        int flightIndex = int.Parse(Console.ReadLine()) - 1;

        Flight selectedFlight = reservationSystem.GetFlight(flightIndex);

        Console.Write("Digite seu nome: ");
        string passengerName = Console.ReadLine();

        if (selectedFlight.BookSeat(passengerName))
        {
            Console.WriteLine("Reserva realizada com sucesso.");
        }
        else
        {
            Console.WriteLine("Falha ao realizar reserva.");
        }
    }

    public static void CancelReservation(FlightReservationSystem reservationSystem)
    {
        Console.WriteLine("\nCancelar reserva:");
        reservationSystem.DisplayFlights();
        Console.Write("\nEscolha um voo: ");
        int flightIndex = int.Parse(Console.ReadLine()) - 1;

        Console.Write("Digite seu nome: ");
        string passengerName = Console.ReadLine();

        reservationSystem.CancelReservation(flightIndex, passengerName);
    }

    public static void AddNewFlight(FlightReservationSystem reservationSystem)
    {
        Console.WriteLine("\nAdicionar novo voo:");
        Console.Write("Digite o número do voo: ");
        string flightNumber = Console.ReadLine();

        Console.Write("Digite o destino: ");
        string destination = Console.ReadLine();

        Console.Write("Digite a capacidade do voo: ");
        int capacity = int.Parse(Console.ReadLine());

        reservationSystem.AddFlight(flightNumber, destination, capacity);
    }

    public static void ViewFlightDetails(FlightReservationSystem reservationSystem)
    {
        Console.WriteLine("\nVisualizar detalhes de um voo:");
        reservationSystem.DisplayFlights();
        Console.Write("\nEscolha um voo: ");
        int flightIndex = int.Parse(Console.ReadLine()) - 1;

        reservationSystem.ViewFlightDetails(flightIndex);
    }

    public static void ViewPassengers(FlightReservationSystem reservationSystem)
    {
        Console.WriteLine("\nVisualizar lista de passageiros de um voo:");
        reservationSystem.DisplayFlights();
        Console.Write("\nEscolha um voo: ");
        int flightIndex = int.Parse(Console.ReadLine()) - 1;

        reservationSystem.ViewPassengers(flightIndex);
    }
}