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

            Console.Write("\nEscolha um voo (ou 'q' para sair): ");
            string choice = Console.ReadLine();
            if (choice.ToLower() == "q")
            {
                break;
            }

            try
            {
                int flightNumber = int.Parse(choice);
                if (flightNumber >= 1 && flightNumber <= reservationSystem.GetNumberOfFlights())
                {
                    Flight selectedFlight = reservationSystem.GetFlight(flightNumber - 1);

                    selectedFlight.DisplayDetails();

                    Console.Write("Digite seu nome: ");
                    string passengerName = Console.ReadLine();

                    Console.WriteLine("Escolha uma opção:");
                    Console.WriteLine("1. Reservar assento");
                    Console.WriteLine("2. Cancelar reserva");

                    int option = int.Parse(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            if (selectedFlight.BookSeat(passengerName))
                            {
                                Console.WriteLine("Reserva realizada com sucesso.");
                            }
                            else
                            {
                                Console.WriteLine("Falha ao realizar reserva.");
                            }
                            break;
                        case 2:
                            reservationSystem.CancelReservation(flightNumber - 1, passengerName);
                            break;
                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Escolha inválida. Por favor, digite o número do voo.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Escolha inválida. Por favor, digite o número do voo.");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Escolha inválida. Por favor, digite o número do voo.");
            }
        }
    }
}
