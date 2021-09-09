using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp10
{
    public class Employee
    {
        private DateTime _hireDate;

        public DateTime HireDate
        {
            get
            {
                return _hireDate;
            }
            set
            {
                _hireDate = value.Date;
            }
        }
    }

    public class AnotherEmployee
    {
        public DateTime HireDate { get; set => field = value.Date; }
        public DateTime DateOfVisit { get; init => field = value.Date; }
    }

    public record TheOtherEmployee
    {
        public required string Name { get; init; }
        public decimal YearlySalary { get; init; }
        public DateTime HiredDate { get; init; }
    }
}
