using System;
using System.Collections.Generic;
using System.Text;

namespace homework5
{
    class Client
    {
        public string ClientName
        {
            get;set;
        }
        public string Address
        {
            get;set;
        }
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
        public override int GetHashCode() => ClientName.GetHashCode() ^ Address.GetHashCode();

    }
}
