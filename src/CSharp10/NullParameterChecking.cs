using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp10
{
    class NullParameterChecking
    {
        public void UpdateAddress(int customerId, Address address)
        {
            if (address is null)
            {
                throw new ArgumentNullException(nameof(address));
            }
        }

        public void UpdateAddressV2(int customerId, Address address)
        {

        }
    }

    public class Address
    {
    }
}
