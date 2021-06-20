using System;
using System.Collections.Generic;
using System.Text;

namespace homework8
{
    public class Client
    {
        public string ClientName
        {
            get;set;
        }
        public string Address
        {
            get;set;
        }
        public Client() { }
        public Client(string name,string address)
        {
            ClientName = name;
            Address = address;
        }
        public override string ToString()
        {
            return $"Client name: {ClientName}, address: {Address}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Client other = (Client)obj;
            return ClientName == other.ClientName && Address == other.Address;
        }

        public override int GetHashCode()
        {
            int hashCode = 664343032;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ClientName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Address);
            return hashCode;
        }
    }
}
