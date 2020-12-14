using System;

namespace AdventOfCode.Challenges._2020
{
    class Day_05 : AChallenge2020
    {
        public override string PartOne()
        {
            var maxSeatId = 0;
            var minRow = 0;
            var rows = 127;
            var minSeat = 0;
            var seats = 7;

            foreach (var ticket in Input)
            {
                var seat = GetSeat(ticket, rows, minRow, seats, minSeat);
                var seatId = GetSeatId(seat.row, seat.seat, seats + 1);

                if (seatId > maxSeatId)
                {
                    maxSeatId = seatId;
                }
            }

            return $"Max seat ID: {maxSeatId}";
        }

        public override string PartTwo()
        {
            var minRow = 0;
            var rows = 127;
            var minSeat = 0;
            var seats = 7;

            var flight = new char[rows+1, seats+1];

            foreach (var ticket in Input)
            {
                var seat = GetSeat(ticket, rows, minRow, seats, minSeat);
                flight[seat.row, seat.seat] = 'X';
            }

            for (int i = 0; i < flight.GetLength(0); i++)
            {
                for (int j = 1; j < flight.GetLength(1)-1; j++)
                {
                    var seat = flight[i,j];

                    if (seat == '\0')
                    {
                        var seatBefore = flight[i, j - 1];
                        var seatAfter = flight[i, j + 1];

                        if (seatBefore == 'X' && seatAfter == 'X')
                        {

                            return $"Your Seat ID: {GetSeatId(i, j, seats+1)}";
                        }
                    }
                }
            }

            return $"Not Found";
        }

        private int GetSeatId(int row, int seat, int seatsInRow)
        {
            return row * seatsInRow + seat;
        }

        private (int row, int seat) GetSeat(string ticket, int rows, int minRow, int seats, int minSeat)
        {
            var rowFrom = minRow;
            var rowTo = rows;
            var seatFrom = minSeat;
            var seatTo = seats;
            foreach (var range in ticket.ToCharArray())
            {
                var rowNextStep = 0;
                var seatNextStep = 0;
                if (range == 'F' || range == 'B')
                {
                    var rowDiff = 1 + rowTo - rowFrom;
                    rowNextStep = rowDiff / 2;
                }
                else if (range == 'R' || range == 'L')
                {
                    var seatDiff = 1 + seatTo - seatFrom;
                    seatNextStep = seatDiff / 2;
                }
                else
                {
                    throw new Exception();
                }

                switch (range)
                {
                    case 'F':
                        rowTo -= rowNextStep;
                        break;
                    case 'B':
                        rowFrom += rowNextStep;
                        break;
                    case 'L':
                        seatTo -= seatNextStep;
                        break;
                    case 'R':
                        seatFrom += seatNextStep;
                        break;
                    default:
                        throw new Exception();

                }
            }

            if (rowFrom == rowTo && seatFrom == seatTo)
            {
                return (rowFrom, seatFrom);
            }
            else
            {
                throw new Exception("Row or Seat do not match");
            }
        }

    }
}
