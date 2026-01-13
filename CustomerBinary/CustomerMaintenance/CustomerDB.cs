namespace CustomerMaintenance
{
    public static class CustomerDB
    {
        
        private const string Dir = @"C:\C#\Files\";
        private const string path = Dir + "Customers.dat";
    
        public static void SaveCustomers(List<Customer> customers)
        {
            using BinaryWriter binaryOut = new( new FileStream(path, FileMode.Create, FileAccess.Write));
            
            foreach (Customer customer in customers)
                {
                    binaryOut.Write(customer.FirstName);
                binaryOut.Write(customer.LastName);
                binaryOut.Write(customer.Email);

                }

        }

        public static List<Customer> GetCustomers()
        {
            List<Customer> customers = new();

            if (!Directory.Exists(Dir))
   
                Directory.CreateDirectory(Dir);

            using BinaryReader binaryIn = new( new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read));

            while (binaryIn.PeekChar() != -1)
            {

                    Customer customer = new()
                    {
                        FirstName = binaryIn.ReadString(),
                        LastName = binaryIn.ReadString(),
                        Email = binaryIn.ReadString()

                    };
                    customers.Add(customer);
            }
            // TODO: Add code that reads a collection of Customer objects 
            // from a text file

            return customers;
        }
    }
}
